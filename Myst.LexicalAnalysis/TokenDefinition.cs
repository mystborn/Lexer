using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Myst.LexicalAnalysis
{
    /// <summary>
    /// Defines a <see cref="Token"/> type.
    /// </summary>
    public class TokenDefinition
    {
        /// <summary>
        /// Determines if this token type is returned when found while tokenizing.
        /// </summary>
        public bool IsIgnored { get; }

        /// <summary>
        /// The regex used to find this token.
        /// </summary>
        public Regex Regex { get; }

        /// <summary>
        /// The type of this token.
        /// </summary>
        /// <remarks>
        /// This value is a string to support extensibility, 
        /// however an enum/constant value would be preferred.
        /// </remarks>
        public string Type { get; }

        /// <summary>
        /// Defines a token using the given pattern and type.
        /// </summary>
        /// <param name="regex">The pattern used to find this token.</param>
        /// <param name="type">The name of the type of this token.</param>
        public TokenDefinition(string regex, string type)
            : this(new Regex(regex), type, false)
        {
        }

        /// <summary>
        /// Defines a token using the given regex and type.
        /// </summary>
        /// <param name="regex">The regex used to find this token.</param>
        /// <param name="type">The name of the type of this token.</param>
        public TokenDefinition(Regex regex, string type)
            : this(regex, type, false)
        {
        }

        /// <summary>
        /// Defines a token using the given pattern and type, and determines whether it should be ignored or not.
        /// </summary>
        /// <param name="regex">The pattern used to find this token.</param>
        /// <param name="type">The name of the type of this token.</param>
        /// <param name="isIgnored"></param>
        public TokenDefinition(string regex, string type, bool isIgnored)
            : this(new Regex(regex), type, isIgnored)
        {
        }

        /// <summary>
        /// Defines a token using the given regex and type, and determines whether it should be ignored or not.
        /// </summary>
        /// <param name="regex">The regex used to find this token.</param>
        /// <param name="type">The name of the type of this token.</param>
        /// <param name="isIgnored"></param>
        public TokenDefinition(Regex regex, string type, bool isIgnored)
        {
            Regex = regex ?? throw new ArgumentNullException("regex", "The regex for a TokenDefinition can't be null.");
            Type = type ?? throw new ArgumentNullException("type", "The type for a token can't be null.");
            IsIgnored = isIgnored;
        }
    }
}
