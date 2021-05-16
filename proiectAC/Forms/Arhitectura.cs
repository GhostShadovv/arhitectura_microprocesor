using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiectAC.Forms {
    public partial class Arhitectura : Form {

        // Signals
        public static bool CLK = false;

        public enum fazaCurenta { IF, OF, EX, INT };

        public static bool PmSBUS, PdSBUS;
        public static bool PmDBUS, PdDBUS;
        public static bool PmRBUS, PdRBUS;
        public static bool PdALU;

        public static bool PmR, PdR;
        public static bool PmSP, PdSP;
        public static bool PmT, PdT;
        public static bool PmPC, PdPC;
        public static bool PmIVR, PdIVR;
        public static bool PmADR, PdADR;
        public static bool PmMDR, PdMDR;
        public static bool PmIR;

        public static bool TIF, TOF, TEX, TINT;


        public Arhitectura() {
            InitializeComponent();
            tCLK.Tick += new EventHandler(tCLK_Tick);
        }

        // Timer
        public void tCLK_Tick(object sender, EventArgs e) {
            CLK = !CLK;

            //
        }
    }
}
