namespace ComputingPowers
{
    using System.Numerics;
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxExponent = 2;
            int maxBase = 1000;
            bool[] isPrime = new bool[maxBase + 1];
            BigInteger[,] powers = new BigInteger[maxBase + 1, maxExponent + 1];
            for (int i = 2; i <= maxBase; i++)
            {
                isPrime[i] = true;
                for (int j = 1; j <= maxExponent; j++)
                {
                    powers[i, j] = 1;
                }
            }
            for (int prime = 2; prime <= maxBase; prime++)
            {
                if (isPrime[prime] == false)
                {
                    continue;
                }
                for (int primeExponent = 1; primeExponent <= maxExponent; primeExponent++)
                {
                    BigInteger primePower = BigInteger.Pow(prime, primeExponent);
                    powers[prime, primeExponent] = primePower;

                }
            }



            Console.WriteLine("Hello, World!");
        }
    }
}
