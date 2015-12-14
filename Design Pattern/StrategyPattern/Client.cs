using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    internal class MainProgram
    {
        private static void ClientCode(IStrategy strategy)
        {
            strategy.Solve();
        }

        private static void Main(string[] args)
        {
            var strategies = new List<IStrategy> { new TemplateMethod1Impl(), new TemplateMethod2Impl() };

            foreach (var strategy in strategies)
            {
                ClientCode(strategy);
            }

            Console.ReadLine();
        }
    }
}