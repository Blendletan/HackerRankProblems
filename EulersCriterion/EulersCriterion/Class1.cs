using System.Numerics;

namespace EulersCriterion
{
    public class Result
    {

        /*
         * Complete the 'solve' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts following parameters:
         *  1. INTEGER a
         *  2. INTEGER m
         */

        public static string solve(int a, int m)
        {
            if (a == 0)
            {
                return "YES";
            }
            int residue = (int)BigInteger.ModPow(a, (m - 1) / 2, m);
            if (residue == 1)
            {
                return "YES";
            }
            return "NO";
        }

    }
}
