using System;
using Xunit;
using Fields;

namespace FieldsTests
{
    public class RealNumbersTests
    {
        [Fact]
        public void AddTwoNumbers()
        {
            var x = new RealNumber(1);
            var y = new RealNumber(2);

            var actual = x + y;
            var expected = new RealNumber(3);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void MultiplyTwoNumbers()
        {
            var x = new RealNumber(3);
            var y = new RealNumber(5);

            var actual = x * y;
            var expected = new RealNumber(15);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void SubtractTwoNumbers()
        {
            var x = new RealNumber(0.1);
            var y = new RealNumber(1.5);

            var actual = x - y;
            var expected = new RealNumber(-1.4);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void DivideTwoNumbers()
        {
            var x = new RealNumber(1.5);
            var y = new RealNumber(2.3);

            var actual = x / y;
            var expected = new RealNumber(1.5 / 2.3);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void DivideByZeroThrowsExeption()
        {
            var x = new RealNumber(1);
            var y = new RealNumber(0);

            Assert.Throws<DivideByZeroException>(() => x / y);
        }
    }
}
