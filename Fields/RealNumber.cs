﻿using System;
using System.Collections.Generic;

namespace Fields
{
    public class RealNumber : Field
    {
        private double num;

        public RealNumber(double x)
        {
            num = x;
        }

        public override Field NeutralByAddition => new RealNumber(0);

        public override Field NeutralByMultiplication => new RealNumber(1);

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

        protected override List<Field> Sqrt()
        {
            var res = new List<Field>();

            if (num < 0)
                return res;

            if (Math.Abs(num) < double.Epsilon)
                res.Add(new RealNumber(0));
            else
            {
                var sqrt = Math.Sqrt(num);

                res.Add(new RealNumber(+sqrt));
                res.Add(new RealNumber(-sqrt));
            }

            return res;
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
