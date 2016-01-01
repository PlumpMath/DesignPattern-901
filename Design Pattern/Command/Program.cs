using System;
using System.Reflection;
using static System.Console;

namespace Command
{
    internal class Program
    {
        private static void Main()
        {
            CommandReflect[] objs = { new CommandReflect(1), new CommandReflect(2) };
            WriteLine("Normal call results: ");
            WriteLine(objs[0].AddOne(3));
            WriteLine(objs[1].AddTwo(4, 5));
            Command[] cmds =
            {
                new Command(objs[0], "AddOne", new object[] { 3 }),
                new Command(objs[1], "AddTwo", new object[] { 4, 5 })
            };
            WriteLine("\nReflection results:  ");
            foreach (var cmd in cmds)
            {
                WriteLine(cmd.Execute() + " ");
            }
            WriteLine();

            ReadKey();
        }
    }

    public class Command
    {
        private readonly object _receiver;               // the "encapsulated" object
        private readonly MethodInfo _action;                 // the "pre-registered" request
        private readonly object[] _args;                   // the "pre-registered" arg list

        public Command(object obj, string methodName, object[] arguments)
        {
            _receiver = obj;
            _args = arguments;
            var cls = obj.GetType();           // get the object's "Class"
            var argTypes = new Type[_args.Length];
            for (var i = 0; i < _args.Length; i++) // get the "Class" for each  supplied argument
            {
                argTypes[i] = _args[i].GetType();
            }

            // get the "Method" data structure with the correct name and signature
            try
            {
                _action = cls.GetMethod(methodName, argTypes);
            }
            catch (Exception e)
            {
                WriteLine(e);
            }
        }

        public object Execute()
        {
            // in C++, you do something like --- return _receiver->_action( _args );
            try { return _action.Invoke(_receiver, _args); }
            catch (Exception e) { WriteLine(e); }
            return null;
        }
    }

    public class CommandReflect
    {
        private readonly int _state;

        public CommandReflect(int ins)
        {
            _state = ins;
        }

        public int AddOne(int one)
        {
            return _state + one;
        }

        public int AddTwo(int one, int two)
        {
            return _state + one + two;
        }
    }
}