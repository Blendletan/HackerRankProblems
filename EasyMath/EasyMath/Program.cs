using System.IO;
using System.Numerics;
using System.Text;
namespace EasyMath
{
    class Result
    {
        /*
         * Complete the 'solve' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER x as parameter.
         */
        public static long Solve(long input)
        {
            long powersOfTwo = NumberOfPowers(input, 2);
            long powersOfFive = NumberOfPowers(input, 5);
            long reducedInput = input;
            for (int i = 0; i < powersOfTwo; i++)
            {
                reducedInput /= 2;
            }
            for (int i = 0; i < powersOfFive; i++)
            {
                reducedInput /= 5;
            }
            long numberOfFours = NumberOfFoursToMakeDivisible(reducedInput);
            long numberOfZeros = NumberOfZerosToMakeDivisible(powersOfTwo, powersOfFive);
            return 2 * numberOfFours + numberOfZeros;
            /*
            BigInteger remainderWithoutZeros = 4 % x;
            for (int numberOfFours = 1; numberOfFours < 50000; numberOfFours++)
            {
                if (numberOfFours > 1)
                {
                    remainderWithoutZeros *= 10;
                    remainderWithoutZeros += 4;
                    remainderWithoutZeros %= x;
                }
                BigInteger remainderWithZeros = remainderWithoutZeros;
                for (int numberOfZeros = 0; numberOfZeros < 50000; numberOfZeros++)
                {
                    if (numberOfZeros > 0)
                    {
                        remainderWithZeros *= 10;
                        remainderWithZeros %= x;
                    }
                    if (remainderWithZeros == 0)
                    {
                        long output = 2 * numberOfFours + numberOfZeros;
                        return output;
                    }
                }
            }
            return -1;
            */
        }
        public static long NumberOfPowers(long input, long factor)
        {
            long output = 0;
            while (input % factor == 0)
            {
                output++;
                input /= factor;
            }
            return output;
        }
        public static long NumberOfZerosToMakeDivisible(long powersOfTwo,long powersOfFive)
        {
            long output = Math.Max(powersOfFive,powersOfTwo-2);
            return output;
        }
        public static long NumberOfFoursToMakeDivisible(long input)
        {
            long remainder = 4;
            remainder %= input;
            long output = 1;
            while (remainder != 0)
            {
                remainder *= 10;
                remainder += 4;
                remainder %= input;
                output++;
            }
            return output;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int tItr = 0; tItr < t; tItr++)
            {
                long x = Convert.ToInt64(Console.ReadLine().Trim());
                long result = Result.Solve(x);
                Console.WriteLine(result);
            }
        }
    }
}
