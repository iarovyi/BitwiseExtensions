namespace BitwiseExtensions
{
    using System;

    /// <summary>
    /// Sources:
    ///  - Hacker's Delight 1st Edition - book about bit hacks
    ///  - https://catonmat.net/low-level-bit-hacks
    /// </summary>
    public static class BitwiseExtensions
    {
        public static bool IsBitSet(this int number, int index) => (number & (1 << index)) != 0;
        public static int SetBit(this int number, int index)    => number | (1 << index);
        public static int UnsetBit(this int number, int index)  => number & ~(1 << index);
        public static int ToggleBit(this int number, int index) => number ^ (1 << index);
        public static bool IsEven(this int number)              => (number & 1) == 0;
        public static bool IsOdd(this int number)               => (number & 1) == 1;

        #region Tricks
        public static int ToggleRightTrailingZeros(this int number) => number | (number - 1);

        public static int CountSetBits(this long number)
        {
            int setBitsCount = 0;
            while (number > 0)
            {
                setBitsCount += (int)(number & 1);
                number >>= 1;
            }
            return setBitsCount;
        }

        #region Rightmost bit
        /*
              01010111 (x)      01011000 (x)
            & 01010110 (x-1)  & 01010111 (x-1)
              --------          --------
              01010110          01010000
              Subtracting 1 will underflow so all "0" after it will become "1" and last "1" will become "0"
              So it will be:    <unchanged part> 1 <zeros>
                              & <unchanged part> 0 <ones>
                                -------------------------
                                <unchanged part> 0 <zeros>
         */
        public static int UnsetRightmostSetBit(this int number) => number & (number - 1);

        /*
            x | (x + 1) = x with the lowest cleared bit set.
            1)  01110111   2)    01110111  (x)        <unchanged part> 0 <unchanged part> (x)
              + 00000001      |  01111000  (x+1)    | <unchanged part> 1 <zeros>          (x +1)
                --------         --------             --------------------------
                01111000         01111111             <unchanged part> 1 <unchanged part>
         */
        public static int SetRightmostUnsetBit(this int number) => number | (number + 1);

        /*
           -x=~x+1 (in "Two's Complement" system)
        1)              2)  01000011   3)   10111100               
           ~ 10111100     + 00000001      & 01000100  (-x or ~x+1)    
             --------       --------        --------                  
             01000011       01000100        00000100  
            Adding one makes them carry this one all the way to bit 1, which is the first zero bit. 

               <unchanged part> 1 <zeros>
             & <toggled part>   1 <zeros>
               --------------------------
               <zeros>          1 <zeros>
         */
        public static int KeepOnlyRightmostSetBit(this int number) => number & (-number); //number & ~(number - 1);

        /*
        01110111  (x)           10111100  (x)
        --------                --------
        10001000  (~x)          01000011  (~x)
    &   01111000  (x+1)     &   10111101  (x+1)
        --------                --------
        00001000                00000001
        */
        public static int KeepOnlyRightmostUnsetBitAs1(this int number) => ~number & (number + 1);

        //x | ~(x + 1) = extracts the lowest cleared bit of x (all others are set).
        public static int KeepOnlyRightmostUnsetBitAs0Rest1(this int number) => number | ~(number + 1);

        /*
            1) 10111100  2)  10111100  (x)         <unchanged> 1 <zeros>
             - 00000001    | 10111011  (x-1)     | <unchanged> 0 <ones>
               --------      --------              ---------------------
               10111011      10111111              <unchanged> 1 <ones>
         */
        #endregion

        #region Runs - group of adjacent 1 or 0
        // x & (x + (1 << n)) = x, with the run of set bits (possibly length 0) starting at bit n cleared.
        // 0b0101110111 and 1 => 0b0101110(00)1
        public static int UnsetAdjacentLeftOnesStartingAt(this int number, int index) => number & (number + (1 << index));

        //x & ~(x + (1 << n)) = the run of set bits (possibly length 0) in x, starting at bit n.
        // 0b0101110111 and 5 => 0b0001100000
        public static int GetAdjacentLeftOnesStartingAt(this int number, int index) => number & ~(number + (1 << index));

        //x | (x - (1 << n)) = x, with the run of cleared bits (possibly length 0) starting at bit n set.
        public static int SetAdjacentLeftZerosStartingAt(this int number, int index) => number | (number - (1 << index));

        //x | ~(x - (1 << n)) = the lowest run of cleared bits (possibly length 0) in x, starting at bit n are the only clear bits.
        public static int GetAdjacentLeftZerosStartingAtAndRest1(this int number, int index) => number | ~(number - (1 << index));
        #endregion
        #endregion

        public static string ToBitString(this long number) =>
            Convert.ToString(number, 2).PadLeft(64, '0');

        public static string ToBitString(this int number) =>
            Convert.ToString(number, 2).PadLeft(32, '0');
    }
}
