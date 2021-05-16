using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace proiectAC
{
    class Assembler
    {
        internal static Dictionary<string, int> labels = new Dictionary<string, int>();
        private static readonly Dictionary<string, int> procedures = new Dictionary<string, int>();

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
                    lineNumberDebug++;
                    noCommentLines[i] = noCommentLines[i].Replace("\t", "");
                    switch (noCommentLines)
                    {
                        case string[] _ when noCommentLines[i].StartsWith(Types.directiveModel):
                            ExecuteModel(noCommentLines, code_lines, ref i, ref j);
                            break;
                        case string[] _ when noCommentLines[i].StartsWith(Types.directiveStack):
                            ExecuteStack(noCommentLines, code_lines, i, ref j);
                            break;
                        case string[] _ when noCommentLines[i].StartsWith(Types.directiveData):
                            ExecuteData(noCommentLines, code_lines, i, j);
                            break;
                        case string[] _ when noCommentLines[i].StartsWith(Types.directiveCode):
                            j = ExecuteCode(noCommentLines, code_lines, i, j);
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

        private void ExecuteModel(string[] noCommentLines, string[] code_lines, ref int i, ref int j)
        {
            string[] noSpace = null;
            noSpace = noCommentLines[i].Split(' ');
            string modelType = Types.Search(noSpace[1]);
            if (modelType != noSpace[1])
            {
                code_lines[j++] += Types.Search(noSpace[0].Substring(1)) + modelType;
            }
            else
            {
                Trace.WriteLine($"{noSpace[1]} nu este un model valid");
                throw new InvalidExpressionException($"{noSpace[1]} nu este un model valid, modelele valide sunt tiny, small si large");
            }
        }

        private void ExecuteStack(string[] noCommentLines, string[] code_lines, int i, ref int j)
        {
            string[] noSpace = noCommentLines[i].Split(' ');
            switch (noSpace.Length)
            {
                case 1:
                    code_lines[j++] += Types.Search(noSpace[0].Substring(1)) + Types.ConvertNumbersToString("255").Substring(8);
                    break;

                case 2:
                    if (int.TryParse(noSpace[1], out int result) && result < 255)
                    {
                        code_lines[j++] += Types.Search(noSpace[0].Substring(1)) + Types.ConvertNumbersToString(noSpace[1]).Substring(8);
                    }
                    else
                    {
                        if (result > 255)
                        {
                            Trace.WriteLine($"{noSpace[1]} depaseste dimensiunea maxima pentru stiva (255)");
                            throw new InvalidExpressionException($"{noSpace[1]} depaseste dimensiunea maxima pentru stiva (255)");
                        }
                        Trace.WriteLine($"{noSpace[1]} nu este un numar valid");
                        throw new InvalidExpressionException($"{noSpace[1]} nu este un numar valid");
                    }
                    break;

                default:
                    Trace.WriteLine($"Instructiunea {code_lines[i]} nu este cunoscuta");
                    throw new InvalidExpressionException($"Instructiunea nu este cunoscuta");
            }
        }

        private void ExecuteData(string[] noCommentLines, string[] code_lines, int i, int j)
        {
            throw new NotImplementedException();
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
            for (; i < noCommentLines.Length; i++)
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
                            code_lines[j++] = one.CorrectOneOperand(noSpace, ref opcode, ref labels, procedures, lineNumberDebug, Offset_PC, PC);
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
            }
            return j;
        }

        /// <summary>
        /// Seteaza etichetele intr-un dictionar
        /// </summary>
        /// <param name="noCommentLines"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private static void SetLabels(string[] noCommentLines)
        {
            lineNumberDebug = 1;
            bool code = false;
            for (int i = 0; i < noCommentLines.Length; i++)
            {
                if (code || noCommentLines[i].StartsWith(".CODE"))
                {
                    code = true;
                    string[] noSpace;
                    noCommentLines[i] = noCommentLines[i].Contains("ENDP") ? "" : noCommentLines[i];
                    if (noCommentLines[i].Contains("PROC"))
                    {
                        noSpace = noCommentLines[i].Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                        noCommentLines[i] = "";
                        procedures[noSpace[0]] = PC;
                        Trace.WriteLine($"Am adaugat procedura {noSpace[0]} ce indica spre instructiunea {PC + 1}: {noCommentLines[i + 1]} la linia {lineNumberDebug}");
                    }

                    noSpace = noCommentLines[i].Split(new[] { " ", ",", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                    //cazul in care am eticheta
                    if (noSpace.Length > 0)
                    {
                        switch (noSpace[0])
                        {
                            case string _ when noSpace[0].EndsWith(":"):
                                labels[noSpace[0].Trim(':')] = PC;
                                Trace.WriteLine($"Adaugat eticheta {labels.Keys.ElementAt(labels.Count - 1)} ce indica spre instructiunea {PC}: {noCommentLines[i]}, " +
                                    $"linia {lineNumberDebug + 1}: {noCommentLines[i + 1]}");
                                noCommentLines[i] = "";
                                break;

                            case string _ when noSpace[0].Contains(":"):
                                noSpace = noCommentLines[i].Split(new[] { ":", " ", ",", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                                labels[noSpace[0]] = PC;
                                Trace.WriteLine($"Adaugat eticheta {labels.Keys.ElementAt(labels.Count - 1)} ce indica spre instructiunea {PC}: {noCommentLines[i]}, " +
                                    $"linia {lineNumberDebug}: {noCommentLines[i]}");
                                noCommentLines[i] = String.Join("", noSpace.Skip(1));
                                break;

                            default:
                                break;
                        }
                        PC++;
                    }
                }
                lineNumberDebug++;
            }
            lineNumberDebug = 0;
        }

    }
}
