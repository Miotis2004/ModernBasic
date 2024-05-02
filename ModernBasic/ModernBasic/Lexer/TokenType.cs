using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernBasic.Lexer
{
    public enum TokenType
    {
        EOF,       // End of file
        Identifier,
        Integer,
        Float,
        String,
        Plus,      // +
        Minus,     // -
        Multiply,  // *
        Divide,    // /
        Assign,    // =
        LParen,    // (
        RParen,    // )
        Comma      // ,
    }

}
