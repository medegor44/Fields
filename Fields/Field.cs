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

        protected abstract bool EqualsTo(Field b);
        protected abstract Field Add(Field b);
        protected abstract Field Multiply(Field b);
        protected abstract Field Subtract(Field b);
        protected abstract Field Divide(Field b);
    }
}
