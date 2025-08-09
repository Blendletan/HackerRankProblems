namespace SumDigitTest
{
    using System.Diagnostics;
    using System.Numerics;
    internal class Program
    {
        static void Main(string[] args)
        {
            Int128 numberOfDigits = 10;
            Int128 maxHeight = (Int128)BigInteger.Pow(10, (int)numberOfDigits);
            for (Int128 b = 2; b < 15; b++)
            {
                Int128 maxSumOfDigits = numberOfDigits * b;
                for (Int128 sumOfDigits = 2; sumOfDigits <= maxSumOfDigits; sumOfDigits++)
                {
                    var output = new List<(Int128,Int128)>();
                    var digitsRaisedToPower = sumOfDigits * sumOfDigits;
                    for (Int128 power = 2; digitsRaisedToPower <= maxHeight; power++)
                    {
                        var testDigitSum = SumOfDigits(digitsRaisedToPower,b);
                        if (testDigitSum == sumOfDigits)
                        {
                            output.Add((digitsRaisedToPower,power));
                        }
                        digitsRaisedToPower *= sumOfDigits;
                    }
                    if (output.Count() > 0)
                    {
                        Console.WriteLine($"Multiple solutions for base {b}");
                        foreach (var v in output)
                        {
                            Console.WriteLine($"{v.Item1} sum of digits is {sumOfDigits} with exponent {v.Item2}");
                        }
                    }
                }
            }
            Console.WriteLine("Hello, World!");
        }
        static Int128 SumOfDigits(Int128 n,Int128 b)
        {
            if (n < b)
            {
                return n;
            }
            return n % b + SumOfDigits(n / b, b);
        }
    }
}
