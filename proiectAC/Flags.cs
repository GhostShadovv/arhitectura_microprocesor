using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectAC {
    public static class Flags
    {
        private static bool Z = false;
        private static bool N = false;
        private static bool C = false;
        private static bool V = false;

        public static void setFlagZ()
        {
            Z = true;
        }
        public static void resetFlagZ()
        {
            Z = false;
        }
        public static bool getFlagZ()
        {
            return Z;
        }
        public static void setFlagN()
        {
            N = true;
        }
        public static void resetFlagN()
        {
            N = false;
        }
        public static bool getFlagN()
        {
            return N;
        }
        public static void setFlagC()
        {
            C = true;
        }
        public static void resetFlagC()
        {
            C = false;
        }
        public static bool getFlagC()
        {
            return C;
        }
        public static void setFlagV()
        {
            V = true;
        }
        public static void resetFlagV()
        {
            V = false;
        }
        public static bool getFlagV()
        {
            return V;
        }
             
    }
}
