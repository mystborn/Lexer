using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Myst.LexicalAnalysis;

namespace Myst.LexicalAnalysis.Tests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void Tokenize_ValidInput_ReturnsValidStream()
        {
            var lexer = new Lexer();
            lexer.AddDefinition(new TokenDefinition("hello|hi|greetings", "Greeting"));
            lexer.AddDefinition(new TokenDefinition(",", "Comma"));
            lexer.AddDefinition(new TokenDefinition("world", "World"));

            var list = new List<Token>(lexer.Tokenize("hi, world", false));
            Assert.IsTrue(list[0].Value == "hi");
            Assert.IsTrue(list[1].Value == ",");
            Assert.IsTrue(list[2].Value == " ");
            Assert.IsTrue(list[3].Value == "world");
        }

        [TestMethod]
        [ExpectedException(typeof(UnrecognizedTokenException))]
        public void Tokenize_InvalidInput_Throws()
        {
            var lexer = new Lexer();
            lexer.AddDefinition(new TokenDefinition("hello|hi|greetings", "Greeting"));
            lexer.AddDefinition(new TokenDefinition(",", "Comma"));
            lexer.AddDefinition(new TokenDefinition("world", "World"));

            var list = new List<Token>(lexer.Tokenize("hello. world"));
        }

        [TestMethod]
        public void Tokenize_ValidInput_ReturnsValidPositions()
        {
            var lexer = new Lexer();
            lexer.AddDefinition(new TokenDefinition("hello|hi|greetings", "Greeting"));
            lexer.AddDefinition(new TokenDefinition(",", "Comma"));
            lexer.AddDefinition(new TokenDefinition("world", "World"));

            var list = new List<Token>(lexer.Tokenize("hello, world\n" +
                "hi, world\n" +
                "greetings, world"));

            Assert.IsTrue(list[6].Position.Line == 3);
            Assert.IsTrue(list[3].Position.Line == 2);
        }
    }
}
