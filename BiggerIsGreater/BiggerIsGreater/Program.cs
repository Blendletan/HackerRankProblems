using System.IO;
namespace BiggerIsGreater
{
    class Result
    {
        /*
         * Complete the 'biggerIsGreater' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING w as parameter.
         */
        public static string biggerIsGreater(string w)
        {
            char[] letters = w.ToCharArray();
            int? pivotIndex = FindPivot(letters);
            if (pivotIndex == null)
            {
                return "no answer";
            }
            int successor = FindSuccessor(letters, pivotIndex.Value);
            char temp = letters[pivotIndex.Value];
            letters[pivotIndex.Value] = letters[successor];
            letters[successor] = temp;
            Array.Reverse(letters, pivotIndex.Value+1, letters.Length - pivotIndex.Value-1);
            return new string(letters);
        }
        private static int? FindPivot(char[] array)
        {
            int length = array.Length;
            for (int i = length - 2; i >= 0; i--)
            {
                if (array[i] < array[i + 1])
                {
                    return i;
                }
            }
            return null;
        }
        private static int FindSuccessor(char[] array,int pivotIndex)
        {
            int length = array.Length;
            for (int i = length-1; i > pivotIndex; i--)
            {
                if (array[i] > array[pivotIndex])
                {
                    return i;
                }
            }
            throw new Exception("Couldn't find successor");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int T = Convert.ToInt32(Console.ReadLine().Trim());
            for (int TItr = 0; TItr < T; TItr++)
            {
                string w = Console.ReadLine();
                string result = Result.biggerIsGreater(w);
                Console.WriteLine(result);
            }
            Console.WriteLine("Hello, World!");
        }
    }
}
