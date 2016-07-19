using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trainingProject
{
    class Rational
    {
        public double A { get; set; }
        public double B { get; set; }

        public Rational() { }
        public Rational(int a, int b) {
            this.A = a;
            this.B = b;
        }

        public static Rational operator +(Rational first, Rational second)
        {
            Rational result = new Rational();
            result.A = (first.A * second.B) + (first.B * second.A);
            result.B = first.B * second.B;
            result.CheckRational();
            return result;
        }

        //public static Rational operator +(Rational first, double second)
        //{
        //    Rational secondRational = new Rational();
        //    string str = second.ToString();
        //    int length = str.Length - str.IndexOf(",") - 1;
        //    secondRational.A = second * Math.Pow(10,length);
        //    secondRational.B = Math.Pow(10, length);
        //    secondRational.CheckRational();
        //    return first + secondRational;
        //}


        public static Rational operator +(Rational first, double second)
        {
            Rational secondRational = new Rational();

            double num = Math.Truncate(second);
            string dem = (second - num).ToString().Substring(2);
            switch (dem.Length) {
                case 1: secondRational.A = second * 10;
                    secondRational.B = 10;
                    break;
                case 2: secondRational.A = second * 100;
                    secondRational.B = 100;
                    break;
                case 3:
                    secondRational.A = second * 1000;
                    secondRational.B = 1000;
                    break;
            }
            //secondRational.CheckRational();
            double gcd = Rational.FindEuclidGcd((int)secondRational.A, (int)secondRational.B);
            secondRational.A /= gcd;
            secondRational.B /= gcd;
            return first + secondRational;
        }


        public static Rational operator -(Rational first, Rational second)
        {
            Rational result = new Rational();
            result.A = (first.A * second.B) - (first.B * second.A);
            result.B = first.B * second.B;
            result.CheckRational();
            return result;
        }

        public static Rational operator *(Rational first, Rational second)
        {
            Rational result = new Rational();
            result.A = first.A * second.A;
            result.B = first.B * second.B;
            result.CheckRational();
            return result;
        }

        public static Rational operator /(Rational first, Rational second)
        {
            Rational result = new Rational();
            result.A = first.A * second.B;
            result.B = first.B * second.A;
            result.CheckRational();
            return result;
        }

        public static bool operator ==(Rational first, Rational second)
        {
            return (first.A * second.B == second.A*first.B);
        }

        public static bool operator !=(Rational first, Rational second)
        {
            return (first.A * second.B != second.A * first.B);
        }

        public void CheckRational()
        {
            Rational res = new Rational();

            int min = Convert.ToInt32(Math.Min(this.A, this.B));
            for(int i = 2; i < min; i++)
            {
                if(this.A % i == 0 && this.B % i == 0)
                {
                    this.A /= i;
                    this.B /= i;
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", this.A, this.B);
        }

        public static int FindEuclidGcd(int firstNum, int secondNum)
        {
            int gcd = 0;
            int maxNum = firstNum;
            int minNum = secondNum;
            if (maxNum < secondNum && minNum > firstNum)
            {
                maxNum = secondNum;
                minNum = firstNum;
            }

            while (maxNum != minNum)
            {
                if (maxNum == 0)
                {
                    gcd = minNum;
                    break;
                }
                else if (minNum == 0)
                {
                    gcd = maxNum;
                    break;
                }
                else if (maxNum % minNum == 0)
                {
                    gcd = minNum;
                    break;
                }
                else
                {
                    int rest = maxNum % minNum;
                    maxNum = minNum;
                    minNum = rest;

                }
            }
            if (maxNum == minNum)
            {
                gcd = maxNum;
            }
            return gcd;
        }
    }
}
