namespace GameOfThrones1
{
    class Result
    {

        /*
         * Complete the 'gameOfThrones' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */

        public static string gameOfThrones(string s)
        {
            var frequencyParities = GetLetterParities(s);
            bool output = IsPalindrome(frequencyParities);
            if (output == true)
            {
                return "YES";
            }
            return "NO";
        }
        private static bool IsPalindrome(Dictionary<char, bool> input)
        {
            int numberOfOddLetters = 0;
            foreach (var v in input)
            {
                if (v.Value == false)
                {
                    numberOfOddLetters++;
                    if (numberOfOddLetters > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private static Dictionary<char, bool> GetLetterParities(string input)
        {
            var output = new Dictionary<char, bool>();
            foreach (char c in input)
            {
                if (output.ContainsKey(c) == false)
                {
                    output.Add(c, false);
                }
                else
                {
                    output[c] = !output[c];
                }
            }
            return output;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            string result = Result.gameOfThrones(s);

            Console.WriteLine(result);
        }
    }
}
