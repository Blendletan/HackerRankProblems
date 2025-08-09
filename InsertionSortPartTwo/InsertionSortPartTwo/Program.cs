using System.Text;
namespace InsertionSortPartTwo
{
    class Result
    {
        /*
         * Complete the 'insertionSort1' function below.
         *
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER_ARRAY arr
         */
        public static void PlaceElement(int n, List<int> arr,int index)
        {
            int temp = arr[index];
            bool foundMatch = false;
            for (int i = index-1; i >= 0; i--)
            {
                int currentNumber = arr[i];
                if (currentNumber <= temp)
                {
                    arr[i + 1] = temp;
                    PrintArray(arr);
                    foundMatch = true;
                    break;
                }
                else
                {
                    arr[i + 1] = currentNumber;
                }
            }
            if (foundMatch == false)
            {
                arr[0] = temp;
                PrintArray(arr);
            }
        }
        public static void insertionSort2(int n, List<int> arr)
        {
            for (int i = 1; i < n; i++)
            {
                PlaceElement(n, arr, i);
            }
        }
        private static void PrintArray(List<int> input)
        {
            StringBuilder output = new StringBuilder();
            foreach (var v in input)
            {
                output.Append(v.ToString());
                output.Append(" ");
            }
            Console.WriteLine(output.ToString());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            Console.WriteLine();
            Result.insertionSort2(n, arr);
        }
    }
}
