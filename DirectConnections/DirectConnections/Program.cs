namespace DirectConnections
{
    internal class Program
    {
        const long modulus = 1000000007;
        static long Solve()
        {
            int numberOfCities = int.Parse(Console.ReadLine());
            long[] cityLocations = new long[numberOfCities];
            long[] cityPopulations = new long[numberOfCities];
            string[] locationInputs = Console.ReadLine().Split();
            string[] populationInputs = Console.ReadLine().Split();
            for (int i = 0; i < numberOfCities; i++)
            {
                cityLocations[i] = long.Parse(locationInputs[i]);
                cityPopulations[i] = long.Parse(populationInputs[i]);
            }
            long output = 0;
            for (int i = 0; i < numberOfCities; i++)
            {
                long firstLocation = cityLocations[i];
                long firstPopulation = cityPopulations[i];
                for (int j = i + 1; j < numberOfCities; j++)
                {
                    long secondLocation = cityLocations[j];
                    long secondPopulation = cityPopulations[j];
                    long distance = Math.Abs(firstLocation - secondLocation);
                    long numberOfCables = Math.Max(firstPopulation, secondPopulation);
                    long toAdd = distance * numberOfCables;
                    toAdd = toAdd % modulus;
                    output += toAdd;
                    output = output % modulus;
                }
            }
            return output;
        }
        static void Main(string[] args)
        {
            int numberOfCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCases; i++)
            {
                var output = Solve();
                Console.WriteLine(output);
            }
        }
    }
}
