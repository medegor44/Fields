using System;

namespace Fields
{
    public class RealNumber : Field
    {
        private double num;

        public RealNumber(double x)
        {
            num = x;
        }

        protected override Field Add(Field b)
        {
            if (b is RealNumber y)
                return new RealNumber(num + y.num);
            else
                throw new ArgumentException("Type of b does not match to type a");
        }

        protected override Field Divide(Field b)
        {
            if (b is RealNumber y)
            {
                if (Math.Abs(y.num) < double.Epsilon)
                    throw new DivideByZeroException("Division on non-invertable element");

                return new RealNumber(num / y.num);
            }
            else
                throw new ArgumentException("Type of b does not match to type a");
        }

        protected override bool EqualsTo(Field b)
        {
            if (b is RealNumber c)
                return Math.Abs(num - c.num) < double.Epsilon;
            return false;
        }

        protected override Field Multiply(Field b)
        {
            if (b is RealNumber y)
                return new RealNumber(num * y.num);
            else
                throw new ArgumentException("Type of b does not match to type a");
        }

        protected override Field Subtract(Field b)
        {
            if (b is RealNumber y)
                return new RealNumber(num - y.num);
            else
                throw new ArgumentException("Type of b does not match to type a");
        }
    }
}
