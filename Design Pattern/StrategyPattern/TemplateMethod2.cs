namespace StrategyPattern
{
    internal abstract class TemplateMethod2 : IStrategy
    {
        public void Solve()
        {
            PreProcess();
            PostProcess();
        }

        protected abstract void PreProcess();

        protected abstract void PostProcess();
    }
}