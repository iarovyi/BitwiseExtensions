namespace BitwiseExtensions
{
    internal static class AlternativeImplementations
    {
        private const int MinInt = unchecked((int)0b10000000000000000000000000000000);
        private const int MaxInt =                0b01111111111111111111111111111111;
        public static int ToggleBitsIncludingSignBit(this int number) => ~number;
        public static int ToggleBitsExceptSignBit(this int number) => number ^ MaxInt;
        public static int Negate(this int number) => ~number + 1; //In two's complement system (like int,long in C#)

        public static string ToBitString(int number)
        {
            char[] b = new char[32];
            int pos = 31;
            int i = 0;

            while (i < 32)
            {
                if ((number & (1 << i)) != 0)
                    b[pos] = '1';
                else
                    b[pos] = '0';
                pos--;
                i++;
            }
            return new string(b);
        }
    }
}
