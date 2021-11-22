using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using System.IO;

namespace Compiler
{
    public class SyntaxError

    {
        public TextWriter output;
        public IRecognizer recognizer;
        public IToken offendingSymbol;
        public int line;
        public int charPositionInLine;
        public string msg;
        public RecognitionException e;
        public SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)

        {
            this.output = output;
            this.recognizer = recognizer;
            this.offendingSymbol = offendingSymbol;
            this.line = line;
            this.charPositionInLine = charPositionInLine;
            this.e = e;
            this.msg = msg;
        }

        public override string ToString()

        {
            string str = "Errors: ";
            str += msg;
            str += ", in line " + line;
            str += ":" + charPositionInLine;
            return str;
        }

        public class SyntaxErrListener : BaseErrorListener

        {
            List<SyntaxError> syntaxErrors;
            public List<SyntaxError> SyntaxErrors { get => syntaxErrors; }
            public SyntaxErrListener()

            {
                syntaxErrors = new List<SyntaxError>();
            }

            public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)

            {
                syntaxErrors.Add(new SyntaxError(output, recognizer, offendingSymbol, line, charPositionInLine, msg, e));
            }
        }

        public class SyntaxErrListenerLexer : IAntlrErrorListener<int>

        {
            List<SyntaxError> syntaxErrors;
            public List<SyntaxError> SyntaxErrors { get => syntaxErrors; }
            public SyntaxErrListenerLexer()
            {
                syntaxErrors = new List<SyntaxError>();
            }

            public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)

            {
                syntaxErrors.Add(new SyntaxError(output, recognizer, null, line, charPositionInLine, msg, e));
            }

        }

    }

}
