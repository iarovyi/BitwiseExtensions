﻿namespace BitwiseExtensions
{
    using System;

    internal static class AlternativeImplementations
    {
        #region Math Operations
        public static int Negate(this int number) => ~number + 1; //In two's complement system (like int,long in C#)

        public static int Add(this int x, int y)
        {
            /*
               https://www.geeksforgeeks.org/add-two-numbers-without-using-arithmetic-operators/
               Algorithm:
               The basic add operation is an XOR. That deals with every case except the columns with two 1s,
               because 1+1=10. You can figure out which columns those are with an AND operator.
               Shift that over (Java <<). Now you can repeat the process: add in the carries, 
               figure out what the new carries are. Keep going until you reach no more carries.
               We operate on all positions each iteration and not like in math when one place at a time.

               while (there is a carry) {
                    find bits that needs to be carried left (&: 1 + 1 = 10. Only when 1 and 1 than it needs to be carried)
                    apply actual addition                   (^: only if one of bits is 1 than at that position 1 will stay)
                    move carry one position left            (<<)
                    assign shifted carry to y               (=)
               }
                   x                                 x
                 & y                               ^ y
                   -                                 -
                   <common bits> -> carry --> y      <different bits> --> x
                    000111     000101
                x = 000111 y = 000101 & =000101 ^ = 000010 carry = 000101 <<carry = 001010 ==> x = 000010(different bits) y = 001010(common bits shifted)
                x = 000010 y = 001010 & =000010 ^ = 001000 carry = 000010 <<carry = 000100 ==> x = 001000(different bits) y = 000100(common bits shifted)
                x = 001000 y = 000100 & =000000 ^ = 001100 carry = 000000 <<carry = 000000 ==> x = 001100(different bits) y = 000000(common bits shifted)
                                                                                                   001100
                 Recursively x ^ y, (x & y) << 1
             */
            // Iterate till there is no carry
            while (y != 0)
            {
                // carry now contains common 
                // set bits of x and y ==> so these bits should be carried
                int carry = x & y;

                // Sum of bits of x and  
                // y where at least one  
                // of the bits is not set 
                //If x and y don’t have set bits at same position(s), then bitwise XOR (^) of x and y gives the sum of x and y
                x = x ^ y;

                // Carry is shifted by  
                // one so that adding it  
                // to x gives the required sum 
                y = carry << 1;
            }
            return x;

            /* Recursive form
            if (y == 0)
            {
                return x;
            }

            return Add(x ^ y, (x & y) << 1);*/
        }

        public static int Subtract(this int x, int y)
        {
            //https://www.geeksforgeeks.org/subtract-two-numbers-without-using-arithmetic-operators/
            /*
               It turns out that "subtract" is just a special kind of "add" -- specifically, 
               "subtract" is an "add" of a negative number. So all you have to do is figure out
               how to make the negative of a number using bitwise operators and "subtract" is done.
             */
            while (y != 0)
            {
                int borrow = (~x) & y; //~ is the only difference comparing to addition
                x = x ^ y;
                y = borrow << 1;
            }

            return x;

            /*Recursive version:
            if (y == 0)
            {
                return x;
            }

            return Subtract(x ^ y, (~x & y) << 1);*/
        }

        public static int Multiply(this int number, int multiplier)
        {
            //https://www.geeksforgeeks.org/multiplication-two-numbers-shift-operator/
            int answer = 0, count = 0;
            while (multiplier > 0)
            {
                // check for set bit and left  
                // shift number, count times 
                if (multiplier % 2 == 1)       //If odd (will execute always: for odd and for 1 with even multiplier)
                {
                    answer += number << count; //Multiply by 2 in power of count    <---------------
                }                              //                                                  |
                // increment of place                                                              |
                // value (count)                                                                   |
                count++;                       //Count how many 2s in multiplier so than later we can 
                multiplier /= 2;
            }

            return answer;
        }

        public static int Divide(this int dividend, int divisor)
        {
            /*
               https://www.geeksforgeeks.org/divide-two-integers-without-using-multiplication-division-mod-operator/
               https://en.wikipedia.org/wiki/Long_division

               dividend = quotient * divisor + remainder

             */
            if (divisor == 0 || (dividend == int.MinValue && divisor == -1)) //edge case
            {
                return int.MaxValue;
            }

            long x = Math.Abs((long)dividend);
            long y = Math.Abs((long)divisor);
            long result = 0;

            while (x >= y)
            {
                long temp = y, multiple = 1;

                while (x >= (temp << 1))
                {
                    temp <<= 1;
                    multiple <<= 1;
                }

                x -= temp;
                result += multiple;
            }

            if (dividend.HasDifferentSignThan(divisor))
            {
                result = -result;
            }

            return (result > int.MaxValue || result < int.MinValue) ? int.MaxValue : (int)result;
        }
        #endregion

        #region Contants
        private const int MinInt = unchecked((int)0b10000000000000000000000000000000);
        private const int MaxInt =                0b01111111111111111111111111111111;
        //It is the first 10-digit prime number and fits in int data type https://www.geeksforgeeks.org/modulo-1097-1000000007/
        private const long Modulo = (long)(1e9 + 7);//1000000007  10^9+7
        #endregion

        public static long ClampByBigPrimeNumber(this long number) => number % Modulo;
        public static int ToggleBitsIncludingSignBit(this int number) => ~number;
        public static int ToggleBitsExceptSignBit(this int number) => number ^ MaxInt;

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

        public static bool HasDifferentSignThan(this int number, int anotherNumber) =>
            number < 0 ^ anotherNumber < 0;
    }
}
