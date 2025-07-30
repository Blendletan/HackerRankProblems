namespace JumpingOnCloudsRevisted
{
    class CloudGame
    {
        readonly int jumpSize;
        int currentPosition;
        public int CurrentEnergy { get; private set; }
        readonly int[] cloudArray;
        public CloudGame(int jumpSize, int[] cloudArray)
        {
            currentPosition = 0;
            CurrentEnergy = 100;
            this.jumpSize = jumpSize;
            this.cloudArray = cloudArray;
        }
        public bool MakeMove()
        {
            CurrentEnergy--;
            int length = cloudArray.Length;
            currentPosition = (currentPosition + jumpSize) % length;
            if (cloudArray[currentPosition] == 1)
            {
                CurrentEnergy -= 2;
            }
            if (currentPosition == 0)
            {
                return true;
            }
            return false;
        }
    }
    internal class Program
    {
        static int jumpingOnClouds(int[] c, int k)
        {
            var game = new CloudGame(k, c);
            while (true)
            {
                if (game.MakeMove())
                {
                    return game.CurrentEnergy;
                }
            }
        }
        static void Main(string[] args)
        {
            string[] nk = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nk[0]);
            int k = Convert.ToInt32(nk[1]);
            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp));
            int result = jumpingOnClouds(c, k);
            Console.WriteLine(result);
        }
    }
}
