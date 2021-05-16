using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectAC
{
    public class Registers
    {
        private string[] R = new string[16];
        private string SP;
        private string T;
        private string PC;
        private string IVR;
        private string ADR;
        private string MDR;
        private string IR;

        // R
        public string readR(int index)
        {
            return R[index];
        }
        public void writeR(string value, int index)
        {
            R[index] = value;
        }
        public string notR(int index)
        {
            int R_value_int = Convert.ToInt16(R[index], 2);
            R_value_int = ~R_value_int;
            return Convert.ToString(R_value_int, 2);
        }

        // SP
        public string readSP()
        {
            return SP;
        }
        public void writeSP(string value)
        {
            SP = value;
        }
        public void incSP()
        {
            int SP_int = Convert.ToInt16(SP, 2);
            SP_int = SP_int + 2;
            SP = Convert.ToString(SP_int, 2);
        }
        public void decSP()
        {
            int SP_int = Convert.ToInt16(SP, 2);
            SP_int = SP_int - 2;
            SP = Convert.ToString(SP_int, 2);
        }

        // T
        public string readT()
        {
            return T;
        }
        public void writeT(string value)
        {
            T = value;
        }
        public void resetT()
        {
            T = "";
        }
        public string notT()
        {
            int T_int = Convert.ToInt16(T, 2);
            T_int = ~T_int;
            return Convert.ToString(T_int, 2);
        }

        // PC
        public string readPC()
        {
            return PC;
        }
        public void writePC(string value)
        {
            PC = value;
        }
        public void incPC()
        {
            int PC_int = Convert.ToInt16(PC, 2);
            PC_int = PC_int + 2;
            PC = Convert.ToString(PC_int, 2);
        }

        // IVR
        public string readIVR()
        {
            return IVR;
        }
        public void writeIVR(string value)
        {
            IVR = value;
        }

        // ADR
        public string readADR()
        {
            return ADR;
        }
        public void writeADR(string value)
        {
            ADR = value;
        }

        // MDR
        public string readMDR()
        {
            return MDR;
        }
        public void writeMDR(string value)
        {
            MDR = value;
        }

        // IR
        public string readIR()
        {
            return IR;
        }
        public void writeIR(string value)
        {
            IR = value;
        }
    }
}
