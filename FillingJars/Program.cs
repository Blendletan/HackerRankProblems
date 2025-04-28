namespace FillingJars
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
    class JarArray
    {
        readonly int length;
        int[] jars;
        public JarArray(int n)
        {
            length = n;
            jars = new int[length];
        }
        public void Fill(List<int> input)
        {
            int startIndex = input[0] - 1;
            int endIndex = input[1] - 1;
            int amountToFill = input[2];
            for (int i = startIndex; i <= endIndex; i++)
            {
                jars[i] += amountToFill;
            }
        }
        public int Average()
        {
            double average = jars.Average();
            return (int)average;
        }
    }
    class Result
    {
        /*
         * Complete the 'solve' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. 2D_INTEGER_ARRAY operations
         */
        public static int solve(int n, List<List<int>> operations)
        {
            JarArray myArray = new JarArray(n);
            foreach (var o in operations)
            {
                myArray.Fill(o);
            }
            return myArray.Average();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int m = Convert.ToInt32(firstMultipleInput[1]);
            List<List<int>> operations = new List<List<int>>();
            for (int i = 0; i < m; i++)
            {
                operations.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(operationsTemp => Convert.ToInt32(operationsTemp)).ToList());
            }
            int result = Result.solve(n, operations);
            Console.WriteLine(result);
        }
    }
}
