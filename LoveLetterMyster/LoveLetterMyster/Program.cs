namespace LoveLetterMyster
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
         * Complete the 'theLoveLetterMystery' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts STRING s as parameter.
         */
        public static int theLoveLetterMystery(string s)
        {
            int length = s.Length;
            int output = 0;
            for (int i = 0; i < length / 2; i++)
            {
                int matchingIndex = MatchingIndex(s, i);
                int charValue = (int)s[i];
                int matchingCharValue = (int)s[matchingIndex];
                if (charValue > matchingCharValue)
                {
                    output += charValue - matchingCharValue;
                }
                else
                {
                    output += matchingCharValue - charValue;
                }
            }
            return output;
        }
        public static int MatchingIndex(string s, int index)
        {
            int length = s.Length;
            int middleIndex = length / 2;
            int output = 2 * middleIndex - index;
            if (int.IsEvenInteger(length))
            {
                output--;
            }
            return output;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());
            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();
                int result = Result.theLoveLetterMystery(s);
                Console.WriteLine(result);
            }
        }
    }
}
