using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernBasic.Lexer
{
    public class Lexer
    {
        private string input;
        private int position;
        private int readPosition;
        private char currentChar;

        public Lexer(string input)
        {
            this.input = input;
            this.position = 0;
            this.readPosition = 0;
            ReadChar();
        }

        private void ReadChar()
        {
            if (readPosition >= input.Length)
            {
                currentChar = '\0';  // EOF
            }
            else
            {
                currentChar = input[readPosition];
            }
            position = readPosition;
            readPosition += 1;
        }

        public Token NextToken()
        {
            Token token;

            SkipWhitespace();

            switch (currentChar)
            {
                case '=':
                    token = new Token(TokenType.Assign, "=");
                    break;
                case '+':
                    token = new Token(TokenType.Plus, "+");
                    break;
                case '-':
                    token = new Token(TokenType.Minus, "-");
                    break;
                case '*':
                    token = new Token(TokenType.Multiply, "*");
                    break;
                case '/':
                    token = new Token(TokenType.Divide, "/");
                    break;
                case '(':
                    token = new Token(TokenType.LParen, "(");
                    break;
                case ')':
                    token = new Token(TokenType.RParen, ")");
                    break;
                case ',':
                    token = new Token(TokenType.Comma, ",");
                    break;
                case '\0':
                    token = new Token(TokenType.EOF, "");
                    break;
                default:
                    if (IsLetter(currentChar))
                    {
                        string identifier = ReadIdentifier();
                        token = new Token(TokenType.Identifier, identifier);
                        return token;
                    }
                    else if (IsDigit(currentChar))
                    {
                        string number = ReadNumber();
                        token = new Token(char.IsDot(number[0]) ? TokenType.Float : TokenType.Integer, number);
                        return token;
                    }
                    else if (currentChar == '"')
                    {
                        string str = ReadString();
                        token = new Token(TokenType.String, str);
                        return token;
                    }
                    else
                    {
                        throw new Exception($"Illegal character encountered: {currentChar}");
                    }
            }

            ReadChar();
            return token;
        }

        private void SkipWhitespace()
        {
            while (char.IsWhiteSpace(currentChar))
            {
                ReadChar();
            }
        }

        private string ReadIdentifier()
        {
            int startPosition = position;
            while (IsLetter(currentChar) || IsDigit(currentChar))
            {
                ReadChar();
            }
            return input.Substring(startPosition, position - startPosition);
        }

        private string ReadNumber()
        {
            int startPosition = position;
            while (IsDigit(currentChar) || currentChar == '.')
            {
                ReadChar();
            }
            return input.Substring(startPosition, position - startPosition);
        }

        private string ReadString()
        {
            ReadChar();  // Skip the opening quote
            int startPosition = position;
            while (currentChar != '"' && currentChar != '\0')
            {
                ReadChar();
            }
            string str = input.Substring(startPosition, position - startPosition);
            ReadChar();  // Skip the closing quote
            return str;
        }

        private bool IsLetter(char ch)
        {
            return char.IsLetter(ch) || ch == '_';
        }

        private bool IsDigit(char ch)
        {
            return char.IsDigit(ch) || ch == '.';
        }
    }

}
