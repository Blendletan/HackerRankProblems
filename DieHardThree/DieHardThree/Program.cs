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
        List<DieHard> currentStates;
        public readonly int Target;
        public DieHardSolver(int a, int b, int c)
        {
            currentStates = new List<DieHard>();
            currentStates.Add(new DieHard(a, b));
            previousStates = new List<string>();
            previousStates.Add(currentStates.First().MyHash());
            Target = c;
        }
        public bool Solve()
        {
            var newStates = new List<DieHard>();
            while (true)
            {
                newStates.Clear();
                if (IsSolved())
                {
                    return true;
                }
                foreach (var current in currentStates)
                {
                    var a = new DieHard(current);
                    a.FillFirstJug();
                    var b = new DieHard(current);
                    b.FillSecondJug();
                    var c = new DieHard(current);
                    c.PourFirstJugIntoSecond();
                    var d = new DieHard(current);
                    d.PourSecondJugIntoFirst();
                    var e = new DieHard(current);
                    e.EmptyFirstJug();
                    var f = new DieHard(current);
                    f.EmptySecondJug();
                    if (AlreadyVisited(a) == false)
                    {
                        newStates.Add(a);
                    }
                    if (AlreadyVisited(b) == false)
                    {
                        newStates.Add(b);
                    }
                    if (AlreadyVisited(c) == false)
                    {
                        newStates.Add(c);
                    }
                    if (AlreadyVisited(d) == false)
                    {
                        newStates.Add(d);
                    }
                    if (AlreadyVisited(e) == false)
                    {
                        newStates.Add(e);
                    }
                    if (AlreadyVisited(f) == false)
                    {
                        newStates.Add(f);
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
        private bool AlreadyVisited(DieHard d)
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
                if (v.Solved(Target))
                {
                    return true;
                }
            }
            return false;
        }
    }
    internal class DieHard
    {
        public readonly int firstJugCapacity;
        public readonly int secondJugCapacity;
        public int FirstJug { get; private set; }
        public int SecondJug { get; private set; }
        public DieHard(DieHard toClone)
        {
            firstJugCapacity = toClone.firstJugCapacity;
            secondJugCapacity = toClone.secondJugCapacity;
            FirstJug = toClone.FirstJug;
            SecondJug = toClone.SecondJug;
        }
        public DieHard(int firstJug, int secondJug)
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
        }
        public void FillFirstJug()
        {
            FirstJug = firstJugCapacity;
        }
        public void FillSecondJug()
        {
            SecondJug = secondJugCapacity;
        }
        public void EmptyFirstJug()
        {
            FirstJug = 0;
        }
        public void EmptySecondJug()
        {
            SecondJug = 0;
        }
        public void PourFirstJugIntoSecond()
        {
            int toAdd = secondJugCapacity - SecondJug;
            if (toAdd <= 0)
            {
                return;
            }
            toAdd = Math.Min(toAdd, FirstJug);
            SecondJug += toAdd;
            FirstJug -= toAdd;
        }
        public void PourSecondJugIntoFirst()
        {
            int toAdd = firstJugCapacity - FirstJug;
            if (toAdd <= 0)
            {
                return;
            }
            toAdd = Math.Min(toAdd, SecondJug);
            FirstJug += toAdd;
            SecondJug -= toAdd;
        }
        public string MyHash()
        {
            return $"{FirstJug.ToString()}_{SecondJug.ToString()}";
        }
        public bool Solved(int target)
        {
            if (FirstJug == target || SecondJug == target)
            {
                return true;
            }
            return false;
        }
    }
}
