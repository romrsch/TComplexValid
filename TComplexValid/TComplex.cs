using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TComplexValid
{
    public class TComplex
    {
        public double real;
        public double im;
        static bool onlyReal;

        // Создание комплексного числа из вызова типа TComplex(real, im)
        public TComplex(double real, double im)
        {
            this.real = real;
            this.im = im;
        }

        public TComplex(string complexNum, bool onlyRealAPP)
        {
            onlyReal = onlyRealAPP;

            string temp = "";
            bool imUse = false;
            string parseString = complexNum.Replace(" ", ""); // убираем все пробелы из переданной строки
            for (int i = 0; i < complexNum.Length; i++)
                if (complexNum[i] == 'i')
                {
                    imUse = true;
                    break;
                }

            if (!imUse)
            {
                this.real = double.Parse(complexNum);
                this.im = 0;
            }
            else
            {
                int realPartMinus = 0;
                int imPartMinus = 0;
                if (parseString[0] == '-')
                    realPartMinus = 1;
                for (int i = realPartMinus; i < parseString.Length; i++)
                {
                    if (parseString[i] != '+' && parseString[i] != '-') // при чтении знака "+" или "-" заканчивается реальная часть
                        temp += parseString[i];
                    else
                    {
                        if (parseString[i] == '-')
                            imPartMinus = 1;
                        this.real = double.Parse(temp);
                        if (realPartMinus == 1)
                            this.real *= -1;
                        temp = "";
                        i++;
                    }
                }
                this.im = double.Parse(temp);
                if (imPartMinus == 1)
                    this.im *= -1;
            }
        }

        public static TComplex operator +(TComplex a, TComplex b) // операция сложение
        {
            double treal = a.real + b.real;
            double tim = a.im + b.im;
            return new TComplex(treal, tim);
        }

        public static TComplex operator -(TComplex a, TComplex b) //  операция вычитание
        {
            double treal = a.real - b.real;
            double tim = a.im - b.im;
            return new TComplex(treal, tim);
        }

        public static TComplex operator *(TComplex a, TComplex b) //  операция умножение
        {
            double treal = a.real * b.real - a.im * b.im;
            double tim = a.real * b.im + b.real * a.im;
            return new TComplex(treal, tim);
        }

        public static TComplex operator /(TComplex a, TComplex b) //  операция деление
        {
            double treal = (a.real * b.real + a.im * b.im) / (Math.Pow(b.real, 2) + Math.Pow(b.im, 2));
            double tim = (b.real * a.im - a.real * b.im) / (Math.Pow(b.real, 2) + Math.Pow(b.im, 2));
            return new TComplex(treal, tim);
        }
        // Минус
        public TComplex minus()
        {
            return new TComplex(0, 0) - (this);
        }

        // Вернуть комплексное число строка
        public override string ToString()
        {
            if(onlyReal)
                return this.real.ToString();

            if (this.im == 0)
                return this.real.ToString();

            if (this.im > 0)
                return this.real + "+i" + this.im;
            else
                return this.real + "-i" + this.im * -1;
        }
    }
}

