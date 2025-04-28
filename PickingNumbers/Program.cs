namespace PickingNumbers
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
            int maxLength = 0;
            for (int i = 0; i < a.Count; i++)
            {
                int length = 1;
                int previousNumber = a[i];
                for (int j = i + 1; j < a.Count; j++)
                {
                    int nextDifference = a[j] - previousNumber;
                    if (nextDifference <= 1 && nextDifference >= -1)
                    {
                        length++;
                        previousNumber = a[j];
                    }
                    else
                    {
                        break;
                    }
                }
                if (length > maxLength)
                {
                    maxLength = length;
                }
            }
            return maxLength;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();
            int result = Result.pickingNumbers(a);
            Console.WriteLine(result);
        }
    }
}
