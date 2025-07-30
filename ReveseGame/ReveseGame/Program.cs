namespace ReveseGame
{
    internal class Program
    {
        public static int[] BuildArray(int max)
        {
            int[] output = new int[max];
            for (int i = 0; i < max; i += 2)
            {
                output[i] = max - 1 - i/2;
                if (i + 1 < max)
                {
                    output[i + 1] = i/2;
                }
            }
            return output;
        }
        public static int FindIndex(int[] arr, int valueToFind)
        {
            int length = arr.Length;
            for (int i = 0; i < length; i++)
            {
                if (arr[i] == valueToFind)
                {
                    return i;
                }
            }
            throw new Exception("Uh-oh");
        }
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int i = 0; i < t; i++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
                int n = Convert.ToInt32(firstMultipleInput[0]);
                int k = Convert.ToInt32(firstMultipleInput[1]);
                int[] array = BuildArray(n);
                Console.WriteLine(FindIndex(array, k));
            }
        Console.WriteLine("Hello, World!");
        }
    }
}
