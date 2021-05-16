using proiectAC;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace proiectAC
{
    public partial class Form1 : Form
    {
        private Form activeForm;
        private readonly Forms.Editor editorForm = new Forms.Editor();
        private Forms.Arhitectura arhitecturaForm = new Forms.Arhitectura();
        private Forms.CodificareInstructiuni codificareInstructiuniForm = new Forms.CodificareInstructiuni();
        private Forms.Memorie memoriaForm = new Forms.Memorie();
        private string savedFile = "";
        private string initialSaveDirectory = "C:";
        private string initialOpenDirectory = "C:";
        private bool hexDisplay = false;

        private ALU ALU = new ALU();

        public Form1()
        {
            InitializeComponent();
            editorForm.TopLevel = false;
            editorForm.FormBorderStyle = FormBorderStyle.None;
            editorForm.Dock = DockStyle.Fill;
            pEditor.Controls.Add(editorForm);
            pEditor.Tag = editorForm;
            editorForm.BringToFront();
            editorForm.Show();
            OpenChildForm(arhitecturaForm);
        }
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Hide();
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

        private void resetTabButtons() {
            btnArhitectura.BackColor = Color.LightGray;
            btnCodificareInstructiuni.BackColor = Color.LightGray;
            btnMemoria.BackColor = Color.LightGray;
        }

        // Btn Arhitectura
        private void btnArhitectura_Click(object sender, EventArgs e)
        {
            resetTabButtons();
            btnArhitectura.BackColor = Color.Silver;
            btnArhitectura.ForeColor = Color.DimGray;
            OpenChildForm(arhitecturaForm);
        }

        private void btnArhitectura_Leave(object sender, EventArgs e)
        {
            btnArhitectura.BackColor = Color.LightGray;
        }

        // Btn Codificare Instr
        private void btnCodificareInstructiuni_Click(object sender, EventArgs e)
        {
            resetTabButtons();
            btnCodificareInstructiuni.BackColor = Color.Silver;
            btnCodificareInstructiuni.ForeColor = Color.DimGray;
            OpenChildForm(codificareInstructiuniForm);
        }
        private void btnCodificareInstructiuni_Leave(object sender, EventArgs e)
        {
            btnCodificareInstructiuni.BackColor = Color.LightGray;
        }

        // Btn Memoria
        private void btnMemoria_Click(object sender, EventArgs e)
        {
            resetTabButtons();
            btnMemoria.BackColor = Color.Silver;
            btnMemoria.ForeColor = Color.DimGray;
            OpenChildForm(memoriaForm);
        }
        private void btnMemoria_Leave(object sender, EventArgs e) {
            btnMemoria.BackColor = Color.LightGray;
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = initialSaveDirectory;
            saveFileDialog1.Title = "Create new file";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Assembly |*.asm";
            if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                savedFile = saveFileDialog1.FileName;
                initialSaveDirectory = saveFileDialog1.FileName;
                editorForm.TopLevel = false;
                editorForm.FormBorderStyle = FormBorderStyle.None;
                editorForm.Dock = DockStyle.Fill;
                pEditor.Controls.Add(editorForm);
                pEditor.Tag = editorForm;
                editorForm.BringToFront();
                editorForm.Show();
                editorForm.SaveFile(savedFile);

            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = initialOpenDirectory;
            openFileDialog1.Title = "Open a file";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Assembly |*.asm";
            if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                string Chosen_File = openFileDialog1.FileName;
                initialOpenDirectory = Chosen_File;
                editorForm.LoadFile(Chosen_File);
                editorForm.AddLineNumbers();
        }
            }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (savedFile != "")
            {
                editorForm.SaveFile(savedFile);
            }
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = initialSaveDirectory;
            saveFileDialog1.Title = "Create new file";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Assembly |*.asm";
            if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                savedFile = saveFileDialog1.FileName;
                initialSaveDirectory = saveFileDialog1.FileName;
                editorForm.SaveFile(savedFile);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void parsareCodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assembler assembler = new Assembler();
            codificareInstructiuniForm.clearOutput();
            var aux = assembler.ParseLines(editorForm.GetRichTextBox());
            if (aux == null) {
                return;
            }
            if (hexDisplay) {
                System.IO.File.WriteAllText(@"temp.bin", string.Empty);
            }
            using (var s = File.OpenWrite("temp.bin")) {
                foreach (var item in aux) {
                    if (hexDisplay) {
                        var longitems = item.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var longitem in longitems) {
                            string hexVal = Convert.ToInt32(longitem, 2).ToString("X").PadLeft(4, '0');
                            codificareInstructiuniForm.appendTextToOutput(hexVal + Environment.NewLine);

                            var bw = new BinaryWriter(s);
                            bw.Write(Convert.ToInt16(hexVal, 16));
                        }
                    } else {
                        codificareInstructiuniForm.appendTextToOutput(item + Environment.NewLine);
                    }
                }
            }
        }

        private void conversieHEXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hexDisplay = !hexDisplay;
        }
    }
}
