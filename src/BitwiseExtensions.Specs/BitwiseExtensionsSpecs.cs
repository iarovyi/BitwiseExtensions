namespace BitwiseExtensions.Specs
{
    using FluentAssertions;
    using Xunit;
    using static BitwiseExtensions;

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

        [Fact]
        public void Can_reverse_bits()
        {
            0b00000000000000000000000000000011.ReverseBits().Should()
                .Be(unchecked((int) 0b11000000000000000000000000000000));
        }

        [Fact]
        public void Can_swap_numbers()
        {
            int a = 77;
            int b = 88;

            Swap(ref a, ref b);

            a.Should().Be(88);
            b.Should().Be(77);
        }

        [Fact]
        public void Can_distinguish_even_and_odd_numbers()
        {
            3.IsOdd().Should().BeTrue();
            3.IsEven().Should().BeFalse();
            4.IsOdd().Should().BeFalse();
            4.IsEven().Should().BeTrue();
        }

        [Fact]
        public void Can_toggle_right_trailing_zeros()
        {
            0b101000.ToggleRightTrailingZeros().Should().Be(0b101111);
        }

        [Fact]
        public void Can_count_set_bits()
        {
            0b101100.CountSetBits().Should().Be(3);
        }

        [Fact]
        public void Can_unset_rightmost_set_bit()
        {
            0b101100.UnsetRightmostSetBit().Should().Be(0b101000);
        }

        [Fact]
        public void Can_set_rightmost_unset_bit()
        {
            0b101011.SetRightmostUnsetBit().Should().Be(0b101111);
        }

        [Fact]
        public void Can_unset_all_bits_except_rightmost_set_bit()
        {
            0b101010.KeepOnlyRightmostSetBit().Should().Be(0b000010);
        }

        [Fact]
        public void Can_toggle_rightmost_unset_bit_and_unset_all_others()
        {
            0b101011.KeepOnlyRightmostUnsetBitAs1().Should().Be(0b000100);
        }

        [Fact]
        public void Can_set_all_bits_except_rightmost_unset_bit()
        {
            0b101011.KeepOnlyRightmostUnsetBitAs0Rest1().Should()
                .Be(unchecked((int)0b11111111111111111111111111111011));
        }

        [Fact]
        public void Can_unset_part_of_group_of_set_bits_starting_at_index()
        {
            0b000111000111000111000.UnsetAdjacentLeftOnesStartingAt(4).Should().Be(0b000111000111000001000);
        }

        [Fact]
        public void Can_unset_all_bits_except_part_of_group_of_set_bits_starting_at_index()
        {
            0b000111000111000111000.GetAdjacentLeftOnesStartingAt(4).Should().Be(0b000000000000000110000);
        }

        [Fact]
        public void Can_set_part_of_group_of_unset_bits_starting_at_index()
        {
            0b000111000111000111000.SetAdjacentLeftZerosStartingAt(7).Should().Be(0b000111000111110111000);
        }

        [Fact]
        public void Set_all_bits_except_part_of_group_of_unset_bits_starting_at_index()
        {
            0b000111000111000111000.GetAdjacentLeftZerosStartingAtAndRest1(7).Should()
                .Be(unchecked((int)0b11111111111111111111111001111111));
        }

        [Fact]
        public void Can_convert_number_to_its_bits_representation()
        {
            0b01111111111111111111111111111111.ToBitString().Should().Be("01111111111111111111111111111111");
        }
    }
}
