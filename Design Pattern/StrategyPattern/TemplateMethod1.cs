namespace StrategyPattern
{
    internal abstract class TemplateMethod1 : IStrategy
    {
        public void Solve()
        {
            Start();
            while (!ShouldStop())
            {
                NextTry();
            }

            Stop();
        }

        protected abstract void Start();

        protected abstract bool ShouldStop();

        protected abstract void NextTry();

        protected abstract void Stop();
    }
}