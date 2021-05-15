using proiectAC.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectAC
{
    class TwoOperandInstruction
    {
        public string TwoOperands(string[] noSpace)
        {
            /* noSpace[0] noSpace[1], noSpace[2]
             *   opcode,        dest,       src
            */
            string opcode = Types.Search(noSpace[0]);
            if (int.TryParse(noSpace[1], out _) && noSpace[0].Contains("MOV"))
            {
                Trace.WriteLine($"{noSpace[1]} nu poate fi folosit ca destinatie pentru instructiunea {noSpace[0]}");
                throw new InvalidOperationException("Cod ilegal destinatia nu poate fi valoare imediata");
            }

            // Rezolvare sursa
            string sourceOp = Types.RegisterEncode(noSpace[2], out string MAS, out string RS);
            // Rezolvare destinatie
            string destOp = Types.RegisterEncode(noSpace[1], out string MAD, out string RD);
            if (noSpace[2].Contains("@"))
            {
                //directiva, trebuie trimisa adresa de memorie a directivei
            }
            return Types.ReturnBinaryLine(opcode, MAS, RS, MAD, RD, sourceOp, destOp);
        }

    }
}
