namespace BitwiseExtensions.Specs
{
    using FluentAssertions;
    using Xunit;

    public class BitwiseExtensionsSpecs
    {
        [Fact]
        public void Should_see_that_bit_is_not_set()
        {
            0b00.IsBitSet(1).Should().BeFalse();
        }

        [Fact]
        public void Should_see_that_bit_is_set()
        {
            0b10.IsBitSet(1).Should().BeTrue();
        }

        [Fact]
        public void Can_set_0_bit()
        {
            0b00.SetBit(1).Should().Be(0b10);
        }

        [Fact]
        public void Can_set_1_bit()
        {
            0b10.SetBit(1).Should().Be(0b10);
        }

        [Fact]
        public void Can_unset_0_bit()
        {
            0b00.UnsetBit(1).Should().Be(0b00);
        }

        [Fact]
        public void Can_unset_1_bit()
        {
            0b10.UnsetBit(1).Should().Be(0b00);
        }

        [Fact]
        public void Can_toggle_0_bit()
        {
            0b00.ToggleBit(1).Should().Be(0b10);
        }

        [Fact]
        public void Can_toggle_1_bit()
        {
            0b10.ToggleBit(1).Should().Be(0b00);
        }
    }
}
