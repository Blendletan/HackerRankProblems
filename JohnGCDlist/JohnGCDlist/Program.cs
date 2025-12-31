namespace JohnGCDlist
{
    using System.Numerics;
    class Result
    {
        /*
         * Complete the 'solve' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts INTEGER_ARRAY a as parameter.
         */
        public static List<int> solve(List<int> a)
        {
            var output = new List<int>();
            int length = a.Count;
            output.Add(a[0]);
            for (int i = 1; i < length; i++)
            {
                int next = output.Last() * a[i];
                int gcd = (int)BigInteger.GreatestCommonDivisor(output.Last(), a[i]);
                next /= gcd;
                output.Add(next);
            }
            output.Add(a.Last());
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
                int aCount = Convert.ToInt32(Console.ReadLine().Trim());
                List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();
                List<int> result = Result.solve(a);
                Console.WriteLine(String.Join(" ", result));
            }
        }
    }
}
