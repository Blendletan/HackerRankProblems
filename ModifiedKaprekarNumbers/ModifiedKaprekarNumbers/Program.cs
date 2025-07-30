namespace ModifiedKaprekarNumbers
{
    class Result
    {

        /*
         * Complete the 'kaprekarNumbers' function below.
         *
         * The function accepts following parameters:
         *  1. INTEGER p
         *  2. INTEGER q
         */

        public static void kaprekarNumbers(int p, int q)
        {
            int foundNumbers = 0;
            for (long i = p; i <= q; i++)
            {
                long square = i * i;
                (int, int) halves = SplitInTwo(square);
                int sum = halves.Item1 + halves.Item2;
                if (sum == i)
                {
                    foundNumbers++;
                    Console.Write(i);
                    Console.Write(" ");
                }
            }
            if (foundNumbers == 0)
            {
                Console.WriteLine("INVALID RANGE");
            }
        }
        public static (int, int) SplitInTwo(long input)
        {
            string inputString = input.ToString();
            int length = inputString.Length;
            int leftLength = length / 2;
            char[] left = new char[leftLength];
            int rightLength = leftLength;
            if (2 * leftLength < length)
            {
                rightLength++;
            }
            char[] right = new char[rightLength];
            for (int i = 0; i < leftLength; i++)
            {
                left[i] = inputString[i];
            }
            for (int i = 0; i<rightLength;i++)
            {
                right[i] = inputString[i + leftLength];
            }
            string leftString = new string(left);
            string rightString = new string(right);
            if (leftString.Length == 0)
            {
                leftString = "0";
            }
            return (int.Parse(leftString), int.Parse(rightString));
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int p = Convert.ToInt32(Console.ReadLine().Trim());

            int q = Convert.ToInt32(Console.ReadLine().Trim());

            Result.kaprekarNumbers(p, q);
        }
    }
}
