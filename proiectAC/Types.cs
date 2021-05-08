using System;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace customButton.Forms
{
    public static class Types
    {
        public static string oneOperand = "10";
        public static string twoOperand = "0";
        public static string jumpOperand = "110";
        public static string diversOperand = "111";
        public static string callInstr = "CALL";
        public static string jmpInstr = "JMP";
        public static string indirectSeparator = "(";
        public static string hexSeparator = "0X";
        public static string binarySeparator = "0B";

        private static readonly string MOV = "0000";
        private static readonly string ADD = "0001";
        private static readonly string SUB = "0010";
        private static readonly string CMP = "0011";
        private static readonly string AND = "0100";
        private static readonly string OR  = "0101";
        private static readonly string XOR = "0110";

        private static readonly string CLR = "1000000000";
        private static readonly string NEG = "1000000001";
        private static readonly string INC = "1000000010";
        private static readonly string DEC = "1000000011";
        private static readonly string ASL = "1000000100";
        private static readonly string ASR = "1000000101";
        private static readonly string LSR = "1000000110";
        private static readonly string ROL = "1000000111";
        private static readonly string ROR = "1000001000";
        private static readonly string RLC = "1000001001";
        private static readonly string RRC = "1000001010";
        private static readonly string JMP = "1000001011";
        private static readonly string CALL= "1000001100";
        private static readonly string PUSH= "1000001101";
        private static readonly string POP = "1000001110";

        private static readonly string BR  = "11000000";
        private static readonly string BNE = "11000001";
        private static readonly string BEQ = "11000010";
        private static readonly string BPL = "11000011";
        private static readonly string BMI = "11000100";
        private static readonly string BCS = "11000101";
        private static readonly string BCC = "11000110";
        private static readonly string BVS = "11000111";
        private static readonly string BVC = "11000000";

        private static readonly string CLC =      "1110000000000000";
        private static readonly string CLV =      "1110000000000001";
        private static readonly string CLZ =      "1110000000000010";
        private static readonly string CLS =      "1110000000000011";
        private static readonly string CCC =      "1110000000000100";
        private static readonly string SEC =      "1110000000000101";
        private static readonly string SEV =      "1110000000000110";
        private static readonly string SEZ =      "1110000000000111";
        private static readonly string SES =      "1110000000001000";
        private static readonly string SCC =      "1110000000001001";
        private static readonly string NOP =      "1110000000001010";
        private static readonly string RET =      "1110000000001011";
        private static readonly string RETI=      "1110000000001100";
        private static readonly string HALT=      "1110000000001101";
        private static readonly string WAIT=      "1110000000001110";
        private static readonly string PUSH_PC=   "1110000000001111";
        private static readonly string POP_PC =   "1110000000010000";
        private static readonly string PUSH_FLAG= "1110000000010001";
        private static readonly string POP_FLAG = "1110000000010010";

        private static readonly string R0  = "0000";
        private static readonly string R1  = "0001";
        private static readonly string R2  = "0010";
        private static readonly string R3  = "0011";
        private static readonly string R4  = "0100";
        private static readonly string R5  = "0101";
        private static readonly string R6  = "0110";
        private static readonly string R7  = "0111";
        private static readonly string R8  = "1000";
        private static readonly string R9  = "1001";
        private static readonly string R10 = "1010";
        private static readonly string R11 = "1011";
        private static readonly string R12 = "1100";
        private static readonly string R13 = "1101";
        private static readonly string R14 = "1110";
        private static readonly string R15 = "1111";


        private static readonly string MA_IMEDIAT = "00";
        private static readonly string MA_DIRECT = "01";
        private static readonly string MA_INDIRECT = "10";
        private static readonly string MA_INDEXAT = "11";

        public static string Search(string text)
        {
            switch (text)
            {
                case "MOV": return MOV;
                case "ADD": return ADD;
                case "SUB": return SUB;
                case "CMP": return CMP;
                case "AND": return AND;
                case "OR": return OR;
                case "XOR": return XOR;

                case "CLR": return CLR;
                case "NEG": return NEG;
                case "INC": return INC;
                case "DEC": return DEC;
                case "ASL": return ASL;
                case "ASR": return ASR;
                case "LSR": return LSR;
                case "ROL": return ROL;
                case "ROR": return ROR;
                case "RLC": return RLC;
                case "RRC": return RRC;
                case "JMP": return JMP;
                case "CALL": return CALL;
                case "PUSH": return PUSH;
                case "POP": return POP;

                case "BR": return BR;
                case "BNE": return BNE;
                case "BEQ": return BEQ;
                case "BPL": return BPL;
                case "BMI": return BMI;
                case "BCS": return BCS;
                case "BCC": return BCC;
                case "BVS": return BVS;
                case "BCV": return BVC;

                case "CLC": return CLC;
                case "CLV": return CLV;
                case "CLZ": return CLZ;
                case "CLS": return CLS;
                case "CCC": return CCC;
                case "SEC": return SEC;
                case "SEV": return SEV;
                case "SEZ": return SEZ;
                case "SES": return SES;
                case "SCC": return SCC;
                case "NOP": return NOP;
                case "RET": return RET;
                case "RETI": return RETI;
                case "HALT": return HALT;
                case "WAIT": return WAIT;
                case "PUSH PC": return PUSH_PC;
                case "POP PC": return POP_PC;
                case "PUSH FLAG": return PUSH_FLAG;
                case "POP FLAG": return POP_FLAG;

                case "R0": return R0;
                case "R1": return R1;
                case "R2": return R2;
                case "R3": return R3;
                case "R4": return R4;
                case "R5": return R5;
                case "R6": return R6;
                case "R7": return R7;
                case "R8": return R8;
                case "R9": return R9;
                case "R10": return R10;
                case "R11": return R11;
                case "R12": return R12;
                case "R13": return R13;
                case "R14": return R14;
                case "R15": return R15;

                case "MA_IMEDIAT": return MA_IMEDIAT;
                case "MA_DIRECT": return MA_DIRECT;
                case "MA_INDIRECT": return MA_INDIRECT;
                case "MA_INDEXAT": return MA_INDEXAT;
                default:
                    return text;
            }
        }

        /// <summary>
        /// Adauga informatiile pentru modul de adresare si registru
        /// </summary>
        /// <param name="noSpace"></param>
        /// <param name="MAX"></param>
        /// <param name="RX"></param>
        /// <returns></returns>
        public static string RegisterEncode(string noSpace, out string MAX, out string RX)
        {
            string xOperand = "";
            if (noSpace.Contains(Types.indirectSeparator))
            {
                string[] source_search = noSpace.Split(new[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                if (source_search.Length == 1)
                {
                    MAX = Types.Search("MA_INDIRECT");
                    RX = Types.Search(source_search[0]);
                }
                else
                {
                    MAX = Types.Search("MA_INDEXAT");
                    CheckSideOperand(out RX, out xOperand, source_search);
                }
            }
            else
            {
                if (noSpace.Contains("R"))
                {
                    MAX = Types.Search("MA_DIRECT");
                    RX = Types.Search(noSpace);
                }
                else
                {
                    MAX = Types.Search("MA_IMEDIAT");
                    RX = Types.Search("R0");
                    xOperand = ConvertNumbersToString(noSpace);
                }
            }
            return xOperand;
        }

        /// <summary>
        /// Verifica unde se afla registrul si offset-ul. Exemplu: (R1)123 sau 123(R1)
        /// </summary>
        /// <param name="RX"></param>
        /// <param name="XOp"></param>
        /// <param name="X_search"></param>
        public static void CheckSideOperand(out string RX, out string XOp, string[] X_search)
        {
            if (X_search[1].Contains("R"))
            {
                RX = Types.Search(X_search[1]);
                XOp = ConvertNumbersToString(X_search[0]);
            }
            else
            {
                RX = Types.Search(X_search[0]);
                XOp = ConvertNumbersToString(X_search[1]);
            }
        }

        /// <summary>
        /// Returneaza un string ce contine 16 biti pentru tipurile de instructiuni
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="MAS"></param>
        /// <param name="RS"></param>
        /// <param name="MAD"></param>
        /// <param name="RD"></param>
        /// <param name="sourceOp"></param>
        /// <param name="destOp"></param>
        /// <returns></returns>
        public static string ReturnBinaryLine(string opcode, string MAS, string RS, string MAD, string RD, string sourceOp, string destOp)
        {
            string space = "";
            string rez = opcode + space + MAS + space + RS + space + MAD + space + RD;
            if (sourceOp != "")
            {
                rez += Environment.NewLine + sourceOp;
            }
            if (destOp != "")
            {
                rez += Environment.NewLine + destOp;
            }
            return rez;
        }

        /// <summary>
        /// Converteste numerele din rich textbox intr-un string ce contine 16 biti. Valorile hexazecimale incep cu prefixul 0x. Valorile binare incep cu prefixul 0b
        /// </summary>
        /// <param name="source_search"></param>
        /// <returns></returns>
        public static string ConvertNumbersToString(string source_search)
        {
            string binaryString;
            switch (source_search)
            {
                case string _ when source_search.StartsWith(Types.hexSeparator):
                    //converteste din hexa in binar pe 16 biti
                    string valHex = source_search.Substring(2);
                    if (valHex.Length > 4)
                    {
                        Trace.WriteLine($"0x{valHex} este mai mare decat domeniul de reprezentare 0x0000 : 0xFFFF");
                        throw new InvalidOperationException("Depasirea domeniului de reprezentare de 16 biti");
                    }
                    binaryString = String.Join(String.Empty, valHex.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'))).PadLeft(16, '0');
                    break;

                case string _ when source_search.StartsWith(Types.binarySeparator):
                    //converteste din binar in binar pe 16 biti
                    string valBin = source_search.Substring(2);
                    foreach (var item in valBin)
                    {
                        if (item < '0' || item > '1')
                        {
                            Trace.WriteLine($"0b{valBin} contine {item} care nu reprezinta un bit");
                            throw new InvalidOperationException("Numarul introdus nu este un sir binar");
                        }
                    }
                    if (valBin.Length > 16)
                    {
                        Trace.WriteLine($"0b{valBin} este mai mare decat domeniul de reprezentare 0b0000 0000 0000 0000 : 0b1111 1111 1111 1111");
                        throw new InvalidOperationException("Depasirea domeniului de reprezentare de 16 biti");
                    }
                    binaryString = valBin.PadLeft(16, '0');
                    break;

                default:
                    //converteste din zecimal in binar pe 16 biti  
                    int.TryParse(source_search, out int val);
                    if (val > 65535)
                    {
                        Trace.WriteLine($"{val} este mai mare decat domeniul de reprezentare 0 : 65535");
                        throw new InvalidOperationException("Depasirea domeniului de reprezentare de 16 biti");
                    }
                    binaryString = Convert.ToString(val, 2).PadLeft(16, '0');
                    break;
            }
            if (binaryString.Length > 16)
            {
                string temp = binaryString;
                binaryString = binaryString.Substring(16);
                Trace.WriteLine($"{temp} devine {binaryString}");
            }
            return binaryString;
        }
    }
}
