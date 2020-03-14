using System;
using Xunit;
using Fields;

namespace FieldsTests
{
    public class FiniteFieldTest
    {
        [Fact]
        public void AddTwoNumbers()
        {
            const int mod = 17;
            var x = new FiniteField(9, mod);
            var y = new FiniteField(12, mod);

            var actual = x + y;
            var expected = new FiniteField(4, mod);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void MultiplyTwoNumbers()
        {
            const int mod = 17;
            var x = new FiniteField(9, mod);
            var y = new FiniteField(12, mod);

            var actual = x * y;
            var expected = new FiniteField((9 * 12) % mod, mod);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void SubtractTwoNumbers()
        {
            const int mod = 17;
            var x = new FiniteField(9, mod);
            var y = new FiniteField(12, mod);

            var actual = x - y;
            var expected = new FiniteField(14, mod);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void DivideTwoNumbers()
        {
            const int mod = 17;
            var x = new FiniteField(9, mod);
            var y = new FiniteField(12, mod);

            var actual = x / y;
            var expected = new FiniteField(5, mod);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void DivideByZeroThrowsExeption()
        {
            const int mod = 17;
            var x = new FiniteField(9, mod);
            var y = new FiniteField(0, mod);

            Assert.Throws<DivideByZeroException>(() => x / y);
        }

        [Fact]
        public void NonPrimeModThrowsExeption()
        {
            Assert.Throws<ArgumentException>(() => new FiniteField(0, 10));
        }
    }
}
