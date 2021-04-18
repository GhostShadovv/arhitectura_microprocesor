using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customButton.Forms
{
    public partial class Memorie : Form
    {
        public Memorie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (customButton2.Start == true)
            {
                customButton2.Start = false;
            }
            else
            {
                customButton2.Start = true;

            }
        }

        private void customButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
