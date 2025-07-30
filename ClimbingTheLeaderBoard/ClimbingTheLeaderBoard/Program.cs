using System.IO;

namespace ClimbingTheLeaderBoard
{
    class Result
    {

        /*
         * Complete the 'climbingLeaderboard' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY ranked
         *  2. INTEGER_ARRAY player
         */
        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
        {
            player.Reverse();
            var output = new List<int>();
            int length = ranked.Count;
            int currentRank = 1;
            int currentScore = ranked[0];
            int playerIndex = 0;
            int playerScore = player[playerIndex];
            if (currentScore <= playerScore)
            {
                output.Add(currentRank);
                playerIndex++;
                if (playerIndex >= player.Count)
                {
                    return output;
                }
                playerScore = player[playerIndex];
            }
            for (int i = 1; i < length; i++)
            {
                int nextScore = ranked[i];
                if (nextScore < playerScore)
                {
                    output.Add(currentRank+1);
                    playerIndex++;
                    if (playerIndex >= player.Count)
                    {
                        return output;
                    }
                    playerScore = player[playerIndex];
                }
                if (nextScore < currentScore)
                {
                    currentRank++;
                }
                if (nextScore == playerScore)
                {
                    output.Add(currentRank);
                    playerIndex++;
                    if (playerIndex >= player.Count)
                    {
                        return output;
                    }
                    playerScore = player[playerIndex];
                }
                currentScore = nextScore;
            }
            while (output.Count < player.Count)
            {
                output.Add(currentRank + 1);
            }
            output.Reverse();
            return output;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

            int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

            List<int> result = Result.climbingLeaderboard(ranked, player);

            Console.WriteLine(String.Join("\n", result));
        }
    }
}
