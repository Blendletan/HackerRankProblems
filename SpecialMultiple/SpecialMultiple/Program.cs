namespace SpecialMultiple
{
    using System.Numerics;
    using System.Diagnostics;
    class Solver
    {
        const int maximumNumberOfDigits = 12;
        private List<long> validIntegers;
        public Solver(int max)
        {
            int maxHeight = (int)Math.Pow(2, maximumNumberOfDigits + 1);
            validIntegers = new List<long>();
            for (int i = 1; i < maxHeight; i++)
            {
                char[] binaryDigits = Convert.ToString(i, 2).ToCharArray();
                int length = binaryDigits.Length;
                for (int j = 0; j < length; j++)
                {
                    if (binaryDigits[j] == '1')
                    {
                        binaryDigits[j] = '9';
                    }
                }
                long nextInt = long.Parse(new string(binaryDigits));
                validIntegers.Add(nextInt);
            }
        }
        public string Solve(int n)
        {
            foreach (var v in validIntegers)
            {
                if (v == 0)
                {
                    continue;
                }
                if (v % n == 0)
                {
                    return v.ToString();
                }
            }
            throw new Exception("Solution not found");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTestCases = Convert.ToInt32(Console.ReadLine().Trim());
            int[] inputs = new int[numberOfTestCases];
            string[] outputs = new string[numberOfTestCases];
            int max = 0;
            for (int i = 0; i < numberOfTestCases; i++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());
                if (max < n)
                {
                    max = n;
                }
                inputs[i] = n;
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Solver s = new Solver(max);
            for (int i = 0; i < numberOfTestCases; i++)
            {
                int v = inputs[i];
                outputs[i] = s.Solve(v);
            }
            sw.Stop();
            foreach (var v in outputs)
            {
                Console.WriteLine(v);
            }
        }
    }
}
