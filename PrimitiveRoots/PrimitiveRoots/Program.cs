namespace PrimitiveRoots
{
    using System.Numerics;
    using System.Diagnostics;
    internal class Program
    {
        static (long,long) PrimitiveRoots(long p)
        {
            long firstRoot = 0;
            List<long> smallPrimes = new List<long> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
            List<long> smallPrimeFactors = new List<long>();
            long numberToFactor = p-1;
            foreach (var nextPrime in smallPrimes)
            {
                if ((p - 1) % nextPrime == 0)
                {
                    numberToFactor /= nextPrime;
                    smallPrimeFactors.Add(nextPrime);
                }
            }
            List<long> primeFactors = PrimeFactors(numberToFactor);
            foreach (var nextPrime in smallPrimeFactors)
            {
                if (primeFactors.Contains(nextPrime) == false)
                {
                    primeFactors.Add(nextPrime);
                }
            }
            for (int i = 2; i < p; i++)
            {
                if (IsRoot(i, p,primeFactors))
                {
                    firstRoot = i;
                    break;
                }
            }
            long numberOfRoots = EulerTotient(p - 1, primeFactors);
            return (firstRoot,numberOfRoots);
        }
        static bool IsRoot(long n, long p,List<long> primeFactors)
        {
            foreach (var nextPrime in primeFactors)
            {
                long exponent = (p - 1) / nextPrime;
                if (BigInteger.ModPow(n, exponent, p) == 1)
                {
                    return false;
                }
            }
            return true;
        }
        static List<long> PrimeFactors(long n)
        {
            List<long> output = new List<long>();
            bool[] isPrime = new bool[n + 1];
            isPrime[0] = false;
            isPrime[1] = false;
            for (int i = 2; i <= n; i++)
            {
                isPrime[i] = true;
            }
            long max = n;
            for (int prime = 2; prime <= max; prime++)
            {
                if (isPrime[prime] == false)
                {
                    continue;
                }
                if (prime == n)
                {
                    output.Add(prime);
                    break;
                }
                for (int composite = 2 * prime; composite <= n; composite += prime)
                {
                    isPrime[composite] = false;
                    if (composite == n)
                    {
                        output.Add((long)prime);
                    }
                }
            }
            return output;
        }
        static long EulerTotient(long n, List<long> primeFactors)
        {
            if (n == 1)
            {
                return 0;
            }
            long output = n;
            foreach (var nextPrime in primeFactors)
            {
                output /= nextPrime;
                output *= (nextPrime - 1);
            }
            return output;
        }
        static void Main(string[] args)
        {
            long p = long.Parse(Console.ReadLine());
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var roots = PrimitiveRoots(p);
            sw.Stop();
            Console.WriteLine($"{roots.Item1} {roots.Item2}");
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine("Hello, World!");
        }
    }
}
