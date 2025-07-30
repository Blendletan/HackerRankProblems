namespace CutTheSticks
{
    class Result
    {

        /*
         * Complete the 'cutTheSticks' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static List<int> cutTheSticks(List<int> arr)
        {
            var output = new List<int>();
            int length = arr.Count;
            arr.Sort();
            while (arr.Count > 0)
            {
                output.Add(arr.Count);
                int amountToSubtract = arr[0];
                for (int j = 0; j < arr.Count; j++)
                {
                    arr[j] -= amountToSubtract;
                }
                arr.RemoveAll(x => x == 0);
            }
            return output;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = Result.cutTheSticks(arr);

            Console.WriteLine(String.Join("\n", result));
        }
    }
}
