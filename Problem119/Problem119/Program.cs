namespace Problem119
{
    using System.Diagnostics;
    using System.Numerics;
    internal class DigitSumPower
    {
        readonly bool debug;
        readonly BigInteger[] digitSumCache;
        readonly int b;
        readonly int numberOfDigitsCached;
        readonly int maxNumberInCache;
        public bool SumOfDigitsMatches(BigInteger n,long target)
        {
            BigInteger sumOfDigits = digitSumCache[(int)(n % maxNumberInCache)];
            if (sumOfDigits > target)
            {
                return false;
            }
            while (n >= maxNumberInCache)
            {
                n /= maxNumberInCache;
                sumOfDigits += digitSumCache[(int)(n % maxNumberInCache)];
                if (sumOfDigits > target)
                {
                    return false;
                }
            }
            if (sumOfDigits == target)
            {
                return true;
            }
            return false;
        }
        public List<BigInteger> FindSolutions(int maxNumberOfDigits)
        {
            var output = new List<BigInteger>();
            long maxSumOfDigits = maxNumberOfDigits * b;
            BigInteger maxHeight = BigInteger.Pow(10, maxNumberOfDigits);
            for (long sumOfDigits = 2; sumOfDigits <= maxSumOfDigits; sumOfDigits++)
            {
                BigInteger digitsRaisedToPower = sumOfDigits * sumOfDigits;
                for (int power = 2; digitsRaisedToPower <= maxHeight; power++)
                {
                    if (SumOfDigitsMatches(digitsRaisedToPower,sumOfDigits))
                    {
                        output.Add(digitsRaisedToPower);
                    }
                    digitsRaisedToPower *= sumOfDigits;
                }
            }
            return output;
        }
        public DigitSumPower(int numberOfDigitsCached, int b, bool debug)
        {
            this.debug = debug;
            this.b = b;
            this.numberOfDigitsCached = numberOfDigitsCached;
            maxNumberInCache = (int)Math.Pow(b, numberOfDigitsCached);
            digitSumCache = new BigInteger[maxNumberInCache];
            for (int decimalPlace = 0; decimalPlace < numberOfDigitsCached; decimalPlace++)
            {
                int previousMax = (int)Math.Pow(b, decimalPlace);
                for (int currentDigit = 0; currentDigit < b; currentDigit++)
                {
                    if (currentDigit == 0 && decimalPlace != 0)
                    {
                        continue;
                    }
                    for (int previousNumber = 0; previousNumber < previousMax; previousNumber++)
                    {
                        int currentNumber = previousNumber + previousMax * currentDigit;
                        digitSumCache[currentNumber] = digitSumCache[previousNumber] + currentDigit;
                    }
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            bool debug = true;
            Stopwatch sw = new Stopwatch();
            int b = int.Parse(Console.ReadLine());
            sw.Start();
            int maxNumberOfDigits = 100;
            var solver = new DigitSumPower(2, b, debug);
            var result = solver.FindSolutions(maxNumberOfDigits);
            result.Sort();
            sw.Stop();
            foreach (var v in result)
            {
                Console.Write($"{v} ");
            }
            if (debug)
            {
                Console.WriteLine();
                Console.WriteLine(sw.Elapsed);
            }
        }
    }
}
