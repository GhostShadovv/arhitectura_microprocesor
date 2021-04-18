using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customButton
{
    public partial class Form1 : Form
    {
        private Form activeForm;
        private Forms.Editor f = new Forms.Editor();
        private string savedFile = "";
        private string initialSaveDirectory = "C:";
        private string initialOpenDirectory = "C:";
        private int i = 0;
        private bool hexDisplay = false;

        public Form1()
        {
            InitializeComponent();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            pEditor.Controls.Add(f);
            pEditor.Tag = f;
            f.BringToFront();
            f.Show();
        
        }
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pContent.Controls.Add(childForm);
            this.pContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.RoyalBlue;
            // new Forms.Editor();
            OpenChildForm(new Forms.Memorie());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.RoyalBlue;
            OpenChildForm(new Forms.Memorie());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.RoyalBlue;
        }

        private void button2_Leave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Blue;
        }

        private void button3_Leave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Blue;
        }

        private void button4_Leave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Blue;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = initialSaveDirectory;
            saveFileDialog1.Title = "Create new file";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Assembly |*.asm";
            if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                savedFile = saveFileDialog1.FileName;
                initialSaveDirectory = saveFileDialog1.FileName;
                f.TopLevel = false;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                pEditor.Controls.Add(f);
                pEditor.Tag = f;
                f.BringToFront();
                f.Show();
                f.saveFile(savedFile);

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Chosen_File = "";
            openFileDialog1.InitialDirectory = initialOpenDirectory;
            openFileDialog1.Title = "Open a file";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Assembly |*.asm";
            if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                Chosen_File = openFileDialog1.FileName;
                initialOpenDirectory = Chosen_File;
                f.loadFile(Chosen_File);
                f.AddLineNumbers();
        }
            }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (savedFile != "")
            {
                f.saveFile(savedFile);
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = initialSaveDirectory;
            saveFileDialog1.Title = "Create new file";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Assembly |*.asm";
            if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                savedFile = saveFileDialog1.FileName;
                initialSaveDirectory = saveFileDialog1.FileName;
                f.saveFile(savedFile);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            f.HighlightLine(i++); 
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tbExemplu.Clear();
            var aux = f.ParseLines();
            if (aux != null)
            {
                System.IO.File.WriteAllText(@"temp.bin", string.Empty);
                using (var s = File.OpenWrite("temp.bin"))
                {
                    foreach (var item in aux)
                    {
                        if (hexDisplay)
                        {
                            var longitems = item.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var longitem in longitems)
                            {
                                string hexVal = Convert.ToInt32(longitem, 2).ToString("X").PadLeft(4, '0');
                                tbExemplu.AppendText(hexVal + Environment.NewLine);
                                var bw = new BinaryWriter(s);
                                bw.Write(Convert.ToInt16(hexVal, 16));
                            }
                        }
                        else
                        {
                            tbExemplu.AppendText(item + Environment.NewLine);
                        }
                    }
                }
            }                        
        }

        private void button9_Click(object sender, EventArgs e)
        {
            hexDisplay = !hexDisplay;
            if (!hexDisplay)
            {
                button9.BackColor = Color.Blue;
            }else
            {
                button9.BackColor = Color.RoyalBlue;
            }
        }

    }
}
