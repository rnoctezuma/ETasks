using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._4.NumberArraySum
{
    public static class NumberArrayExtension
    {
        public static byte Sum(this byte[] array)   ////byte
        {
            byte result = 0;
            foreach (var item in array)
            {
                result += item;
            }
            return result;
        }

        public static sbyte Sum(this sbyte[] array)   ////sbyte
        {
            sbyte result = 0;
            foreach (var item in array)
            {
                result += item;
            }
            return result;
        }

        public static int Sum(this int[] array)   ////int
        {
            int result = 0;
            foreach (var item in array)
            {
                result += item;
            }
            return result;
        }

        public static uint Sum(this uint[] array)   ////uint
        {
            uint result = 0;
            foreach (var item in array)
            {
                result += item;
            }
            return result;
        }

        public static short Sum(this short[] array)   ////short
        {
            short result = 0;
            foreach (var item in array)
            {
                result += item;
            }
            return result;
        }

        public static ushort Sum(this ushort[] array)   ////ushort
        {
            ushort result = 0;
            foreach (var item in array)
            {
                result += item;
            }
            return result;
        }

        public static long Sum(this long[] array)   ////long
        {
            long result = 0;
            foreach (var item in array)
            {
                result += item;
            }
            return result;
        }

        public static ulong Sum(this ulong[] array)   ////ulong
        {
            ulong result = 0;
            foreach (var item in array)
            {
                result += item;
            }
            return result;
        }

        public static float Sum(this float[] array)   ////float
        {
            float result = 0;
            foreach (var item in array)
            {
                result += item;
            }
            return result;
        }

        public static double Sum(this double[] array)   ////double
        {
            double result = 0;
            foreach (var item in array)
            {
                result += item;
            }
            return result;
        }

        public static decimal Sum(this decimal[] array)   ////decimal
        {
            decimal result = 0;
            foreach (var item in array)
            {
                result += item;
            }
            return result;
        }
    }
}