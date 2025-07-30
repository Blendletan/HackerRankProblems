namespace NumberGroups
{
    class Result
    {
        /*
         * Complete the 'sumOfGroup' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts INTEGER k as parameter.
         */
        public static long sumOfGroup(int k)
        {
            // Return the sum of the elements of the k'th group.
            long m = StartOfGroup(k);
            long l = (long)k;
            return l * m + l * (l - 1);
        }
        private static long StartOfGroup(int k)
        {
            long l = (long)k;
            return l * (l - 1) + 1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = Convert.ToInt32(Console.ReadLine().Trim());
            long answer = Result.sumOfGroup(k);
            Console.WriteLine(answer);
            Console.WriteLine("Hello, World!");
        }
    }
}
