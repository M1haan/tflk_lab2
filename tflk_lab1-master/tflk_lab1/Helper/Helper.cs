using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using tflk_lab1.Enums;

namespace tflk_lab1
{
    public static class Helper
    {
        private static readonly string _mainPattern = @"\btype\b\s+[a-zA-Z]+\s+=\s+(integer|real|char)\s*;";
        private static List<Token> _elementList { get; set; } = new List<Token>();

        public static readonly Dictionary<ElementType, string> elementTitles = new Dictionary<ElementType, string>()
        {
            {ElementType.ERROR, "Ошибка" },
            {ElementType.AssignmentOperator, "Оператор присваивания" },
            {ElementType.divived, "Разделитель" },
            {ElementType.Integer, "Тип данных: Целочисленный" },
            {ElementType.Real, "Тип данных: Вещественное число" },
            {ElementType.Char, "Тип данных: Символ" },
            {ElementType.EndLine, "Конец строки" },
            {ElementType.typeName, "Имя типа" },
            {ElementType.keyWord, "Ключевое слово" },
        };



        private static readonly Dictionary<ElementType, string> digitPatterns = new Dictionary<ElementType, string>()
        {
            //{ ElementType.ExpDigit, @"e" },
            //{ ElementType.IntDigit, @"^\d+$"  },
            //{ ElementType.FloatDigit, @"^-?\d+\.\d+?$"},
            //{ ElementType.RoundNumber, @"^\.\d+?$"}
        };
        private static readonly Dictionary<ElementType, string> stringPatterns = new Dictionary<ElementType, string>()
        {
            { ElementType.typeName, @"[A-Za-z_]+\s*" }
            //{ ElementType.String, @"[A-Za-z_]+\s*" }
        };

        public static List<Token> Tokenize(this string input)
        {
            int lineNumber = 1;
            int startPos = 1;
            short positionInList = 0;

            var mathesRegex = Regex.Matches(input, _mainPattern);

            foreach (Match match in mathesRegex)
            {
                string value = match.Value.Trim();

                //Определяем одиночные символы
                //ElementType type = value.SetElementType();

                //if (type == 0)
                //{
                //    type = value.FindElementType(digitPatterns);
                //}

                //if (type == ElementType.ERROR)
                //{
                //    type = value.FindElementType(stringPatterns);
                //}

                //_elementList.Add(new Token(type, value, lineNumber, startPos));
                //startPos += value.Length;

                //Определяем имена переменных
                if (positionInList != 0 && _elementList[positionInList].Type == ElementType.AssignmentOperator)
                {
                    _elementList[positionInList - 1].Type = ElementType.typeName;
                }

                positionInList++;
            }

            //_elementList.SetStringElementType();

            return _elementList;
        }

        //private static ElementType SetElementType(this string value) => applySymbols.FirstOrDefault(x => x.Value == value).Key;

        private static ElementType FindElementType(this string value, Dictionary<ElementType, string> patterns)
        {
            foreach (var pattern in patterns)
            {
                var math = Regex.Matches(value, pattern.Value);
                if (math.Count != 0) return pattern.Key;
            }

            return ElementType.ERROR;
        }

    }
}
