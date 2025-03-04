using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilator_Kursovaya
{
    public class Scaner
    {
        private string input;
        private int position = 0;
        public List<Error> errors;

        private static readonly Dictionary<string, int> Keywords = new()
        {
            { "const", 1 },
            { "integer", 3 }
        };

        public Scaner(string input, List<Error> errors)
        {
            this.input = input.Trim();
            this.errors = errors;
        }

        private char CurrentChar => position < input.Length ? input[position] : '\0';

        private void NextChar() => position++;

        public void Analyze()
        {
            while (position < input.Length)
            {
                char ch = CurrentChar;
                int startPos = position;
                int endPos = position;

                switch (ch)
                {
                    case char c when char.IsLetter(c):
                        ProcessIdentifier(startPos);
                        break;
                    case ' ':
                        AddToken(4, "Разделитель", "_", startPos+" - "+endPos);
                        NextChar();
                        break;
                    case ':':
                        AddToken(5, "Двоеточие", ":", startPos + " - " + endPos);
                        NextChar();
                        break;
                    case '=':
                        AddToken(6, "Присваивание", "=", startPos + " - " + endPos);
                        NextChar();
                        break;
                    case '-':
                        AddToken(7, "Минус", "-", startPos + " - " + endPos);
                        NextChar();
                        break;
                    case '+':
                        AddToken(8, "Плюс", "+", startPos + " - " + endPos);
                        NextChar();
                        break;
                    case char c when char.IsDigit(c):
                        ProcessNumber(startPos);
                        break;
                    case ';':
                        AddToken(10, "Конец оператора", ";", startPos + " - " + endPos);
                        NextChar();
                        break;
                    case '\n':
                    case '\r':
                        //AddToken(11, "Перенос строки", "ENTER", startPos);
                        NextChar();
                        break;
                    default:
                        AddToken(-1, "Ошибка", ch.ToString(), startPos + " - " + endPos);
                        NextChar();
                        break;
                }
            }
        }

        private void ProcessIdentifier(int startPos)
        {
            string lexeme = "";
            while (char.IsLetterOrDigit(CurrentChar))
            {
                lexeme += CurrentChar;
                NextChar();
            }
            int endPos = startPos + lexeme.Length;
            if (Keywords.TryGetValue(lexeme, out int code))
            {
                AddToken(code, "Ключевое слово", lexeme, startPos + " - " + endPos);
            }
            else
            {
                AddToken(2, "Идентификатор", lexeme, startPos + " - " + endPos);
            }
        }

        private void ProcessNumber(int startPos)
        {
            
            string number = "";
            while (char.IsDigit(CurrentChar))
            {
                number += CurrentChar;
                NextChar();
            }
            int endPos = startPos + number.Length;
            AddToken(9, "Целое число", number, startPos + " - " + endPos);
        }

        private void AddToken(int code, string type, string lexeme, string position)
        {
            errors.Add(new Error {index = errors.Count, code = code, token_type = type, token = lexeme, location = position });
        }
    }
}
