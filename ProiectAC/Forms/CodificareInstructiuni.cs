using System;
using System.Windows.Forms;

namespace proiectAC.Forms
{
    public partial class CodificareInstructiuni : Form
    {
        public CodificareInstructiuni()
        {
            InitializeComponent();
        }

        // Clear Output
        public void clearOutput()
        {
            this.tbExemplu.Clear();
        }

        public void appendTextToOutput(String text)
        {
            this.tbExemplu.AppendText(text);
        }
    }
}
