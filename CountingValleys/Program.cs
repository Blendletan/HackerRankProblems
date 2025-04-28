namespace CountingValleys
{
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Collections;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Text.RegularExpressions;
    using System.Text;
    using System;
    internal class Climber
    {
        int elevation;
        public int numberOfValleys { get; private set; }
        public Climber()
        {
            elevation = 0;
            numberOfValleys = 0;
        }
        public void Climb(char c)
        {
            if (c == 'U')
            {
                elevation++;
            }
            else if (c == 'D')
            {
                if (elevation == 0)
                {
                    numberOfValleys++;
                }
                elevation--;
            }
            else
            {
                throw new Exception("invalid input");
            }
        }
    }
    class Result
    {
        /*
         * Complete the 'countingValleys' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER steps
         *  2. STRING path
         */
        public static int countingValleys(int steps, string path)
        {
            Climber myClimber = new Climber();
            foreach (char c in path)
            {
                myClimber.Climb(c);
            }
            return myClimber.numberOfValleys;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int steps = Convert.ToInt32(Console.ReadLine().Trim());
            string path = Console.ReadLine();
            int result = Result.countingValleys(steps, path);
            Console.WriteLine(result);
        }
    }
}
