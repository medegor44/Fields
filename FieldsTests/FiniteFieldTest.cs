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
            FiniteField.Mod = 17;

            var x = new FiniteField(9);
            var y = new FiniteField(12);

            var actual = x + y;
            var expected = new FiniteField(4);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void MultiplyTwoNumbers()
        {
            FiniteField.Mod = 17;

            var x = new FiniteField(9);
            var y = new FiniteField(12);

            var actual = x * y;
            var expected = new FiniteField((9 * 12) % FiniteField.Mod);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void SubtractTwoNumbers()
        {
            FiniteField.Mod = 17;

            var x = new FiniteField(9);
            var y = new FiniteField(12);

            var actual = x - y;
            var expected = new FiniteField(14);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void DivideTwoNumbers()
        {
            FiniteField.Mod = 17;

            var x = new FiniteField(9);
            var y = new FiniteField(12);

            var actual = x / y;
            var expected = new FiniteField(5);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void DivideByZeroThrowsExeption()
        {
            FiniteField.Mod = 17;

            var x = new FiniteField(9);
            var y = new FiniteField(0);

            Assert.Throws<DivideByZeroException>(() => x / y);
        }

        [Fact]
        public void NonPrimeModThrowsExeption()
        {
            Assert.Throws<ArgumentException>(() => { FiniteField.Mod = 16; });
        }
    }
}
