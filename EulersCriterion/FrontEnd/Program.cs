using System.IO;
using EulersCriterion;

namespace FrontEnd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "input.txt";
            string outputFilePath = "output.txt";
            StreamReader reader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);
            int t = Convert.ToInt32(reader.ReadLine().Trim());
            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] firstMultipleInput = reader.ReadLine().TrimEnd().Split(' ');

                int a = Convert.ToInt32(firstMultipleInput[0]);

                int m = Convert.ToInt32(firstMultipleInput[1]);

                string result = Result.solve(a, m);

                writer.WriteLine(result);
            }
            reader.Close();
            writer.Close();
            Console.WriteLine("Hello, World!");
        }
    }
}
