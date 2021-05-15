using customButton.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectAC
{
    class OneOperandInstruction
    {
        /// <summary>
        /// Corectie pentru instructiunile formate din 2 cuvinte. Ex: push pc VS push r1
        /// </summary>
        /// <param name="noSpace"></param>
        /// <param name="opcode"></param>
        /// <returns></returns>
        public string CorrectOneOperand(string[] noSpace, ref string opcode, ref Dictionary<string, int> labels, Dictionary<string, int> procedures, int lineNumberDebug, int Offset_PC, int PC)
        {
            //in cazul in care am push flags, pop flags, push pc, pop pc, sa mearga mai departe
            if (!(noSpace[1].Equals("FLAG") || noSpace[1].Equals("PC")))
            {
                return OneOperand(noSpace, ref labels, procedures, Offset_PC, PC);
            }
            else
            {
                if (noSpace[1].Equals("FLAG"))
                {                    
                    Trace.WriteLine($"Corectat opcode: {opcode}, instructiunea {noSpace[1]} in opcode: {Types.Search("PUSH FLAG")}, instructiunea PUSH FLAG la linia {lineNumberDebug}");
                    return Types.Search("PUSH FLAG");
                }
                else
                {
                    if (noSpace[1].Equals("PC"))
                    {
                        Trace.WriteLine($"Corectat opcode: {opcode}, instructiunea {noSpace[1]} in opcode: {Types.Search("PUSH PC")}, instructiunea PUSH PC la linia {lineNumberDebug}");
                        return Types.Search("PUSH PC");
                    }
                    else
                    {
                        throw new InvalidExpressionException("Greseala");
                    }
                }
            }
        }

        private static string OneOperand(string[] noSpace, ref Dictionary<string, int> labels, Dictionary<string, int> procedures, int Offset_PC, int PC)
        {
            /* noSpace[0] noSpace[1]
             *    opcode,      dest
            */
            string opcode = Types.Search(noSpace[0]);
            string MAD;
            string RD;
            string destOp = "";
            //JMP eticheta
            if (noSpace[0].Equals(Types.jmpInstr) && !noSpace[1].Contains("R"))
            {
                return CheckLabelOffset(noSpace[1], opcode, 31, 6, Offset_PC, PC, labels);
            }
            if (noSpace[0].Equals(Types.jmpInstr) && noSpace[1].Contains("R"))
            {
                destOp = JumpEncodeRegister(noSpace, out MAD, out RD, destOp);
                return Types.ReturnBinaryLine(opcode, "", "", MAD, RD, destOp, "");
            }
            if (noSpace[0].Equals(Types.callInstr))
            {
                MAD = Types.Search("MA_IMEDIAT");
                RD = Types.Search("R0");
                destOp = Types.ConvertNumbersToString(noSpace[1]);
                if (destOp != "0".PadLeft(16, '0'))
                {
                    var procedure_aux = procedures.FirstOrDefault(t => t.Key == noSpace[1]);
                    if (procedure_aux.Key != null)
                    {
                        destOp = Types.ConvertNumbersToString(procedure_aux.Value.ToString());
                        return Types.ReturnBinaryLine(opcode, "", "", MAD, RD, destOp, "");
                    }
                }
                return Types.ReturnBinaryLine(opcode, "", "", MAD, RD, destOp, "");
            }
            else
            {
                destOp = Types.RegisterEncode(noSpace[1], out MAD, out RD);
                return Types.ReturnBinaryLine(opcode, "", "", MAD, RD, destOp, "");
            }

        }

        /// <summary>
        /// Calculeaza distanta pana la eticheta si incadrarea in limitele de salt
        /// </summary>
        /// <param name="noSpace"></param>
        /// <param name="opcode"></param>
        /// <param name="limit"></param>
        /// <param name="bits_size"></param>
        /// <returns></returns>
        private static string CheckLabelOffset(string noSpace, string opcode, int limit, int bits_size, int Offset_PC, int PC, Dictionary<string,int> labels)
        {
            var label_aux = labels.FirstOrDefault(t => t.Key == noSpace);
            if (label_aux.Key != null)
            {
                Offset_PC = label_aux.Value - PC;
                if (Offset_PC > -(limit + 1) && Offset_PC < limit)
                {
                    return Offset_PC < 0 ? opcode + Convert.ToString((label_aux.Value - PC), 2).Substring(16).Substring(opcode.Length).PadLeft(bits_size, '1') :
                        opcode + Convert.ToString((label_aux.Value - PC), 2).PadLeft(bits_size, '0');
                }
                else
                {
                    Trace.WriteLine($"Eticheta {label_aux.Key} se afla la o distanta mai mare de {limit} pozitii relative de {PC} si anume {Offset_PC}");
                    throw new InvalidExpressionException("Distanta pentru instructiunea JMP este prea mare");
                }
            }
            else
            {
                int value;
                switch (noSpace)
                {
                    case string _ when noSpace.StartsWith("0X"):
                        noSpace = noSpace.Substring(2);
                        value = Convert.ToInt32(noSpace, 16);
                        break;
                    case string _ when noSpace.StartsWith("0B"):
                        noSpace = noSpace.Substring(2);
                        value = Convert.ToInt32(noSpace, 2);
                        break;
                    default:
                        int.TryParse(noSpace, out value);
                        break;
                }
                int PCnext = value - PC;
                if (PCnext - PC < 0)
                {
                    //TO DO !!!!
                    Trace.WriteLine($"TODO trebuie sa verifici daca iesi din zona de cod nu adresa mai mica de 0 sau poate nu, cine stie ... :) ");

                    Trace.WriteLine($"Ai ajuns la o zona de memorie mai mica de adresa 0");
                    throw new InvalidExpressionException($"Ai ajuns la o zona de memorie mai mica de adresa 0");
                }

                if (PCnext != 0)
                {
                    if (PCnext > -(limit + 1) && PCnext < limit)
                    {
                        return opcode + Types.ConvertNumbersToString(noSpace).Substring(opcode.Length);//operand 7 biti
                    }
                    else
                    {
                        Trace.WriteLine($"Offset-ul {value} depaseste domeniul de reprezentare (-128,128)");
                        throw new InvalidExpressionException($"Salt la o valoare mai mare de 128 instructiuni");
                    }
                }
                else
                {
                    Trace.WriteLine($"Ai vrut sa faci salt la adresa curenta");
                    throw new InvalidExpressionException($"Nu poti face salt cu offset 0");
                }
            }
        }

        /// <summary>
        /// Codifica modul de adresare si registrul specific instructiunii de JMP. Are doar mod de adresare indirect sau indexat
        /// </summary>
        /// <param name="noSpace"></param>
        /// <param name="MAD"></param>
        /// <param name="RD"></param>
        /// <param name="destOp"></param>
        /// <returns></returns>
        private static string JumpEncodeRegister(string[] noSpace, out string MAD, out string RD, string destOp)
        {
            if (noSpace[1].Contains(Types.indirectSeparator))
            {
                string[] source_search = noSpace[1].Split(new[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                if (source_search.Length == 1)
                {
                    MAD = Types.Search("MA_INDIRECT");
                    RD = Types.Search(source_search[0]);
                }
                else
                {
                    MAD = Types.Search("MA_INDEXAT");
                    Types.CheckSideOperand(out RD, out destOp, source_search);
                }
            }
            else
            {
                Trace.WriteLine($"Instructiunea {noSpace[0]} nu poate fi adresata decat indirect sau indexat");
                throw new InvalidExpressionException($"Instructiunea {noSpace[0]} nu poate fi adresata decat indirect sau indexat");
            }

            return destOp;
        }

    }
}
