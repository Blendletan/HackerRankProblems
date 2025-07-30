using System;

namespace PalindromeIndex
{
    class Result
    {

        /*
         * Complete the 'palindromeIndex' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts STRING s as parameter.
         */
        public static Dictionary<char, List<int>> CharFrequencies(string s)
        {
            var output = new Dictionary<char, List<int>>();
            int length = s.Length;
            for (int i = 0; i < length; i++)
            {
                char c = s[i];
                if (output.ContainsKey(c) == false)
                {
                    output.Add(c,new List<int>());
                }
                output[c].Add(i);
            }
            return output;
        }
        public static int TestPalindromeIndex(string s)
        {
            if (IsPalindrome(s))
            {
                return -1;
            }
            var frequencies = CharFrequencies(s);
            var possibleOutput = new List<int>();
            var oddFrequencies = new List<char>();
            bool stringLengthIsEven = int.IsEvenInteger(s.Length);
            foreach (var v in frequencies)
            {
                if (int.IsEvenInteger(v.Value.Count) == false)
                {
                    oddFrequencies.Add(v.Key);
                }
            }
            if (stringLengthIsEven==false)
            {
                if (oddFrequencies.Count != 1)
                {
                    return -1;
                }
                char oddLetter = oddFrequencies.First();
                foreach (int index in frequencies[oddLetter])
                {
                    string possiblePalindrome = RemoveLetter(s, index);
                    if (IsPalindrome(possiblePalindrome))
                    {
                        return index;
                    }
                }
                return -1;
            }
            if (oddFrequencies.Count != 0)
            {
                if (oddFrequencies.Count != 2)
                {
                    return -1;
                }
                char c1 = oddFrequencies[0];
                char c2 = oddFrequencies[1];
                if (frequencies[c1].Count != 1 && frequencies[c2].Count != 1)
                {
                    return -1;
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                string possiblePalindrome = RemoveLetter(s, i);
                if (IsPalindrome(possiblePalindrome))
                {
                    return i;
                }
            }
            return -1;
        }
        static string RemoveLetter(string s, int index)
        {
            char[] output = new char[s.Length - 1];
            for (int i = 0; i < index; i++)
            {
                output[i] = s[i];
            }
            if (index < s.Length - 1)
            {
                for (int i = index + 1; i < s.Length; i++)
                {
                    output[i - 1] = s[i];
                }
            }
            return new string(output);
        }
        static bool IsPalindrome(string s)
        {
            int mid = s.Length / 2;
            for (int i = 0; i <= mid; i++)
            {
                if (s[i] != s[ComplimentaryIndex(s, i)])
                {
                    return false;
                }
            }
            return true;
        }

        public static int palindromeIndex(string s)
        {
            int maxIndex = s.Length/2;
            var outputs = new SortedSet<int>();
            for (int i = maxIndex; i >= 0; i--)
            {
                int i2 = ComplimentaryIndex(s, i);
                char c1 = s[i];
                char c2 = s[i2];
                if (c1 != c2)
                {
                    if (s[i + 1] == c2)
                    {
                        outputs.Add(i);
                    }
                    else if (c1 == s[i2 - 1])
                    {
                        outputs.Add(i2);
                    }
                }
            }
            int outputSize = outputs.Count;
            if (outputs.Count==0)
            {
                return -1;
            }
            return outputs.Min();
        }
        public static int ComplimentaryIndex(string s, int index)
        {
            return s.Length - index - 1;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = Result.TestPalindromeIndex(s);

                Console.WriteLine(result);
            }
        }
    }
}
