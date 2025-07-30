using System.IO;
namespace LeonardosPrimeFactors
{
    class Result
    {
        /*
         * Complete the 'primeCount' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts LONG_INTEGER n as parameter.
         */
        public static int primeCount(long n)
        {
            if (n == 1)
            {
                return 0;
            }
            List<long> primeList = new List<long> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37,41,43,47 };
            int primeCount = primeList.Count;
            List<long> primorials = new List<long>();
            long primorial = 1;
            foreach (var nextPrime in primeList)
            {
                primorial *= nextPrime;
                primorials.Add(primorial);
            }
            for (int i = primeCount-1; i >= 0; i--)
            {
                long nextPrimorial = primorials[i];
                if (n >= nextPrimorial)
                {
                    return i + 1;
                }
            }
            throw new Exception("Input larger than 47 primorial");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());
            for (int qItr = 0; qItr < q; qItr++)
            {
                long n = Convert.ToInt64(Console.ReadLine().Trim());
                int result = Result.primeCount(n);
                Console.WriteLine(result);
            }
            Console.WriteLine("Hello, World!");
        }
    }
}
