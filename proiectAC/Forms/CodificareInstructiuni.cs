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
    public partial class CodificareInstructiuni : Form {
        public CodificareInstructiuni() {
            InitializeComponent();
        }

        // Clear Output
        public void clearOutput() {
            this.tbExemplu.Clear();
        }

        public void appendTextToOutput(String text) {
            this.tbExemplu.AppendText(text);
        }
    }
}
