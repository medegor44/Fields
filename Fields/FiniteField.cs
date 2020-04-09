using System;
using System.Collections.Generic;

namespace Fields
{
    public class FiniteField : Field
    {
        public static int Mod
        {
            get => _mod;
            set
            {
                if (!IsPrimeModulo(value))
                    throw new ArgumentException("Modulo must be prime");
                _mod = value;
            }
        }

        private int num;
        private static int _mod;

        public override Field NeutralByAddition => new FiniteField(0);

        public override Field NeutralByMultiplication => new FiniteField(1);

        public FiniteField(int x)
        {
            if (!IsPrimeModulo(Mod))
                throw new ArgumentException("modulo must be a prime number and must be greather than 1");

            num = x % Mod;
        }

        protected override Field Add(Field b)
        {
            if (b is FiniteField y)
                return new FiniteField((num + y.num) % Mod);
            else
                throw new ArgumentException("Type of b does not match to type a");
        }

        protected override Field Divide(Field b)
        {
            if (b is FiniteField y)
            {
                (int d, int _, int t) = Gcd(Mod, y.num);

                if (d != 1)
                    throw new DivideByZeroException("Division on non-invertable element");

                t %= Mod;
                if (t < 0)
                    t += Mod;

                int z = (num * t) % Mod;

                return new FiniteField(z);
            }
            else
                throw new ArgumentException("Type of b does not match to type a");
        }

        protected override bool EqualsTo(Field b)
        {
            if (b is FiniteField c)
                return (num - c.num) % Mod == 0;
            return false;
        }

        protected override Field Multiply(Field b)
        {
            if (b is FiniteField y)
            {
                return new FiniteField((num * y.num) % Mod);
            }
            else
                throw new ArgumentException("Type of b does not match to type a");
        }

        protected override Field Subtract(Field b)
        {
            if (b is FiniteField y)
            {
                int t = (num - y.num) % Mod;

                if (t < 0)
                    t += Mod;

                return new FiniteField(t);
            }
            else
                throw new ArgumentException("Type of b does not match to type a");
        }

        private static bool IsPrimeModulo(int modulo)
        {
            if (modulo <= 1)
                return false;

            for (long i = 2; i * i <= modulo; i++)
                if (modulo % i == 0)
                    return false;

            return true;
        }

        private (int, int, int) Gcd(int a, int b)
        {
            if (b == 0)
                return (a, 1, 0);

            (int d, int x1, int y1) = Gcd(b, a % b);

            int x = y1;
            int y = x1 - (a / b) * y1;

            return (d, x, y);
        }

        protected override List<Field> Sqrt()
        {
            var res = new List<Field>();

            for (int i = 0; i < Mod; i++)
                if (i * i % Mod == num)
                    res.Add(new FiniteField(i));

            return res;
        }
    }
}
