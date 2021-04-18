using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customButton
{
    public class Flags
    {
        private bool Z = false;
        private bool S = false;
        private bool C = false;
        private bool V = false;

        public void setFlagZ()
        {
            Z = true;
        }
        public void resetFlagZ()
        {
            Z = false;
        }
        public bool getFlagZ()
        {
            return Z;
        }
        public void setFlagS()
        {
            S = true;
        }
        public void resetFlagS()
        {
            S = false;
        }
        public bool getFlagS()
        {
            return S;
        }
        public void setFlagC()
        {
            C = true;
        }
        public void resetFlagC()
        {
            C = false;
        }
        public bool getFlagC()
        {
            return C;
        }
        public void setFlagV()
        {
            V = true;
        }
        public void resetFlagV()
        {
            V = false;
        }
        public bool getFlagV()
        {
            return V;
        }
             
    }
}
