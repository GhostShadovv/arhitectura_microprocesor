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
        public bool PmSBUS, PdSBUS;
        public bool PmDBUS, PdDBUS;
        public bool PmRBUS, PdRBUS;
        public bool PdALU;

        public bool PmR, PdR;
        public bool PmSP, PdSP;
        public bool PmT, PdT;
        public bool PmPC, PdPC;
        public bool PmIVR, PdIVR;
        public bool PmADR, PdADR;
        public bool PmMDR, PdMDR;
        public bool PmIR;


        public Arhitectura() {
            InitializeComponent();
        }
    }
}
