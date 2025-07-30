namespace Bijective
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool bijective = true;
            bool[] numberUsed = new bool[n + 1];
            for (int i = 0; i <= n; i++)
            {
                numberUsed[i] = false;
            }
            string[] inputs = Console.ReadLine().Split();
            foreach (string s in inputs)
            {
                int next = int.Parse(s);
                if (numberUsed[n] == false)
                {
                    numberUsed[n] = true;
                }
                else
                {
                    bijective = false;
                    break;
                }
            }
            if (bijective)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
