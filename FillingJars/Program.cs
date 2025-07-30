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
        readonly Int128 length;
        Int128 totalCandies;
        public JarArray(int n)
        {
            length = n;
            totalCandies = 0;
        }
        public void Fill(List<int> input)
        {
            int startIndex = input[0];
            int endIndex = input[1];
            int numberOfJarsToFill = endIndex - startIndex + 1;
            int amountToFill = input[2];
            Int128 totalAmountToAdd = amountToFill * numberOfJarsToFill;
            totalCandies += totalAmountToAdd;
        }
        public Int128 Average()
        {
            return totalCandies / length;
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
        public static Int128 solve(int n, List<List<int>> operations)
        {
            JarArray myArray = new JarArray(n);
            foreach (var o in operations)
            {
                myArray.Fill(o);
            }
            Int128 output = myArray.Average();
            return output;
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
            Int128 result = Result.solve(n, operations);
            Console.WriteLine(result);
        }
    }
}
