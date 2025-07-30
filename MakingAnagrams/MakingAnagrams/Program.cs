namespace MakingAnagrams
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
         * Complete the 'makingAnagrams' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. STRING s1
         *  2. STRING s2
         */
        public static int makingAnagrams(string s1, string s2)
        {
            var freqOne = CreateDictionary(s1);
            var freqTwo = CreateDictionary(s2);
            int discrepencies = 0;
            foreach (var v in freqOne)
            {
                if (freqTwo.ContainsKey(v.Key) == false)
                {
                    discrepencies += v.Value;
                }
                else
                {
                    if (v.Value > freqTwo[v.Key])
                    {
                        int amountToAdd = v.Value - freqTwo[v.Key];
                        discrepencies += amountToAdd;
                    }
                }
            }
            foreach (var v in freqTwo)
            {
                if (freqOne.ContainsKey(v.Key) == false)
                {
                    discrepencies += v.Value;
                }
                else
                {
                    if (v.Value > freqOne[v.Key])
                    {
                        int amountToAdd = v.Value - freqOne[v.Key];
                        discrepencies += amountToAdd;
                    }
                }
            }
            return discrepencies;
        }
        public static Dictionary<char, int> CreateDictionary(string s)
        {
            var output = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (output.ContainsKey(c) == false)
                {
                    output.Add(c, 1);
                }
                else
                {
                    output[c]++;
                }
            }
            return output;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            int result = Result.makingAnagrams(s1, s2);
            Console.WriteLine(result);
        }
    }
}
