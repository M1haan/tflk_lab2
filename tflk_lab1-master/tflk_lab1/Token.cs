using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tflk_lab1.Enums;

namespace tflk_lab1
{
    public class Token
    {
        public ElementType Type { get; set; }
        public string Value { get; set; }
        public int LineNumber { get; set; }
        public int StartPos { get; set; }

        public Token(ElementType type, string value, int lineNumber, int startPos)
        {
            Type = type;
            Value = value;
            LineNumber = lineNumber;
            StartPos = startPos;
        }

        public Token() { }
    }
}
