namespace Problem103
{
    using System.Diagnostics;
    internal class Program
    {
        const int modulus = 715827881;
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var output = SpecialSubsetSum(input);
            sw.Stop();
            foreach (var v in output)
            {
                Console.Write($"{v} ");
            }
            Console.WriteLine();
            Console.WriteLine(sw.Elapsed);
        }
        static List<long> SpecialSubsetSum(int n)
        {
            var output = new List<long> { 1 };
            if (n == 1)
            {
                return output;
            }
            using (var debugWriter = new StreamWriter("debug.txt"))
            {
                for (int i = 2; i <= n; i++)
                {
                    NextSubset(output, i, debugWriter);
                }
            }
            return output;
        }
        static void NextSubset(List<long> subset,int n,StreamWriter debugWriter)
        {
            long first = subset[(n-1)/ 2];
            debugWriter.WriteLine(first);
            for (int i = 0; i < n - 1; i++)
            {
                subset[i] += first;
                subset[i] = subset[i] % modulus;
            }
            subset.Insert(0, first);
        }
    }
}
