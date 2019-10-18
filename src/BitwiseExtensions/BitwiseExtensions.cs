namespace BitwiseExtensions
{
    public static class BitwiseExtensions
    {
        public static bool IsBitSet(this int number, int index) => (number & (1 << index)) != 0;
        public static int SetBit(this int number, int index)    => number | (1 << index);
        public static int UnsetBit(this int number, int index)  => number & ~(1 << index);
        public static int ToggleBit(this int number, int index) => number ^ (1 << index);
    }
}
