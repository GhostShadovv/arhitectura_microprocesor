using proiectAC.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectAC
{
    class JumpOperandInstruction
    {
        public string JumpInstr(string[] noSpace, ref Dictionary<string, int> labels, int Offset_PC, int PC)
        {
            /* noSpace[0] noSpace[1]
             *   opcode,    offset
            */
            string opcode = Types.Search(noSpace[0]);
            return CheckLabelOffset(noSpace[1], opcode, 127, 8, ref labels, Offset_PC, PC);
        }

        /// <summary>
        /// Calculeaza distanta pana la eticheta si incadrarea in limitele de salt
        /// </summary>
        /// <param name="noSpace"></param>
        /// <param name="opcode"></param>
        /// <param name="limit"></param>
        /// <param name="bits_size"></param>
        /// <returns></returns>
        internal static string CheckLabelOffset(string noSpace, string opcode, int limit, int bits_size, ref Dictionary<string, int> labels, int Offset_PC, int PC)
        {
            //Daca se cauta eticheta
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
            //Daca se cauta valoare
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
                //Verificari conditii si tratare exceptii
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
    }
}
