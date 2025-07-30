namespace PointsOnALine
{
    using System.Numerics;
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<(int, int)> points = new List<(int, int)>();
            for (int nItr = 0; nItr < n; nItr++)
            {
                string[] xy = Console.ReadLine().Split(' ');

                int x = Convert.ToInt32(xy[0]);

                int y = Convert.ToInt32(xy[1]);
                points.Add((x, y));
            }
            bool isLine = IsLine(points);
            if (isLine)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
        static bool IsLine(List<(int, int)> points)
        {
            (int, int)? differenceVector = null;
            int length = points.Count;
            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    (int,int) nextDifferenceVector = DifferenceVector(points[j], points[i]);
                    if (nextDifferenceVector.Item1 != 0 && nextDifferenceVector.Item2 != 0)
                    {
                        return false;
                    }
                    if (nextDifferenceVector.Item1 != 0 && nextDifferenceVector.Item2 != 0)
                    {
                        if (differenceVector == null)
                        {
                            differenceVector = nextDifferenceVector;
                        }
                        else
                        {
                            if (differenceVector.Value.Item1 != nextDifferenceVector.Item1)
                            {
                                return false;
                            }
                            if (differenceVector.Value.Item2 != nextDifferenceVector.Item2)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        static (int, int) DifferenceVector((int, int) firstPoint, (int, int) secondPoint)
        {
            int xDiff = firstPoint.Item1 - secondPoint.Item1;
            int yDiff = firstPoint.Item2 - secondPoint.Item2;
            if (xDiff == 0 && yDiff == 0)
            {
                return (0, 0);
            }
            if (xDiff == 0)
            {
                return (0, 1);
            }
            if (yDiff == 0)
            {
                return (1, 0);
            }
            int gcd = (int)BigInteger.GreatestCommonDivisor(xDiff, yDiff);
            xDiff /= gcd;
            yDiff /= gcd;
            if (xDiff < 0)
            {
                xDiff *= -1;
                yDiff *= -1;
            }
            return (xDiff, yDiff);
        }


    }
}
