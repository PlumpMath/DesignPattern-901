using static System.Console;

namespace CeilingFan
{
    internal class Program
    {
        private static void Main()
        {
            var chain = new CeilingFanPullChain();
            while (true)
            {
                WriteLine("Press ");
                if (ReadLine() == "exit")
                {
                    break;
                }
                chain.Pull();
            }
        }
    }

    internal class CeilingFanPullChain
    {
        private IState _currentState;

        public CeilingFanPullChain()
        {
            _currentState = new Off();
        }

        public void SetState(IState s)
        {
            _currentState = s;
        }

        public void Pull()
        {
            _currentState.Pull(this);
        }
    }

    internal interface IState
    {
        void Pull(CeilingFanPullChain wrapper);
    }

    internal class Off : IState
    {
        public void Pull(CeilingFanPullChain wrapper)
        {
            wrapper.SetState(new Low());
            WriteLine("   low speed");
        }
    }

    internal class Low : IState
    {
        public void Pull(CeilingFanPullChain wrapper)
        {
            wrapper.SetState(new Medium());
            WriteLine("   medium speed");
        }
    }

    internal class Medium : IState
    {
        public void Pull(CeilingFanPullChain wrapper)
        {
            wrapper.SetState(new High());
            WriteLine("   high speed");
        }
    }

    internal class High : IState
    {
        public void Pull(CeilingFanPullChain wrapper)
        {
            wrapper.SetState(new Off());
            WriteLine("   turning off");
        }
    }
}