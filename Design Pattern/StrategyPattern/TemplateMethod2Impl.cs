using static System.Console;

namespace StrategyPattern
{
    internal class TemplateMethod2Impl : TemplateMethod2
    {
        protected override void PostProcess() => WriteLine("Post process");

        protected override void PreProcess() => WriteLine("pre-process");
    }
}