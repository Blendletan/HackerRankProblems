namespace DieHardThree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTestCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfTestCases; i++)
            {
                string[] input = Console.ReadLine().Split();
                int a = int.Parse(input[0]);
                int b = int.Parse(input[1]);
                int c = int.Parse(input[2]);
                Console.WriteLine(DieHard(a, b, c));
            }
        }
        static string DieHard(int firstJug, int secondJug, int target)
        {
            var v = new DieHardSolver(firstJug, secondJug, target);
            bool solved = v.Solve();
            if (solved)
            {
                return "YES";
            }
            return "NO";
        }
    }
    internal class DieHardSolver
    {
        List<string> previousStates;
        List<GameState> currentStates;
        public DieHardSolver(int a, int b, int c)
        {
            currentStates = new List<GameState>();
            currentStates.Add(new GameState(a, b, c));
            previousStates = new List<string>();
            previousStates.Add(currentStates.First().MyHash());
        }
        public bool Solve()
        {
            var newStates = new List<GameState>();
            while (true)
            {
                newStates.Clear();
                if (IsSolved())
                {
                    return true;
                }
                foreach (var current in currentStates)
                {
                    var next = current.GetAllNewStates();
                    foreach (var v in next)
                    {
                        if (AlreadyVisited(v) == false)
                        {
                            newStates.Add(v);
                        }
                    }
                }
                if (newStates.Count == 0)
                {
                    return false;
                }
                currentStates.Clear();
                foreach (var state in newStates)
                {
                    if (AlreadyVisited(state))
                    {
                        continue;
                    }
                    currentStates.Add(state);
                    previousStates.Add(state.MyHash());
                }
            }
        }
        private bool AlreadyVisited(GameState d)
        {
            if (previousStates.Contains(d.MyHash()))
            {
                return true;
            }
            return false;
        }
        private bool IsSolved()
        {
            foreach (var v in currentStates)
            {
                if (v.Solved())
                {
                    return true;
                }
            }
            return false;
        }
    }
    internal class GameState
    {
        public readonly int firstJugCapacity;
        public readonly int secondJugCapacity;
        int firstJug;
        int secondJug;
        int target;
        public GameState(int firstJug, int secondJug, int target)
        {
            if (firstJug > secondJug)
            {
                firstJugCapacity = secondJug;
                secondJugCapacity = firstJug;
            }
            else
            {
                firstJugCapacity = firstJug;
                secondJugCapacity = secondJug;
            }
            this.target = target;
        }
        public List<GameState> GetAllNewStates()
        {
            var output = new List<GameState>();
            GameState a = (GameState)this.MemberwiseClone();
            a.FillFirstJug();
            output.Add(a);
            GameState b = (GameState)this.MemberwiseClone();
            b.FillSecondJug();
            output.Add(b);
            GameState c = (GameState)this.MemberwiseClone();
            c.PourFirstJugIntoSecond();
            output.Add(c);
            GameState d = (GameState)this.MemberwiseClone();
            d.PourSecondJugIntoFirst();
            output.Add(d);
            GameState e = (GameState)this.MemberwiseClone();
            e.EmptyFirstJug();
            output.Add(e);
            GameState f = (GameState)this.MemberwiseClone();
            f.EmptySecondJug();
            output.Add(f);
            return output;
        }
        public void FillFirstJug()
        {
            firstJug = firstJugCapacity;
        }
        public void FillSecondJug()
        {
            secondJug = secondJugCapacity;
        }
        public void EmptyFirstJug()
        {
            firstJug = 0;
        }
        public void EmptySecondJug()
        {
            secondJug = 0;
        }
        public void PourFirstJugIntoSecond()
        {
            int toAdd = secondJugCapacity - secondJug;
            if (toAdd <= 0)
            {
                return;
            }
            toAdd = Math.Min(toAdd, firstJug);
            secondJug += toAdd;
            firstJug -= toAdd;
        }
        public void PourSecondJugIntoFirst()
        {
            int toAdd = firstJugCapacity - firstJug;
            if (toAdd <= 0)
            {
                return;
            }
            toAdd = Math.Min(toAdd, secondJug);
            firstJug += toAdd;
            secondJug -= toAdd;
        }
        public string MyHash()
        {
            return $"{firstJug.ToString()}_{secondJug.ToString()}";
        }
        public bool Solved()
        {
            if (firstJug == target || secondJug == target)
            {
                return true;
            }
            return false;
        }
    }
}