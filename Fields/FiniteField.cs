using System;

namespace Fields
{
    public class FiniteField : Field
    {
        private int mod;
        private int num;

        public FiniteField(int x, int modulo)
        {
            if (!IsPrimeModulo(modulo))
                throw new ArgumentException("modulo must be a prime number and must be greather than 1");

            mod = modulo;
            num = x % mod;
        }

        protected override Field Add(Field b)
        {
            if (b is FiniteField y)
            {
                if (y.mod != mod)
                    throw new ArgumentException("modulo of b does not equal to modulo of a");

                return new FiniteField((num + y.num) % mod, mod);
            }
            else
                throw new ArgumentException("Type of b does not match to type a");
        }

        protected override Field Divide(Field b)
        {
            if (b is FiniteField y)
            {
                if (y.mod != mod)
                    throw new ArgumentException("modulo of b does not equal to modulo of a");

                (int d, int _, int t) = Gcd(mod, y.num);

                if (d != 1)
                    throw new DivideByZeroException("Division on non-invertable element");

                t %= mod;
                if (t < 0)
                    t += mod;

                int z = (num * t) % mod;

                return new FiniteField(z, mod);
            }
            else
                throw new ArgumentException("Type of b does not match to type a");
        }

        protected override bool EqualsTo(Field b)
        {
            if (b is FiniteField c && c.mod == mod)
                return (num - c.num) % mod == 0;
            return false;
        }

        protected override Field Multiply(Field b)
        {
            if (b is FiniteField y)
            {
                if (y.mod != mod)
                    throw new ArgumentException("modulo of b does not equal to modulo of a");

                return new FiniteField((num * y.num) % mod, mod);
            }
            else
                throw new ArgumentException("Type of b does not match to type a");
        }

        protected override Field Subtract(Field b)
        {
            if (b is FiniteField y)
            {
                if (y.mod != mod)
                    throw new ArgumentException("modulo of b does not equal to modulo of a");

                int t = (num - y.num) % mod;

                if (t < 0)
                    t += mod;

                return new FiniteField(t, mod);
            }
            else
                throw new ArgumentException("Type of b does not match to type a");
        }

        private bool IsPrimeModulo(int modulo)
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
    }
}
