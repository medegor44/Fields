using System;

namespace Fields
{
    public abstract class Field
    {
        public static Field operator +(Field a, Field b)
        {
            return a.Add(b);
        }

        public static Field operator *(Field a, Field b)
        {
            return a.Multiply(b);
        }

        public static Field operator *(int n, Field a)
        {
            var res = a.NeutralByAddition;

            int k = n;
            if (k < 0)
                k = -k;

            while (k > 0)
            {
                if (k % 2 != 0)
                    res += a;

                a += a;
                k /= 2;
            }

            if (n > 0)
                return res;
            else
                return -res;
        }

        public static Field Pow(Field a, int n)
        {
            var res = a.NeutralByMultiplication;

            int k = n;
            if (k < 0)
                k = -k;

            while (k > 0)
            {
                if (k % 2 != 0)
                    res *= a;

                a *= a;
                k /= 2;
            }

            if (n > 0)
                return res;
            else
                return a.NeutralByMultiplication / a;
        }

        public static Field operator-(Field a)
        {
            return a.NeutralByAddition - a;
        }

        public static Field operator -(Field a, Field b)
        {
            return a.Subtract(b);
        }

        public static Field operator /(Field a, Field b)
        {
            return a.Divide(b);
        }

        public static bool operator==(Field a, Field b)
        {
            return a.EqualsTo(b);
        }

        public static bool operator!=(Field a, Field b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is Field b)
                return this.EqualsTo(b);
            return false;
        }

        public abstract Field NeutralByAddition { get; }
        public abstract Field NeutralByMultiplication { get; }

        protected abstract bool EqualsTo(Field b);
        protected abstract Field Add(Field b);
        protected abstract Field Multiply(Field b);
        protected abstract Field Subtract(Field b);
        protected abstract Field Divide(Field b);
    }
}
