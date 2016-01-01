using System.Collections.Generic;
using static System.Console;

namespace Memento
{
    internal class Program
    {
        private static void Main()
        {
            Caretaker caretaker = new Caretaker();

            Originator originator = new Originator();
            originator.Set("State1");
            originator.Set("State2");
            caretaker.AddMemento(originator.SaveToMemento());
            originator.Set("State3");
            caretaker.AddMemento(originator.SaveToMemento());
            originator.Set("State4");

            originator.RestoreFromMemento(caretaker.GetMemento(1));

            ReadKey();
        }
    }

    internal class Memento
    {
        private readonly string _state;

        public Memento(string stateToSave)
        {
            _state = stateToSave;
        }

        public string GetSavedState()
        {
            return _state;
        }
    }

    internal class Originator
    {
        private string _state;
        /* lots of memory consumptive private data that is not necessary to define the
         * _state and should thus not be saved. Hence the small memento object. */

        public void Set(string state)
        {
            WriteLine("Originator: Setting _state to " + state);
            _state = state;
        }

        public Memento SaveToMemento()
        {
            WriteLine("Originator: Saving to Memento.");
            return new Memento(_state);
        }

        public void RestoreFromMemento(Memento m)
        {
            _state = m.GetSavedState();
            WriteLine("Originator: State after restoring from Memento: " + _state);
        }
    }

    internal class Caretaker
    {
        private readonly List<Memento> _savedStates = new List<Memento>();

        public void AddMemento(Memento m)
        {
            _savedStates.Add(m);
        }

        public Memento GetMemento(int index)
        {
            return _savedStates[index];
        }
    }
}