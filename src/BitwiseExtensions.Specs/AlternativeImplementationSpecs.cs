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
    }
}