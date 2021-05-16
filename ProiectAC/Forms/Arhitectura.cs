using System;
using System.Windows.Forms;

namespace proiectAC.Forms
{
    public partial class Arhitectura : Form {

        // Signals
        public bool PmSBUS, PdSBUS;
        public bool PmDBUS, PdDBUS;
        public bool PmRBUS, PdRBUS;
        public bool PdALU;

        public bool PmR, PdR;
        public bool PmSP, PdSP;
        public bool PmT, PdT;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Arhitectura_Load(object sender, EventArgs e)
        {

        }

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
