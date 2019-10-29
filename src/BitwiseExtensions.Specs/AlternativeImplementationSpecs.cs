namespace BitwiseExtensions.Specs
{
    using FluentAssertions;
    using Xunit;

    public class AlternativeImplementationSpecs
    {
        [Fact]
        public void Can_divide()
        {
            9.Divide(4).Should().Be(2);
        }

        [Fact]
        public void Can_multiply()
        {
            7.Multiply(3).Should().Be(21);
        }

        [Fact]
        public void Can_add()
        {
            0b111.Add(0b101).Should().Be(0b1100); //7+5=12
        }

        [Fact]
        public void Can_subtract()
        {
            7.Subtract(3).Should().Be(4);
        }

        [Fact]
        public void Can_subtract_negative_number()
        {
            7.Subtract(-3).Should().Be(10);
        }

        [Fact]
        public void Can_subtract_negative_number_from_negative_number()
        {
            (-7).Subtract(-3).Should().Be(-4);
        }

        [Fact]
        public void Can_subtract_from_negative_number()
        {
            (-7).Subtract(3).Should().Be(-10);
        }

        [Fact]
        public void Can_negate()
        {
            7.Negate().Should().Be(-7);
        }

        [Fact]
        public void Can_prevent_overflow_with_addition_by_performing_modulo()
        {
            long sum = 0;
            long expectedSum = 0;
            foreach (int number in new []{ int.MaxValue, int.MaxValue })
            {
                sum = (sum + number).ClampByBigPrimeNumber();
                expectedSum = expectedSum + number;
            }

            sum.Should().Be(expectedSum.ClampByBigPrimeNumber());
        }

        [Fact]
        public void Can_prevent_overflow_with_substruction_by_performing_modulo()
        {
            long result = 0;
            long expectedResult = 0;
            foreach (int number in new[] { int.MaxValue, -int.MaxValue })
            {
                result = (result - number).ClampByBigPrimeNumber();
                expectedResult = expectedResult - number;
            }

            result.Should().Be(expectedResult.ClampByBigPrimeNumber());
        }

        [Fact]
        public void Can_prevent_overflow_with_multiplication_by_performing_modulo()
        {
            long multiplication = 1;
            long expectedMultiplication = 1;
            foreach (int number in new[] { int.MaxValue, int.MaxValue })
            {
                multiplication = (multiplication * number).ClampByBigPrimeNumber();
                expectedMultiplication = expectedMultiplication * number;
            }

            multiplication.Should().Be(expectedMultiplication.ClampByBigPrimeNumber());
        }
    }
}