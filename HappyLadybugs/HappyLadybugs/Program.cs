namespace HappyLadybugs
{
    class Result
    {

        /*
         * Complete the 'happyLadybugs' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING b as parameter.
         */

        public static string happyLadybugs(string b)
        {
            if (IsAlreadyValid(b))
            {
                return "YES";
            }
            var frequencies = LetterFrequency(b);
            int numberOfSingletons = 0;
            int numberOfBlanks = 0;
            foreach (var v in frequencies)
            {
                if (v.Key != '_' && v.Value == 1)
                {
                    numberOfSingletons++;
                }
                if (v.Key == '_')
                {
                    numberOfBlanks++;
                }
            }
            if (numberOfSingletons > 0)
            {
                return "NO";
            }
            if (numberOfBlanks == 0)
            {
                return "NO";
            }
            return "YES";
        }
        private static bool IsAlreadyValid(string input)
        {
            int length = input.Length;
            if (length == 1)
            {
                if (input[0] == '_')
                {
                    return true;
                }
                return false;
            }
            if (input[0] != input[1])
            {
                return false;
            }
            for (int i = 1; i < length-1; i++)
            {
                if (input[i] != input[i - 1])
                {
                    if (input[i] != input[i + 1])
                    {
                        return false;
                    }
                }
            }
            if (input[length - 2] != input[length - 1])
            {
                return false;
            }
            return true;
        }
        private static Dictionary<char, int> LetterFrequency(string input)
        {
            var output = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (output.ContainsKey(c) == false)
                {
                    output.Add(c, 0);
                }
                output[c]++;
            }
            return output;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            int g = Convert.ToInt32(Console.ReadLine().Trim());

            for (int gItr = 0; gItr < g; gItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                string b = Console.ReadLine();

                string result = Result.happyLadybugs(b);

                Console.WriteLine(result);
            }
        }
    }
}
