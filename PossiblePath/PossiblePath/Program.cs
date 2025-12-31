namespace PossiblePath
{
    using System.Numerics;
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTestCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfTestCases; i++)
            {
                var inputs = Console.ReadLine().Split();
                int a = int.Parse(inputs[0]);
                int b = int.Parse(inputs[1]);
                int c = int.Parse(inputs[2]);
                int d = int.Parse(inputs[3]);
                Console.WriteLine(Solve(a, b, c, d));
            }
        }
        static string Solve(int a, int b, int c, int d)
        {
            var gcd = BigInteger.GreatestCommonDivisor(a, b);
            if (gcd == BigInteger.GreatestCommonDivisor(c, d))
            {
                return "YES";
            }
            return "NO";
        }
    }
}
