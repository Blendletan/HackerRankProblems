using System.IO;
using System.Numerics;
namespace FibonacciFinding
{
    class MyMatrix
    {
        public readonly long a;
        public readonly long b;
        public readonly long c;
        public readonly long d;
        const long modulus = 1000000007;
        public MyMatrix(long a, long b, long c, long d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }
        public static MyMatrix Multiply(MyMatrix m1, MyMatrix m2)
        {
            long a = m1.a * m2.a + m1.b * m2.c;
            long b = m1.a * m2.b + m1.b * m2.d;
            long c = m1.c * m2.a + m1.d * m2.c;
            long d = m1.c * m2.b + m1.d * m2.d;
            return new MyMatrix(a % modulus, b % modulus, c % modulus, d % modulus);
        }
        public static MyMatrix Pow(MyMatrix matrix, int n,Dictionary<int,MyMatrix> cache)
        {
            if (n == 0)
            {
                return new MyMatrix(1, 0, 0, 1);
            }
            if (n == 1)
            {
                return matrix;
            }
            MyMatrix halfPower;
            if (cache.ContainsKey(n / 2))
            {
                halfPower = cache[n / 2];
            }
            else
            {
                halfPower = Pow(matrix, n / 2,cache);
                cache.Add(n / 2, halfPower);
            }
            MyMatrix output = Multiply(halfPower, halfPower);
            if (int.IsEvenInteger(n))
            {
                return output;
            }
            return Multiply(matrix, output);
        }
    }
    class Result
    {
        /*
         * Complete the 'solve' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER a
         *  2. INTEGER b
         *  3. INTEGER n
         */
        public static int solve(int a, int b, int n)
        {
            long modulus = 1000000007;
            var fib = new MyMatrix(1, 1, 1, 0);
            var fibPower = MyMatrix.Pow(fib, n - 1,new Dictionary<int,MyMatrix>());
            long output = b * fibPower.a + a * fibPower.b;
            return (int)(output % modulus);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
                int a = Convert.ToInt32(firstMultipleInput[0]);
                int b = Convert.ToInt32(firstMultipleInput[1]);
                int n = Convert.ToInt32(firstMultipleInput[2]);
                int result = Result.solve(a, b, n);
                Console.WriteLine(result);
            }
        }
    }
}
