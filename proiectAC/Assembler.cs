using customButton.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using  Procedures = System.Tuple<string, int, System.Collections.Generic.List<string>>;
namespace proiectAC
{
    class Assembler
    {
        internal static Dictionary<string, int> labels = new Dictionary<string, int>();
        private static Procedures procedures_details;

        internal static int PC = 0;
        internal static int Offset_PC = 0;
        internal static int lineNumberDebug = 0;

        public string[] ParseLines(RichTextBox richTextBox1)
        {
            PC = 0;
            Offset_PC = 0;
            lineNumberDebug = 0;
            labels.Clear();
            try
            {
                var noCommentLines = richTextBox1.Text.ToUpper().Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.None);
                SetLabels(noCommentLines);
                string[] code_lines = new string[200];

                for (int i = 0, j = 0; i < noCommentLines.Length; i++)
                {
                    switch (noCommentLines)
                    {
                        case string[] _ when noCommentLines[i].StartsWith(".MODEL"):
                            break;
                        case string[] _ when noCommentLines[i].StartsWith(".STACK"):
                            break;
                        case string[] _ when noCommentLines[i].StartsWith(".DATA"):
                            break;
                        case string[] _ when noCommentLines[i].StartsWith(".CODE"):
                            j = ExecuteCode(noCommentLines, code_lines, ++i, j);
                            break;
                        default:
                            break;
                    }
                }
                return code_lines.Where(c => c != null).ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Linia {lineNumberDebug}: {ex.Message}");
                return null;
            }
        }
        /// <summary>
        /// Codifica instructiuniile de dupa directiva .CODE
        /// </summary>
        /// <param name="noCommentLines"></param>
        /// <param name="code_lines"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private static int ExecuteCode(string[] noCommentLines, string[] code_lines, int i, int j)
        {
            for (;i<noCommentLines.Length;i++)
            {
                string[] noSpace = noCommentLines[i].Split(new[] { " ", ",", "\t" }, StringSplitOptions.RemoveEmptyEntries);

                if (noSpace.Length > 0)
                {
                    string opcode = Types.Search(noSpace[0]);
                    switch (opcode)
                    {
                        case string _ when opcode.StartsWith(Types.twoOperand):
                            TwoOperandInstruction two = new TwoOperandInstruction();
                            code_lines[j++] = two.TwoOperands(noSpace);
                            break;
                        case string _ when opcode.StartsWith(Types.oneOperand):
                            OneOperandInstruction one = new OneOperandInstruction();
                            code_lines[j++] = one.CorrectOneOperand(noSpace, ref opcode, ref labels, lineNumberDebug, Offset_PC, PC);
                            break;
                        case string _ when opcode.StartsWith(Types.jumpOperand):
                            JumpOperandInstruction jump = new JumpOperandInstruction();
                            code_lines[j++] = jump.JumpInstr(noSpace, ref labels, Offset_PC, PC);
                            break;
                        case string _ when opcode.StartsWith(Types.diversOperand):
                            code_lines[j++] = opcode;
                            break;
                        default:
                            break;
                    }
                    PC++;
                }
                lineNumberDebug++;
            }            return j;
        }

        /// <summary>
        /// Seteaza etichetele intr-un dictionar
        /// </summary>
        /// <param name="noCommentLines"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private static void SetLabels(string[] noCommentLines)
        {
            bool code = false;
            for (int i = 0; i < noCommentLines.Length; i++)
            {
                if (code || noCommentLines[i].StartsWith(".CODE"))
                {
                    code = true;
                    if (noCommentLines[i].Contains("PROC"))
                    {
                        string[] noSpace = noCommentLines[i++].Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                        List<string> procedures_instructions = new List<string>();
                        noCommentLines[--i] = "";
                        while (!noCommentLines[i].Contains("ENDP"))
                        {
                            procedures_instructions.Add(noCommentLines[i].Replace("\t", String.Empty));
                            noCommentLines[i++] = "";
                        }
                        noCommentLines[i] = "";
                        procedures_details = new Procedures(noSpace[0], PC, procedures_instructions);                        
                    }
                    else
                    {
                        string[] noSpace = noCommentLines[i].Split(new[] { " ", ",", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                        //cazul in care am eticheta
                        if (noSpace.Length > 0)
                        {
                            if (noSpace[0].Substring(noSpace[0].Length - 1).Contains(":"))
                            {
                                labels[noSpace[0].Substring(0, noSpace[0].Length - 1)] = PC;
                                Trace.WriteLine($"Adaugat eticheta {labels.Keys.ElementAt(labels.Count - 1)} ce indica spre instructiunea {PC}, " +
                                    $"linia {(noSpace.Length > 1 ? lineNumberDebug : lineNumberDebug + 1)}: {(noSpace.Length > 1 ? noCommentLines[i] : noCommentLines[i + 1])}");
                                noCommentLines[i] = String.Join("", noSpace.Skip(1));
                                //PC++;
                            }
                            else
                            {
                                if (noSpace[0].Contains(":"))
                                {
                                    noSpace = noCommentLines[i].Split(new[] { ":", " ", ",", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                                    labels[noSpace[0]] = PC;
                                    Trace.WriteLine($"Adaugat eticheta {labels.Keys.ElementAt(labels.Count - 1)} ce indica spre instructiunea {PC}, linia {lineNumberDebug}: {noCommentLines[i]}");
                                    //PC++;
                                }
                            }
                        }
                    }
                    PC++;
                }
                lineNumberDebug++;
            }
            lineNumberDebug = 0;
        }

       

    }
}
