namespace LucyAndFlowers
{
    class Result
    {
        long[] catalan;
        List<long>[] binomials;
        const long modulus = 1000000009;
        public Result(int max)
        {
            catalan = new long[max + 1];
            binomials = new List<long>[max + 1];
            catalan[0] = 1;
            binomials[0] = new List<long> { 1 };
            for (int i = 1; i <= max; i++)
            {
                long nextCatalanNumber = 0;
                binomials[i] = new List<long>();
                for (int j = 0; j < i; j++)
                {
                    long nextSummand = catalan[j];
                    nextSummand *= catalan[i - j - 1];
                    nextSummand %= modulus;
                    nextCatalanNumber += nextSummand;
                    nextCatalanNumber %= modulus;
                    long nextBinomial = binomials[i - 1][j];
                    if (j > 0)
                    {
                        nextBinomial += binomials[i - 1][j - 1];
                    }
                    else
                    {
                        nextBinomial += 0;
                    }
                    nextBinomial %= modulus;
                    binomials[i].Add(nextBinomial);
                }
                catalan[i] = (int)nextCatalanNumber;
                binomials[i].Add(1);
            }
        }
        public int Solve(int n)
        {
            long output = 0;
            for (int i = 1; i <= n; i++)
            {
                output += binomials[n][i] * catalan[i];
                output %= modulus;
            }
            return (int)output;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCases = Convert.ToInt32(Console.ReadLine().Trim());
            int[] inputs = new int[numberOfCases];
            int[] outputs = new int[numberOfCases];
            int? maxInput = null;
            for (int i = 0; i < numberOfCases; i++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());
                inputs[i] = n;
                if (maxInput == null)
                {
                    maxInput = n;
                }
                else
                {
                    if (n > maxInput)
                    {
                        maxInput = n;
                    }
                }
            }
            if (maxInput == null)
            {
                throw new Exception("No max value");
            }
            var solver = new Result(maxInput.Value + 1);
            for (int i = 0; i < numberOfCases; i++)
            {
                var result = solver.Solve(inputs[i]);
                outputs[i] = result;
            }
            foreach (var v in outputs)
            {
                Console.WriteLine(v);
            }
        }
    }
}
