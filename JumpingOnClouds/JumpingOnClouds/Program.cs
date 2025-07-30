namespace JumpingOnClouds
{
    class Result
    {
        /*
         * Complete the 'jumpingOnClouds' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY c as parameter.
         */
        public static int jumpingOnClouds(List<int> c)
        {
            int length = c.Count;
            int currentPosition = 0;
            int numberOfSteps = 0;
            while (currentPosition < length-1)
            {
                if (currentPosition + 2 < length && c[currentPosition + 2] == 0)
                {
                    currentPosition += 2;
                }
                else
                {
                    currentPosition++;
                }
                numberOfSteps++;
            }
            return numberOfSteps;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt32(cTemp)).ToList();
            int result = Result.jumpingOnClouds(c);
            Console.WriteLine(result);
        }
    }
}
