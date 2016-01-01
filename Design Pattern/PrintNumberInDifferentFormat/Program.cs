using System;
using static System.Console;

namespace PrintNumberInDifferentFormat
{
    /// <summary>
    /// 1. Model the "independent" functionality with a "subject" abstraction
    /// 2. Model the "dependent" functionality with "observer" hierarchy
    /// 3. The Subject is coupled only to the Observer base class
    /// 4. Observers register themselves with the Subject
    /// 5. The Subject broadcasts events to all registered Observers
    /// 6. Observers "pull" the information they need from the Subject
    /// 7. Client configures the number and type of Observers
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sub = new Subject();
            // Client configures the number and type of Observers
            new HexObserver(sub);
            new OctObserver(sub);
            new BinObserver(sub);
            while (true)
            {
                WriteLine("\nEnter a number: ");
                sub.SetState(Convert.ToInt32(ReadLine()));
            }
        }
    }

    internal abstract class Observer
    {
        protected Subject Subj;

        public abstract void Update();
    }

    // Observers "pull" information

    // Observers "pull" information

    internal class Subject
    {
        private readonly Observer[] _observers = new Observer[9];
        private int _totalObs;
        private int _state;

        public void Attach(Observer o)
        {
            _observers[_totalObs++] = o;
        }

        public int GetState()
        {
            return _state;
        }

        public void SetState(int ins)
        {
            _state = ins;
            Notify();
        }

        private void Notify()
        {
            for (var i = 0; i < _totalObs; i++)
            {
                _observers[i].Update();
            }
        }
    }
}