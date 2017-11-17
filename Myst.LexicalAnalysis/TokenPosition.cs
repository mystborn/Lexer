using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myst.LexicalAnalysis
{
    /// <summary>
    /// Represents a position within a document/stream where a <see cref="Token"/> was found.
    /// </summary>
    public class TokenPosition
    {
        /// <summary>
        /// The position on the line where the <see cref="Token"/> was found.
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// The index in the document/stream where the <see cref="Token"/> was found.
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// The line number where the <see cref="Token"/> was found.
        /// </summary>
        public int Line { get; }

        internal TokenPosition(int index, int line, int column)
        {
            Index = index;
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return $"TokenPosition: Line: {Line} | Column: {Column} | Index: {Index}";
        }
    }
}
