using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace proiectAC.Forms
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
        }

        //pentru a sincroniza cele 2 textbox-uri
        [DllImport("User32.dll")]
        public extern static int GetScrollPos(IntPtr hWnd, int nBar);       
        
        [DllImport("User32.dll")]
        public extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        private enum ScrollBarType : uint
        {
            SbHorz = 0,
            SbVert = 1,
            SbCtl = 2,
            SbBoth = 3
        }
        private enum Message : uint
        {
            WM_VSCROLL = 0x0115, //actiunea de scroll
            SB_BOTTOM = 7 //scroll pana jos
    }
        private enum ScrollBarCommands : uint
        {
            SB_THUMBPOSITION = 4
        }
        private int LastLineIndex;

        private void ParcurgeLinii(List<string> linii, ref int linieCurenta, ref int ct)
        {
            foreach (var linie in linii)    //verific liniile la fiecarea actiune
            {
                Size textSize = TextRenderer.MeasureText(linie, richTextBox1.Font);
                float rtbWidth = richTextBox1.Width;
                int adaos = 0;
                int LinieAdaos = 0;
                if (textSize.Width - 10 > rtbWidth && rtbWidth != 0) //daca am depasit o linie si n-am apasat enter
                {
                    LinieAdaos = richTextBox1.Lines.Count();  //linia respectiva
                    int nrCaractere = richTextBox1.Lines[ct].Length;    //Cate caractere avem
                    float caracterWidth = textSize.Width / (float)nrCaractere;   //Ce lungime are un caracter
                    adaos = (int)caracterWidth * nrCaractere / (int)rtbWidth;   //cate randuri sunt scrise
                }
                if (adaos == 0)
                {
                    LineNumberTextBox.Text += " " + linieCurenta++ + "\n";
                }
                else
                {
                    LineNumberTextBox.Text += " " + linieCurenta++ + "\n";
                    for (int i = 0; i < adaos; i++)
                    {
                        LineNumberTextBox.Text += "\n";
                    }
                }
                ct++;
            }
            int nPos = GetScrollPos(richTextBox1.Handle, (int)ScrollBarType.SbVert);
            nPos <<= 16;
            uint wParam = (uint)ScrollBarCommands.SB_THUMBPOSITION | (uint)nPos;
            SendMessage(LineNumberTextBox.Handle, (int)Message.WM_VSCROLL, new IntPtr(wParam), new IntPtr(0));
            
        }
        public RichTextBox GetRichTextBox()
        {
            return richTextBox1;
        }

        /*  Setari pentru functionarea 'normala' a richTextBox-ului
         */
        private void RichTextBox1_FontChanged(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBox1.Font;
            richTextBox1.Select();
            AddLineNumbers();
        }
        private void RichTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            int CurrentLineIndex = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) + 1;
            if (e.KeyData == Keys.Back)
            {
                if (CurrentLineIndex == LastLineIndex)
                {
                    SendMessage(LineNumberTextBox.Handle, (int)Message.WM_VSCROLL, new IntPtr((int)Message.SB_BOTTOM), new IntPtr(0));
                    richTextBox1.ScrollToCaret();
                }
                SubLineNumbers();
            }
            if (e.KeyData == Keys.Enter)
            {
                if (CurrentLineIndex == LastLineIndex)
                {
                    SendMessage(LineNumberTextBox.Handle, (int)Message.WM_VSCROLL, new IntPtr((int)Message.SB_BOTTOM), new IntPtr(0));
                    richTextBox1.Focus();
                    richTextBox1.ScrollToCaret();
                }
                AddLineNumbers();
            }
        }
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                AddLineNumbers();
            }
        }
        private void LineNumberTextBox_MouseDown(object sender, MouseEventArgs e)
        {            
            richTextBox1.Select();
            LineNumberTextBox.DeselectAll();
        }
        public void HighlightLine(int index)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = richTextBox1.BackColor;
            var lines = richTextBox1.Lines;
            if (index < 0 || index >= lines.Length)
            {
                return;
            }
            if (lines[index] == "")
            {
                index++;
            }
            var start = richTextBox1.GetFirstCharIndexFromLine(index);  // Get the 1st char index of the appended text
            var length = lines[index].Length;
            richTextBox1.Select(start, length);                 // Select from there to the end
            richTextBox1.SelectionBackColor = Color.Green;
        }
        public void SaveFile(string path)
        {
            richTextBox1.SaveFile(path, RichTextBoxStreamType.PlainText);
        }
        public void LoadFile(string path)
        {
            richTextBox1.LoadFile(path, RichTextBoxStreamType.PlainText);
        }
        public void AddLineNumbers()
        {
            LineNumberTextBox.Clear();
            var linii = this.richTextBox1.Text.Split('\n').ToList();
            LastLineIndex = richTextBox1.Lines.Count() + 1;
            panel1.Width = 70;
            int linieCurenta = 1;
            int ct = 0;
            ParcurgeLinii(linii, ref linieCurenta, ref ct);

            LineNumberTextBox.Text += " " + linieCurenta++ + "\n";

        }
        public void SubLineNumbers()
        {
            LineNumberTextBox.ScrollToCaret();
            LineNumberTextBox.Clear();
            var linii = this.richTextBox1.Text.Split('\n').ToList();
            LastLineIndex = richTextBox1.Lines.Count() - 1;
            if (LastLineIndex > 0)
            {
                int linieCurenta = 1;
                int ct = 0;
                ParcurgeLinii(linii, ref linieCurenta, ref ct);
            }
        }
        public void AddWidthLineNumberRTB()
        {
            LineNumberTextBox.Width += 20;
        }
        public void SubWidthLineNumberRTB()
        {
            LineNumberTextBox.Width -= 20;
        }
        private void Editor_Resize(object sender, EventArgs e)
        {
            int CurrentLineIndex = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) + 1;
            if (CurrentLineIndex == LastLineIndex)
            {
                SendMessage(LineNumberTextBox.Handle, (int)Message.WM_VSCROLL, new IntPtr((int)Message.SB_BOTTOM), new IntPtr(0));
                SendMessage(richTextBox1.Handle, (int)Message.WM_VSCROLL, new IntPtr((int)Message.SB_BOTTOM), new IntPtr(0));
            }
            // AddLineNumbers();
        }
        private void Editor_Load(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBox1.Font;
            richTextBox1.Select();
            richTextBox1.Font = new Font(FontFamily.GenericMonospace, richTextBox1.Font.Size);
            AddLineNumbers();
        }
        private void RichTextBox1_VScroll(object sender, EventArgs e)
        {
            int nPos = GetScrollPos(richTextBox1.Handle, (int)ScrollBarType.SbVert);
            nPos <<= 16;
            uint wParam = (uint)ScrollBarCommands.SB_THUMBPOSITION | (uint)nPos;
            SendMessage(LineNumberTextBox.Handle, (int)Message.WM_VSCROLL, new IntPtr(wParam), new IntPtr(0));
        }
        private void RichTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            String s = e.KeyChar.ToString();
            int sel = richTextBox1.SelectionStart;
            switch (s)
            {
                case "(":
                    richTextBox1.Text = richTextBox1.Text.Insert(sel, "()");
                    e.Handled = true;
                    richTextBox1.SelectionStart = sel + 1;
                    break;
                case ")":
                    richTextBox1.Text = richTextBox1.Text.Insert(sel, ")");
                    e.Handled = true;
                    if (sel != richTextBox1.Text.Length-1)
                    {
                        richTextBox1.Text = richTextBox1.Text.Remove(sel + 1, 1);
                    }
                    richTextBox1.SelectionStart = sel+1;
                    break;                
            }
        }
    }
}
