using System;

namespace CalculatorRomanNumber.Models
{
    public class RomanNumber : ICloneable, IComparable
    {
        private ushort _number;
        private string _romanNumber = string.Empty;

        private static ushort minNumber = 1;
        private static ushort maxNumber = 3999;

        public RomanNumber(ushort n)
        {
            if (n < minNumber || n > maxNumber)
                throw new RomanNumberException("Insert value must be between 1 and 3999");
            _number = n;

            _romanNumber = ToString();
        }

        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new RomanNumberException("Invalid values");

            return new RomanNumber((ushort)(n1._number + n2._number));
        }

        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new RomanNumberException("Invalid values");
            if (n1._number <= n2._number)
                throw new RomanNumberException("Answer doesn`t exist in Roman numbers");

            return new RomanNumber((ushort)(n1._number - n2._number));
        }

        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new ArgumentNullException("Invalid values");
            if (n1._number * n2._number > maxNumber)
                throw new RomanNumberException("Answer doesn`t exist in Roman numbers");

            return new RomanNumber((ushort)(n1._number * n2._number));
        }

        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new ArgumentNullException("Invalid values");
            if (n1._number < n2._number)
                throw new RomanNumberException("Answer doesn`t exist in Roman numbers");

            return new RomanNumber((ushort)(n1._number / n2._number));
        }

        public override string ToString()
        {
            ushort tempNumber = _number;
            string romanNumber = string.Empty;

            while (tempNumber > 0)
            {
                if (tempNumber >= 1000)
                {
                    tempNumber -= 1000;
                    romanNumber += "M";
                }
                else if (tempNumber >= 900)
                {
                    tempNumber -= 900;
                    romanNumber += "CM";
                }
                else if (tempNumber >= 500)
                {
                    tempNumber -= 500;
                    romanNumber += "D";
                }
                else if (tempNumber >= 400)
                {
                    tempNumber -= 400;
                    romanNumber += "CD";
                }
                else if (tempNumber >= 100)
                {
                    tempNumber -= 100;
                    romanNumber += "C";
                }
                else if (tempNumber >= 90)
                {
                    tempNumber -= 90;
                    romanNumber += "XC";
                }
                else if (tempNumber >= 50)
                {
                    tempNumber -= 50;
                    romanNumber += "L";
                }
                else if (tempNumber >= 40)
                {
                    tempNumber -= 40;
                    romanNumber += "XL";
                }
                else if (tempNumber >= 10)
                {
                    tempNumber -= 10;
                    romanNumber += "X";
                }
                else if (tempNumber >= 9)
                {
                    tempNumber -= 9;
                    romanNumber += "IX";
                }
                else if (tempNumber >= 5)
                {
                    tempNumber -= 5;
                    romanNumber += "V";
                }
                else if (tempNumber >= 4)
                {
                    tempNumber -= 4;
                    romanNumber += "IV";
                }
                else if (tempNumber >= 1)
                {
                    tempNumber -= 1;
                    romanNumber += "I";
                }
            }

            return romanNumber;
        }

        public object Clone()
        {
            return new RomanNumber(_number);
        }

        public int CompareTo(object? obj)
        {
            if (obj is RomanNumber number)
                return _number - number._number;
            else
                throw new RomanNumberException("Invalid value");
        }

    }
}
