using System.IO;
namespace AppendAndDelete
{
    class Result
    {

        /*
         * Complete the 'appendAndDelete' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts following parameters:
         *  1. STRING s
         *  2. STRING t
         *  3. INTEGER k
         */
        static int FirstDifferingIndex(string s1, string s2)
        {
            int length = s1.Length;
            for (int i = 0; i < length; i++)
            {
                if (i >= s2.Length)
                {
                    return i;
                }
                if (s1[i] != s2[i])
                {
                    return i;
                }
            }
            return length;
        }
        public static string appendAndDelete(string s, string t, int k)
        {
            if (k > s.Length + t.Length)
            {
                return "Yes";
            }
            int differingIndex = FirstDifferingIndex(s, t);
            int numberOfLettersToRemove = s.Length - differingIndex;
            int numberOfLettersToAdd = t.Length - differingIndex;
            int numberOfOperations = numberOfLettersToRemove + numberOfLettersToAdd;
            if (numberOfOperations > k)
            {
                return "No";
            }
            if (numberOfOperations == k)
            {
                return "Yes";
            }
            int extraOperations = k - numberOfOperations;
            if (int.IsEvenInteger(extraOperations))
            {
                return "Yes";
            }
            return "No";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string t = Console.ReadLine();
            int k = Convert.ToInt32(Console.ReadLine().Trim());
            string result = Result.appendAndDelete(s, t, k);
            Console.WriteLine(result);
        }
    }
}
