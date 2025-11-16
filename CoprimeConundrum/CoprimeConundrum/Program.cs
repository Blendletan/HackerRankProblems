namespace CoprimeConundrum
{
    internal class Program
    {
        public static int NchooseK(int n, int k)
        {
            int output = 1;
            for (int i = n; i > k; i--)
            {
                output *= i;
            }
            for (int i = k; i > 1; i--)
            {
                output /= i;
            }
            return output;
        }
        public static int Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            int[] distinctPrimeFactors = new int[n + 1];
            bool[] isPrime = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
                isPrime[i] = true;
            }
            for (int prime = 2; prime <= n; prime++)
            {
                if (isPrime[prime] == false)
                {
                    continue;
                }
                for (int composite = 2 * prime; composite <= n; composite += prime)
                {
                    isPrime[composite] = false;
                    distinctPrimeFactors[composite]++;
                }
            }
            int output = 0;
            for (int i = 2; i <= n; i++)
            {
                int factorCount = distinctPrimeFactors[i];
                if (factorCount < 2)
                {
                    continue;
                }
                for (int k = 1; k <= factorCount / 2; k++)
                {
                    int toAdd = NchooseK(factorCount, k);
                    if (2 * k == factorCount)
                    {
                        if (k != 1 && k!= 2)
                        {
                            Console.WriteLine();
                        }
                        toAdd /= 2;
                    }
                    output += toAdd;
                }
            }
            Console.WriteLine(output);
        }
    }
}
