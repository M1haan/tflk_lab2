using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using tflk_lab1.Enums;

namespace tflk_lab1
{
    public class Lexer
    {
        private Dictionary<string, ElementType> keywords = new Dictionary<string, ElementType>
    {
        {"integer", ElementType.keyWord},
        {"char", ElementType.keyWord},
        {"double", ElementType.keyWord},
        // Добавьте другие ключевые слова языка Pascal
    };

        private Regex identifierRegex = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_]*$");
        private Regex numberRegex = new Regex(@"^\d+$");

        public List<Token> Tokenize(string input)
        {
            List<Token> tokens = new List<Token>();
            int currentIndex = 0;

            while (currentIndex < input.Length)
            {
                if (char.IsWhiteSpace(input[currentIndex]))
                {
                    currentIndex++;
                    continue;
                }

                ElementType elementType = ElementType.ERROR;
                int startIndex = currentIndex;

                // Проверяем каждую лексему, начиная с самой длинной
                foreach (var keyword in keywords.Keys)
                {
                    if (input.Substring(currentIndex).StartsWith(keyword))
                    {
                        elementType = keywords[keyword];
                        currentIndex += keyword.Length;
                        break;
                    }
                }

                if (elementType == ElementType.ERROR)
                {
                    if (identifierRegex.IsMatch(input.Substring(currentIndex)))
                    {
                        elementType = ElementType.keyWord;
                        while (currentIndex < input.Length && identifierRegex.IsMatch(input.Substring(currentIndex, 1)))
                        {
                            currentIndex++;
                        }
                    }
                    else
                    {
                        // Если не удалось определить тип, считаем текущий символ недопустимым
                        elementType = ElementType.ERROR;
                        currentIndex++;
                    }
                }

                tokens.Add(new Token
                {
                    Type = elementType,
                    Value = input.Substring(startIndex, currentIndex - startIndex),
                    StartPos = startIndex + 1, // Индексы начинаются с 1
                    LineNumber = currentIndex
                });
            }

            return tokens;
        }
    }
}
