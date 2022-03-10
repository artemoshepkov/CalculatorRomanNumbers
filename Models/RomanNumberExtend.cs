using System;

namespace CalculatorRomanNumber.Models
{
    public class RomanNumberExtend : RomanNumber
    {
        private RomanNumberExtend(ushort n) : base(n) { }

        public static RomanNumberExtend Create(string num)
        {
            ushort resultNumber = 0;

            int index = 0;
            while (index < num.Length)
            {
                if (num[index] == 'M')
                {
                    resultNumber += 1000;
                    index += 1;
                }
                else if (index < num.Length - 1 && num[index] == 'C' && num[index + 1] == 'M')
                {
                    resultNumber += 900;
                    index += 2;
                }
                else if (num[index] == 'D')
                {
                    resultNumber += 500;
                    index += 1;
                }
                else if (index < num.Length - 1 && num[index] == 'C' && num[index + 1] == 'D')
                {
                    resultNumber += 400;
                    index += 2;
                }
                else if (num[index] == 'C')
                {
                    resultNumber += 100;
                    index += 1;
                }
                else if (index < num.Length - 1 && num[index] == 'X' && num[index + 1] == 'C')
                {
                    resultNumber += 90;
                    index += 2;
                }
                else if (num[index] == 'L')
                {
                    resultNumber += 50;
                    index += 1;
                }
                else if (index < num.Length - 1 && num[index] == 'X' && num[index + 1] == 'L')
                {
                    resultNumber += 40;
                    index += 2;
                }
                else if (num[index] == 'X')
                {
                    resultNumber += 10;
                    index += 1;
                }
                else if (index < num.Length - 1 && num[index] == 'I' && num[index + 1] == 'X')
                {
                    resultNumber += 9;
                    index += 2;
                }
                else if (num[index] == 'V')
                {
                    resultNumber += 5;
                    index += 1;
                }
                else if (index < num.Length - 1 && num[index] == 'I' && num[index + 1] == 'V')
                {
                    resultNumber += 4;
                    index += 2;
                }
                else if (num[index] == 'I')
                {
                    resultNumber += 1;
                    index += 1;
                }
            }

            return new RomanNumberExtend(resultNumber);
        }
    }
}
