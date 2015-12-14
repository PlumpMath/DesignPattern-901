using static System.Console;

namespace StrategyPattern
{
    internal class TemplateMethod1Impl : TemplateMethod1
    {
        private int _count;

        protected override void NextTry()
        {
            WriteLine($"NextTry[{_count++}]........");
        }

        protected override bool ShouldStop() => _count > 3;

        protected override void Start()
        {
            WriteLine("start........");
        }

        protected override void Stop()
        {
            WriteLine("stop........");
        }
    }
}