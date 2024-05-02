using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernBasic.Lexer;
using NUnit.Framework;

namespace ModernBasic.Tests
{
    [TestFixture]
    public class LexerTests
    {
        [Test]
        public void TestSimpleExpression()
        {
            var input = "var = 3 + 4 * 10";
            var lexer = new Lexer(input);
            Token token;
            do
            {
                token = lexer.NextToken();
                Console.WriteLine($"{token.Type} - {token.Value}");
            } while (token.Type != TokenType.EOF);
        }
    }
}
