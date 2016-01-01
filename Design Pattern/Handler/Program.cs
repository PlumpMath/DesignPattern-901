using System;
using static System.Console;

namespace Handler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var chainRoot = new Handler();
            chainRoot.Add(new Handler());
            chainRoot.Add(new Handler());
            chainRoot.Add(new Handler());
            chainRoot.WrapAround(chainRoot);
            for (var i = 1; i < 10; i++)
            {
                chainRoot.Handle(i);
            }

            ReadKey();
        }
    }

    internal class Handler
    {
        private static Random _random = new Random();
        private static int _next = 1;
        private int _id = _next++;
        private Handler _nextHandler;

        public void Add(Handler next)
        {
            if (_nextHandler == null)
                _nextHandler = next;
            else
                _nextHandler.Add(next);
        }

        public void WrapAround(Handler root)
        {
            if (_nextHandler == null)
                _nextHandler = root;
            else
                _nextHandler.WrapAround(root);
        }

        public void Handle(int num)
        {
            if (_random.Next(4) != 0)
            {
                WriteLine(_id + "-busy  ");
                _nextHandler.Handle(num);
            }
            else
            {
                WriteLine(_id + "-handled-" + num);
            }
        }
    }
}