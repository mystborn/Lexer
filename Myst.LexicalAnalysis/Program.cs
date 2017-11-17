using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Myst.LexicalAnalysis
{
    public class Program
    {
        //private static string newLinePattern = $"(?<NewLine>({Environment.NewLine}|\n|\r|\t|\v|\f)+)";
        //private static Regex _whiteSpace = new Regex($@"( *(?<NewLine>({Environment.NewLine}|\n|\r|\t|\v|\f)+)?)+", RegexOptions.Compiled);

        static void Main(string[] args)
        {   
            var lexer = new Lexer();
            lexer.AddDefinition(new TokenDefinition("hello|hi|greetings", "Greeting"));
            lexer.AddDefinition(new TokenDefinition(",", "Comma"));
            lexer.AddDefinition(new TokenDefinition("world", "World"));

            foreach(var token in lexer.Tokenize("hello, world\n" +
                "hi, world\n" +
                "greetings, world"))
            {
                Console.WriteLine(token);
            }

            Console.ReadLine();
        }
    }
}
