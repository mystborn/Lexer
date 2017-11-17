﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myst.LexicalAnalysis
{
    public class UnrecognizedTokenException : Exception
    {
        /// <summary>
        /// The position in the document/stream where the error occurred.
        /// </summary>
        public TokenPosition Position { get; }

        /// <summary>
        /// The symbol that wasn't recognized.
        /// </summary>
        public char Symbol { get; }

        public UnrecognizedTokenException(char symbol, TokenPosition position)
        {
            Position = position;
            Symbol = symbol;
        }

        public UnrecognizedTokenException(char symbol, TokenPosition position, string message)
            : base(message)
        {
            Position = position;
            Symbol = symbol;
        }

        public UnrecognizedTokenException(char symbol, TokenPosition position, string message, Exception innerException)
            : base(message, innerException)
        {
            Position = position;
            Symbol = symbol;
        }
    }
}
