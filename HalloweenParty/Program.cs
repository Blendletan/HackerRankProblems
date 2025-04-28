namespace HalloweenParty
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
         * Complete the 'halloweenParty' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts INTEGER k as parameter.
         */
        public static long halloweenParty(int k)
        {
            long width = k / 2;
            long height = k - width;
            return width * height;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int tItr = 0; tItr < t; tItr++)
            {
                int k = Convert.ToInt32(Console.ReadLine().Trim());
                long result = Result.halloweenParty(k);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }
    }
}
