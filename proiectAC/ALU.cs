using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectAC {
    public class ALU {
        private string SBUS;
        private string DBUS;
        private string RBUS;

        // SUM
        public string SUM(string SBUS, string DBUS, int Cin = 0) {
            int SBUS_int = Convert.ToInt16(SBUS, 2);
            int DBUS_int = Convert.ToInt16(DBUS, 2);
            int RBUS_int = SBUS_int + DBUS_int + Cin;
            RBUS = Convert.ToString(RBUS_int, 2);

            if(RBUS.Length > 16) {
                Flags.setFlagC();
                Flags.setFlagV();

                return RBUS.Substring(1);
            }

            if(RBUS_int < 0) {
                Flags.setFlagN();
            }

            if (RBUS_int == 0) {
                Flags.setFlagZ();
            }

            return RBUS;
        }

        // AND
        public string AND(string SBUS, string DBUS) {
            int SBUS_int = Convert.ToInt16(SBUS, 2);
            int DBUS_int = Convert.ToInt16(DBUS, 2);
            int RBUS_int = SBUS_int & DBUS_int;
            RBUS = Convert.ToString(RBUS_int, 2);

            if (RBUS_int < 0) {
                Flags.setFlagN();
            }

            if (RBUS_int == 0) {
                Flags.setFlagZ();
            }

            return RBUS;
        }

        // OR
        public string OR(string SBUS, string DBUS) {
            int SBUS_int = Convert.ToInt16(SBUS, 2);
            int DBUS_int = Convert.ToInt16(DBUS, 2);
            int RBUS_int = SBUS_int | DBUS_int;
            RBUS = Convert.ToString(RBUS_int, 2);

            if (RBUS_int < 0) {
                Flags.setFlagN();
            }

            if (RBUS_int == 0) {
                Flags.setFlagZ();
            }

            return RBUS;
        }

        // XOR
        public string XOR(string SBUS, string DBUS) {
            int SBUS_int = Convert.ToInt16(SBUS, 2);
            int DBUS_int = Convert.ToInt16(DBUS, 2);
            int RBUS_int = SBUS_int ^ DBUS_int;
            RBUS = Convert.ToString(RBUS_int, 2);

            if (RBUS_int < 0) {
                Flags.setFlagN();
            }

            if (RBUS_int == 0) {
                Flags.setFlagZ();
            }

            return RBUS;
        }

        // Not SBUS
        public string notSBUS(string SBUS) {
            int SBUS_int = Convert.ToInt16(SBUS, 2);
            int RBUS_int = ~SBUS_int;
            RBUS = Convert.ToString(RBUS_int, 2);

            if (RBUS_int < 0) {
                Flags.setFlagN();
            }

            if (RBUS_int == 0) {
                Flags.setFlagZ();
            }

            return RBUS;
        }

        // Return SBUS
        public string retSBUS() {
            return SBUS;
        }

        // Return DBUS
        public string retDBUS() {
            return DBUS;
        }
    }
}
