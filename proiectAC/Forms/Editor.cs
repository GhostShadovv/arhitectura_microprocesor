using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace customButton.Forms
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
        int LastLineIndex;

        public static Flags flags = new Flags();
        public static Dictionary<string, int> labels = new Dictionary<string,int>();

        public static int PC = -1;
        public static int Offset_PC = 0;
        public static int lineNumberDebug = 0;
        public static List<string> waitingLabel = new List<string>();
        private void ParcurgeLinii(List<string> linii, ref int linieCurenta, ref int ct, ref int LastLineIndex)
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

        internal string[] ParseLines()
        {
            PC = -1;
            Offset_PC = 0;
            lineNumberDebug = 0;
            labels.Clear();
            try
            {
                var noCommentLines = richTextBox1.Text.ToUpper().Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.None);
                //pun intr-un string separat de newline, tot ce e in rtb mai putin comentariile (tot ce e dupa ; )

                bool model = false;
                bool stack = false;
                bool data = false;
                bool code = false;
                for (int i = 0; i < noCommentLines.Length; i++)
                {
                    if (code || noCommentLines[i].IndexOf(".CODE") >= 0)
                    {
                        code = true;
                        string[] noSpace = noCommentLines[i].Split(new[] { " ", ",", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                        //cazul in care am eticheta
                        lineNumberDebug++;
                        if (noSpace.Length > 0)
                        {
                            PC++;
                            if (noSpace[0].Substring(noSpace[0].Length - 1).Contains(":"))
                            {
                                labels[noSpace[0].Substring(0, noSpace[0].Length - 1)] = PC;
                                Trace.WriteLine($"Adaugat eticheta {labels.Keys.ElementAt(labels.Count - 1)} ce indica spre instructiunea {PC}, " +
                                    $"linia {(noSpace.Length > 1 ? lineNumberDebug : lineNumberDebug + 1)}: {(noSpace.Length > 1 ? noCommentLines[i] : noCommentLines[i + 1])}");
                                noSpace = noSpace.Skip(1).ToArray();
                            }
                        }
                    }
                }
                PC = -1;
                Offset_PC = 0;
                lineNumberDebug = 0;
                code = false;

                string[] code_lines = new string[200];
                for (int i = 0, j = 0; i < noCommentLines.Length; i++)
                {
                    if (!model && noCommentLines[i].IndexOf(".MODEL") >= 0)
                    {
                        model = true;
                    }
                    if (!stack && noCommentLines[i].IndexOf(".STACK") >= 0)
                    {
                        stack = true;
                        model = false;
                    }
                    if (!data && noCommentLines[i].IndexOf(".DATA") >= 0)
                    {
                        data = true;
                        stack = false;
                    }
                    if (!code && noCommentLines[i].IndexOf(".CODE") >= 0)
                    {
                        code = true;
                        data = false;
                    }
                    if (model)
                    {
                        int a = 10;
                    }
                    if (stack)
                    {
                        int a = 10;
                    }
                    if (data)
                    {
                        int a = 10;
                    }
                    if (code)
                    {
                        string[] noSpace = noCommentLines[i].Split(new[] { " ", ",", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                        lineNumberDebug++;

                        //daca am eticheta pe o linie, si instructiunea pe urmatoarea
                        if (noSpace.Length>0 && noSpace[0].Contains(":"))
                        {
                            noSpace = noSpace.Skip(1).ToArray();
                            i = noCommentLines[i + 1] == "" ? throw new InvalidExpressionException($"Nu poate fi linie goala dupa eticheta") : i;
                        }

                        if (noSpace.Length > 0)
                        {
                            PC++;
                            string opcode ="";
                            opcode = Types.Search(noSpace[0]);

                            //cazul in care am instructiune cu 2 operanzi
                            if (opcode.Substring(0, 1).Contains(Types.twoOperand))
                            {
                                code_lines[j++] = TwoOperands(noSpace);
                            }

                            //cazul in care am instructiune cu un operand
                            if (opcode.Substring(0, 2).Contains(Types.opeOperand))
                            {
                                //in cazul in care am push flags, pop flags, push pc, pop pc, sa mearga mai departe
                                if (!(noSpace[1].Equals("FLAGS") || noSpace[1].Equals("PC")))
                                {
                                    code_lines[j++] = OneOperand(noSpace);
                                }
                                else
                                {
                                    if (noSpace[1].Equals("FLAG"))
                                    {
                                        Trace.WriteLine($"Corectat opcode: {opcode}, instructiunea {noSpace[1]} in opcode: {Types.Search("PUSH FLAG")}, instructiunea PUSH FLAG la linia {lineNumberDebug}");
                                        opcode = Types.Search("PUSH FLAG");
                                    }
                                    else
                                    {
                                        if (noSpace[1].Equals("PC"))
                                        {
                                            Trace.WriteLine($"Corectat opcode: {opcode}, instructiunea {noSpace[1]} in opcode: {Types.Search("PUSH PC")}, instructiunea PUSH PC la linia {lineNumberDebug}");
                                            opcode = Types.Search("PUSH PC");
                                        }
                                        else
                                        {
                                            throw new InvalidExpressionException("Greseala");
                                        }
                                    }
                                }
                            }

                            //cazul in care am inscructiune de salt
                            if (opcode.Substring(0, 3).Contains(Types.jumpOperand))
                            {
                                code_lines[j++] = JumpInstr(noSpace);
                            }

                            //cazul in care am instructiuni diverse
                            if (opcode.Substring(0, 3).Contains(Types.diversOperand))
                            {
                                code_lines[j++] = opcode;
                            }
                        }
                    }
                }
                code_lines = code_lines.Where(c => c != null).ToArray();
                return code_lines;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Linia {lineNumberDebug}: {ex.Message}");
                return null;
            }
        }

        private static string JumpInstr(string[] noSpace)
        {
            string opcode = Types.Search(noSpace[0]);
            return checkLabelOffset(noSpace[1], opcode, 127);
        }

        private static string OneOperand(string[] noSpace)
        {
            string opcode = Types.Search(noSpace[0]);
            string MAD = "";
            string RD = "";
            string destOp = "";
            if (noSpace[0].Equals(Types.jmpInstr) || noSpace[0].Equals(Types.callInstr))
            {
                return checkLabelOffset(noSpace[1], opcode, 31);
            }
            else
            {
                destOp = registerEncode(noSpace[1], out MAD, out RD);
            }
            return returnBinaryLine(opcode, "", "", MAD, RD, destOp, "");
        }

        private static string checkLabelOffset(string noSpace, string opcode, int limit)
        {
            var label_aux = labels.FirstOrDefault(t => t.Key == noSpace);
            if (label_aux.Key != null)
            {
                Offset_PC = label_aux.Value - PC;
                if (Offset_PC > -(limit+1) && Offset_PC < limit)
                {
                    if (Offset_PC < 0)
                    {
                        return opcode + Convert.ToString((label_aux.Value - PC), 2).Substring(16).Substring(opcode.Length);
                    }
                    else
                    {
                        return opcode + Convert.ToString((label_aux.Value - PC), 2);
                    }
                }
                else
                {
                    Trace.WriteLine($"Eticheta {label_aux.Key} se afla la o distanta mai mare de {limit} pozitii relative de {PC} si anume {Offset_PC}");
                    throw new InvalidExpressionException("Distanta pentru instructiunea JMP este prea mare");
                }
            }
            else
            {
                int value;
                if (noSpace.Contains("X"))
                {
                    noSpace = noSpace.Substring(2);
                    value = Convert.ToInt32(noSpace, 16);
                }
                else
                {
                    if (noSpace.Contains("0B"))
                    {
                        noSpace = noSpace.Substring(2);
                        value = Convert.ToInt32(noSpace, 2);
                    }
                    else
                    {
                        int.TryParse(noSpace, out value);
                    }
                }
                if (value != 0)
                {
                    if (value > -32 || value < 31)
                    {
                        return opcode + ConvertNumbersToString(noSpace).Substring(opcode.Length);//operand 7 biti
                    }
                    else
                    {
                        Trace.WriteLine($"Offset-ul {value} depaseste domeniul de reprezentare (-32,31)");
                        throw new InvalidExpressionException($"Salt la o valoare mai mare de 32 instructiuni");
                    }
                }
                else
                {
                    Trace.WriteLine($"Eticheta {noSpace} nu exista");
                    throw new InvalidExpressionException($"Nu exista eticheta {noSpace}");
                }
            }
        }

        private static string TwoOperands(string[] noSpace)
        {
            /* noSpace[0] noSpace[1], noSpace[2]
             *       mov        dest,       src
            */
            string opcode = Types.Search(noSpace[0]);
            string MAS = "";
            string RS = "";
            string MAD = "";
            string RD = "";
            string sourceOp = "";
            string destOp = "";
            int ilegal;
            if (int.TryParse(noSpace[1], out ilegal) && noSpace[0].Contains("MOV"))
            {
                Trace.WriteLine($"{noSpace[1]} nu poate fi folosit ca destinatie pentru instructiunea {noSpace[0]}");
                throw new InvalidOperationException("Cod ilegal destinatia nu poate fi valoare imediata");
            }
            // Rezolvare sursa
            sourceOp = registerEncode(noSpace[2], out MAS, out RS);
            // Rezolvare destinatie
            destOp = registerEncode(noSpace[1], out MAD, out RD);
            if (noSpace[2].Contains("@"))
            {
                //directiva
            }
            return returnBinaryLine(opcode, MAS, RS, MAD, RD, sourceOp, destOp);
        }

        private static string registerEncode(string noSpace, out string MAX, out string RX)
        {
            string xOperand = "";
            if (noSpace.Contains(Types.indirectSeparator))
            {
                string[] source_search = noSpace.Split(new[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                if (source_search.Length == 1)
                {
                    MAX = Types.Search("MA_INDIRECT");
                    RX = Types.Search(source_search[0]);
                }
                else
                {
                    MAX = Types.Search("MA_INDEXAT");
                    checkSideOperand(out RX, out xOperand, source_search);
                }
            }
            else
            {
                if (noSpace.Contains("R"))
                {
                    MAX = Types.Search("MA_DIRECT");
                    RX = Types.Search(noSpace);
                }
                else
                {
                    MAX = Types.Search("MA_IMEDIAT");
                    RX = Types.Search("R0");
                    xOperand = ConvertNumbersToString(noSpace);
                }
            }
            return xOperand;
        }

        /*  Verifica unde se afla registrul si offset-ul
         *  Exemplu: (R1)123 sau 123(R1)
        */
        private static void checkSideOperand(out string RX, out string XOp, string[] X_search)
        {
            if (X_search[1].Contains("R"))
            {
                RX = Types.Search(X_search[1]);
                XOp = ConvertNumbersToString(X_search[0]);
            }
            else
            {
                RX = Types.Search(X_search[0]);
                XOp = ConvertNumbersToString(X_search[1]);
            }
        }
        
        /* Returneaza un string ce contine 16 biti pentru tipurile de instructiuni 
        */
        private static string returnBinaryLine(string opcode, string MAS, string RS, string MAD, string RD, string sourceOp, string destOp)
        {
            string space = "";
            string rez = opcode + space + MAS + space + RS + space + MAD + space + RD;
            if (sourceOp != "")
            {
                rez += Environment.NewLine + sourceOp;
            }
            if (destOp != "")
            {
                rez += Environment.NewLine + destOp;
            }
            return rez;
        }

       /*   Converteste numerele din rich textbox intr-un string ce contine 16 biti
        *   Valorile hexazecimale incep cu prefixul 0x
        *   Valorile binare incep cu prefixul 0b
       */
        private static string ConvertNumbersToString(string source_search)
        {
            string binaryString;
            //converteste din hexa in binar pe 16 biti
            if (source_search.Contains(Types.hexSeparator))
            {
                string valHex = source_search.Substring(2);
                if (valHex.Length > 4)
                {
                    Trace.WriteLine($"0x{valHex} este mai mare decat domeniul de reprezentare 0x0000 : 0xFFFF");
                    throw new InvalidOperationException("Depasirea domeniului de reprezentare de 16 biti");
                }
                binaryString = String.Join(String.Empty, valHex.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'))).PadLeft(16, '0');
            }
            else
            {
                //converteste din binar in binar pe 16 biti
                if (source_search.Contains(Types.binarySeparator))
                {
                    string valBin = source_search.Substring(2);
                    foreach (var item in valBin)
                    {
                        if(item < '0' || item > '1')
                        {
                            Trace.WriteLine($"0b{valBin} contine {item} care nu reprezinta un bit");
                            throw new InvalidOperationException("Numarul introdus nu este un sir binar");
                        }
                    }
                    if (valBin.Length > 16)
                    {
                        Trace.WriteLine($"0b{valBin} este mai mare decat domeniul de reprezentare 0b0000 0000 0000 0000 : 0b1111 1111 1111 1111");
                        throw new InvalidOperationException("Depasirea domeniului de reprezentare de 16 biti");
                    }
                    binaryString = valBin.PadLeft(16, '0');
                }
                else
                {
                    //converteste din zecimal in binar pe 16 biti  
                    int val = 0;
                    int.TryParse(source_search, out val);
                    if (val > 65535)
                    {
                        Trace.WriteLine($"{val} este mai mare decat domeniul de reprezentare 0 : 65535");
                        throw new InvalidOperationException("Depasirea domeniului de reprezentare de 16 biti");
                    }
                    binaryString = Convert.ToString(val, 2).PadLeft(16, '0');
                }
            }
            if (binaryString.Length > 16)
            {
                string temp = binaryString;
                binaryString = binaryString.Substring(16);
                Trace.WriteLine($"{temp} devine {binaryString}");
            }
            return binaryString;
        }

        /*  Setari pentru functionarea 'normala' a richTextBox-ului
         */
        private void richTextBox1_FontChanged(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBox1.Font;
            richTextBox1.Select();
            AddLineNumbers();
        }
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
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
        private void richTextBox1_TextChanged(object sender, EventArgs e)
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

        public void saveFile(string path)
        {
            richTextBox1.SaveFile(path, RichTextBoxStreamType.PlainText);
        }
        public void loadFile(string path)
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
            ParcurgeLinii(linii, ref linieCurenta, ref ct, ref LastLineIndex);

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
                ParcurgeLinii(linii, ref linieCurenta, ref ct, ref LastLineIndex);
            }
        }
        public void addWidthLineNumberRTB()
        {
            LineNumberTextBox.Width += 20;
        }
        public void subWidthLineNumberRTB()
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
        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            int nPos = GetScrollPos(richTextBox1.Handle, (int)ScrollBarType.SbVert);
            nPos <<= 16;
            uint wParam = (uint)ScrollBarCommands.SB_THUMBPOSITION | (uint)nPos;
            SendMessage(LineNumberTextBox.Handle, (int)Message.WM_VSCROLL, new IntPtr(wParam), new IntPtr(0));
        }
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
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
