using System.Reflection;

namespace GraphSubsetSums
{
    using System.Numerics;
    internal class Program
    {
        static void Main(string[] args)
        {
            List<long> results = new List<long> { 1 };
            List<double> yValues = new List<double> { 1 };
            List<long> xValues = new List<long> { 1 };
            List<double> errorValues = new List<double>();
            int max = 30;
            for (int i = 2; i <= max; i++)
            {
                NextSubset(results, i);
                xValues.Add(i);
                double nextValue = results.First();
                yValues.Add(nextValue);
                double prediction = Math.Ceiling(21*Math.Pow(2d, (double)i-1)/60);
                double error = nextValue/prediction;
                Console.WriteLine($"Prediction was {prediction}");
                Console.WriteLine($"Result was {nextValue}");
                Console.WriteLine($"Error was {error}");
                errorValues.Add(error);
            }
            ScottPlot.Plot myPlot = new ScottPlot.Plot();
            myPlot.Add.Scatter(xValues, yValues);
            myPlot.SaveJpeg($"plot{DateTime.Now.ToFileTime()}.jpg", 1920, 1080);
            myPlot = new ScottPlot.Plot();
            xValues.RemoveAt(0);
            myPlot.Add.Scatter(xValues, errorValues);
            myPlot.SaveJpeg($"ErrorPlot{DateTime.Now.ToFileTime()}.jpg", 1920, 1080);
            Console.WriteLine("Graph Saved");

        }
        static void NextSubset(List<long> subset, int n)
        {
            long first = subset[(n - 1) / 2];
            for (int i = 0; i < n - 1; i++)
            {
                subset[i] += first;
                subset[i] = subset[i];
            }
            subset.Insert(0, first);
        }
    }
}
