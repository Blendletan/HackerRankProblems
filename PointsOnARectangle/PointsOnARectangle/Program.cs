using System.IO;
namespace PointsOnARectangle
{
    class Result
    {
        /*
         * Complete the 'solve' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts 2D_INTEGER_ARRAY coordinates as parameter.
         */
        public static string solve(List<List<int>> coordinates)
        {
            int maxX = coordinates[0][0];
            int minX = coordinates[0][0];
            int maxY = coordinates[0][1];
            int minY = coordinates[0][1];
            int length = coordinates.Count;
            for (int i = 1; i < length; i++)
            {
                int x = coordinates[i][0];
                int y = coordinates[i][1];
                if (x > maxX)
                {
                    maxX = x;
                }
                if (y > maxY)
                {
                    maxY = y;
                }
                if (x < minX)
                {
                    minX = x;
                }
                if (y < minY)
                {
                    minY = y;
                }
            }
            foreach (var point in coordinates)
            {
                if (point[0] != minX && point[0] != maxX)
                {
                    if (point[1] != minY && point[1] != maxY)
                    {
                        return "NO";
                    }
                }
            }
            return "YES";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());
            for (int qItr = 0; qItr < q; qItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());
                List<List<int>> coordinates = new List<List<int>>();
                for (int i = 0; i < n; i++)
                {
                    coordinates.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(coordinatesTemp => Convert.ToInt32(coordinatesTemp)).ToList());
                }
                string result = Result.solve(coordinates);
                Console.WriteLine(result);
            }
        }
    }
}
