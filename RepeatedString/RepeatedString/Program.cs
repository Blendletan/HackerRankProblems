using System.IO;
using System.Runtime.InteropServices;

namespace RepeatedString
{
    class Result
    {

        /*
         * Complete the 'repeatedString' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts following parameters:
         *  1. STRING s
         *  2. LONG_INTEGER n
         */

        public static long repeatedString(string s, long n)
        {
            long length = s.Length;
            long numberOfRepitions = n / length;
            int remainder = (int)(n % length);
            long totalOccurences = 0;
            for (int i = 0; i < remainder; i++)
            {
                if (s[i] == 'a')
                {
                    totalOccurences++;
                }
            }
            long occurencesInRemainder = totalOccurences;
            for (int i = remainder; i < length; i++)
            {
                if (s[i] == 'a')
                {
                    totalOccurences++;
                }
            }
            return numberOfRepitions * totalOccurences + occurencesInRemainder;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            string s = Console.ReadLine();

            long n = Convert.ToInt64(Console.ReadLine().Trim());

            long result = Result.repeatedString(s, n);

            Console.WriteLine(result);
        }
    }
}
