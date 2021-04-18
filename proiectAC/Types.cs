using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customButton.Forms
{
    public static class Types
    {
        public static string opeOperand = "10";
        public static string twoOperand = "0";
        public static string jumpOperand = "110";
        public static string diversOperand = "111";
        public static string callInstr = "CALL";
        public static string jmpInstr = "JMP";
        public static string indirectSeparator = "(";
        public static string hexSeparator = "0X";
        public static string binarySeparator = "0B";

        public static string MOV = "0000";
        public static string ADD = "0001";
        public static string SUB = "0010";
        public static string CMP = "0011";
        public static string AND = "0100";
        public static string OR  = "0101";
        public static string XOR = "0110";

        public static string CLR = "1000000000";
        public static string NEG = "1000000001";
        public static string INC = "1000000010";
        public static string DEC = "1000000011";
        public static string ASL = "1000000100";
        public static string ASR = "1000000101";
        public static string LSR = "1000000110";
        public static string ROL = "1000000111";
        public static string ROR = "1000001000";
        public static string RLC = "1000001001";
        public static string RRC = "1000001010";
        public static string JMP = "1000001011";
        public static string CALL= "1000001100";
        public static string PUSH= "1000001101";
        public static string POP = "1000001110";

        public static string BR  = "11000000";
        public static string BNE = "11000001";
        public static string BEQ = "11000010";
        public static string BPL = "11000011";
        public static string BMI = "11000100";
        public static string BCS = "11000101";
        public static string BCC = "11000110";
        public static string BVS = "11000111";
        public static string BVC = "11000000";

        public static string CLC = "1110000000000000";
        public static string CLV = "1110000000000001";
        public static string CLZ = "1110000000000010";
        public static string CLS = "1110000000000011";
        public static string CCC = "1110000000000100";
        public static string SEC = "1110000000000101";
        public static string SEV = "1110000000000110";
        public static string SEZ = "1110000000000111";
        public static string SES = "1110000000001000";
        public static string SCC = "1110000000001001";
        public static string NOP = "1110000000001010";
        public static string RET = "1110000000001011";
        public static string RETI= "1110000000001100";
        public static string HALT=      "1110000000001101";
        public static string WAIT=      "1110000000001110";
        public static string PUSH_PC=   "1110000000001111";
        public static string POP_PC =   "1110000000010000";
        public static string PUSH_FLAG= "1110000000010001";
        public static string POP_FLAG = "1110000000010010";

        public static string R0  = "0000";
        public static string R1  = "0001";
        public static string R2  = "0010";
        public static string R3  = "0011";
        public static string R4  = "0100";
        public static string R5  = "0101";
        public static string R6  = "0110";
        public static string R7  = "0111";
        public static string R8  = "1000";
        public static string R9  = "1001";
        public static string R10 = "1010";
        public static string R11 = "1011";
        public static string R12 = "1100";
        public static string R13 = "1101";
        public static string R14 = "1110";
        public static string R15 = "1111";


        public static string MA_IMEDIAT = "00";
        public static string MA_DIRECT = "01";
        public static string MA_INDIRECT = "10";
        public static string MA_INDEXAT = "11";

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
                case "BCC": return BCS;
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
                    break;
            }
            return text;
        }
    }
}
