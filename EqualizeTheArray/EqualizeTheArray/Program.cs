namespace EqualizeTheArray
{
    class Result
    {
        /*
         * Complete the 'equalizeArray' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */
        public static int equalizeArray(List<int> arr)
        {
            var dictionary = new Dictionary<int, int>();
            foreach (int i in arr)
            {
                if (dictionary.ContainsKey(i) == false)
                {
                    dictionary.Add(i, 0);
                }
                dictionary[i]++;
            }
            int? currentMax = null;
            int? maxValue = null;
            foreach (var v in dictionary)
            {
                if (currentMax == null)
                {
                    currentMax = v.Value;
                    maxValue = v.Key;
                }
                else
                {
                    if (v.Value > currentMax)
                    {
                        currentMax = v.Value;
                        maxValue = v.Key;
                    }
                }
            }
            int amountToRemove = 0;
            foreach (var v in dictionary)
            {
                if (v.Key != maxValue)
                {
                    amountToRemove += v.Value;
                }
            }
            return amountToRemove;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            int result = Result.equalizeArray(arr);
            Console.WriteLine(result);
        }
    }
}
