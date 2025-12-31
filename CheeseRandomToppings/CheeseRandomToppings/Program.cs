using System.Numerics;
namespace CheeseRandomToppings
{
    class Result
    {
        List<BigInteger> primes;
        public Result(int maxPrime)
        {
            bool[] isPrime = new bool[maxPrime + 1];
            for (int i = 2; i <= maxPrime; i++)
            {
                isPrime[i] = true;
            }
            for (int prime = 2; prime <= maxPrime; prime++)
            {
                if (isPrime[prime] == false)
                {
                    continue;
                }
                for (int composite = 2 * prime; composite <= maxPrime; composite += prime)
                {
                    isPrime[composite] = false;
                }
            }
            primes = new List<BigInteger>();
            for (int i = 2; i <= maxPrime; i++)
            {
                if (isPrime[i] == false)
                {
                    continue;
                }
                primes.Add(i);
            }
        }
        List<BigInteger> Factor(BigInteger input)
        {
            var output = new List<BigInteger>();
            foreach (var p in primes)
            {
                if (input % p == 0)
                {
                    output.Add(p);
                }
            }
            return output;
        }
        List<BigInteger> GetDigits(BigInteger input, BigInteger numberBase)
        {
            var output = new List<BigInteger>();
            while (input > 0)
            {
                BigInteger nextDigit = (input % numberBase);
                output.Add(nextDigit);
                input /= numberBase;
            }
            return output;
        }
        BigInteger NChooseKModP(BigInteger n, BigInteger k, BigInteger p)
        {
            var nDigits = GetDigits(n, p);
            var kDigits = GetDigits(k, p);
            if (nDigits.Count < kDigits.Count)
            {
                BigInteger toAdd = kDigits.Count - nDigits.Count;
                for (BigInteger i = 0; i < toAdd; i++)
                {
                    nDigits.Add(0);
                }
            }
            if (kDigits.Count < nDigits.Count)
            {
                BigInteger toAdd = nDigits.Count - kDigits.Count;
                for (BigInteger i = 0; i < toAdd; i++)
                {
                    kDigits.Add(0);
                }
            }
            BigInteger output = 1;
            BigInteger length = nDigits.Count;
            for (int i = 0; i < length; i++)
            {
                BigInteger next = NChooseK(nDigits[i], kDigits[i]);
                next = next % p;
                output *= next;
            }
            return output;
        }
        BigInteger NChooseK(BigInteger n, BigInteger k)
        {
            if (k == 0)
            {
                return 1;
            }
            if (n < k)
            {
                return 0;
            }
            BigInteger output = 1;
            for (BigInteger i = n; i > n - k; i--)
            {
                output *= i;
            }
            for (BigInteger i = 2; i <= k; i++)
            {
                output /= i;
            }
            return output;
        }
        BigInteger ChineseRemainderTheorem(List<BigInteger> remainders, List<BigInteger> primes)
        {
            BigInteger product = 1;
            foreach (var v in primes)
            {
                product *= v;
            }
            BigInteger output = 0;
            BigInteger length = remainders.Count;
            for (int i = 0; i < length; i++)
            {
                BigInteger pp = product/ primes[i];
                output += remainders[i] * ModularInverse(pp, primes[i]) * pp;
            }
            return output % product;
        }
        BigInteger ModularInverse(BigInteger input, BigInteger modulus)
        {
            input = input % modulus;
            BigInteger i = modulus;
            BigInteger v = 0;
            BigInteger d = 1;
            while (input > 0)
            {
                BigInteger t = i / input;
                BigInteger x = input;
                input = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= modulus;
            if (v < 0)
            {
                v+=modulus;
            }
            return v;
        }
        public BigInteger Solve(BigInteger n, BigInteger k, BigInteger m)
        {
            var primeFactors = Factor(m);
            var remainders = new List<BigInteger>();
            foreach (var p in primeFactors)
            {
                BigInteger next = NChooseKModP(n, k, p);
                remainders.Add(next);
            }
            BigInteger result = ChineseRemainderTheorem(remainders, primeFactors);
            return result;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            var results = new Result(50);
            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
                int n = Convert.ToInt32(firstMultipleInput[0]);
                int r = Convert.ToInt32(firstMultipleInput[1]);
                int m = Convert.ToInt32(firstMultipleInput[2]);
                BigInteger result = results.Solve(n, r, m);
                Console.WriteLine(result);
            }
        }
    }
}
