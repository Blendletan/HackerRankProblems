namespace PickingNumbers
{
    using System.Diagnostics;
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
    class Result
    {
        /*
         * Complete the 'pickingNumbers' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY a as parameter.
         */
        public static int pickingNumbers(List<int> a)
        {
            List<List<int>> validSubsets = Subsets(a);
            int currentMax = 0;
            foreach (var nextSubset in validSubsets)
            {
                int length = nextSubset.Count;
                if (length > currentMax)
                {
                    currentMax = length;
                }
            }
            return currentMax;
        }
        private static List<List<int>> Subsets(List<int> input)
        {
            int length = input.Count;
            List<List<int>> subsets = new List<List<int>>();
            subsets.Add(new List<int>());
            int index = 0;
            foreach (var nextInteger in input)
            {
                List<List<int>> toAddToCollection = new List<List<int>>();
                foreach (var previousSubset in subsets)
                {
                    List<int> newSubset = new List<int>(previousSubset);
                    newSubset.Add(nextInteger);
                    if (IsValid(newSubset))
                    {
                        toAddToCollection.Add(newSubset);
                    }
                }
                foreach (var newSubset in toAddToCollection)
                {
                    subsets.Add(newSubset);
                }
                index++;
            }
            return subsets;
        }
        private static bool IsValid(List<int> input)
        {
            int length = input.Count;
            if (length <= 1)
            {
                return true;
            }
            for (int i = 1; i < length; i++)
            {
                int current = input[i];
                int previous = input[i - 1];
                int gap = current - previous;
                if (gap != 1 && gap != -1 && gap != 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int result = Result.pickingNumbers(a);
            sw.Stop();
            Console.WriteLine(result);
            Console.WriteLine($"{sw.ElapsedMilliseconds} milliseconds");
        }
    }
}
