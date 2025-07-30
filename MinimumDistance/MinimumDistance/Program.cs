using System.Collections.Generic;
namespace MinimumDistance
{
    class Result
    {
        /*
         * Complete the 'minimumDistances' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY a as parameter.
         */
        public static int MinDistance(List<int> l)
        {
            int length = l.Count;
            int? output = null;
            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (l[i] == l[j])
                    {
                        int newDistance = j - i;
                        if (output == null)
                        {
                            output = newDistance;
                        }
                        else if (newDistance < output)
                        {
                            output = newDistance;
                        }
                    }
                }
            }
            if (output == null)
            {
                output = -1;
            }
            return output.Value;
        }
        public static int minimumDistances(List<int> a)
        {
            return MinDistance(a);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();
            int result = Result.minimumDistances(a);
            Console.WriteLine(result);
        }
    }
}
