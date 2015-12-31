using System;

namespace Composite
{
    /// <summary>
    /// 1. "lowest common denominator"
    /// </summary>
    internal interface IComponent
    {
        void Traverse();
    }

    /// <summary>
    /// 2. "Is a" relationship
    /// </summary>
    internal class Primitive : IComponent
    {
        private readonly int _value;

        public Primitive(int val)
        {
            _value = val;
        }

        public void Traverse()
        {
            Console.WriteLine(_value + "  ");
        }
    }

    /// <summary>
    /// 2. "has a" relationship
    /// </summary>
    internal abstract class Composite : IComponent
    {
        private readonly IComponent[] _children = new IComponent[9];  // 3. Couple to interface IComponent
        private int _total = 0;
        private readonly int _value;

        internal Composite(int val)
        {
            _value = val;
        }

        public void Add(IComponent c)// 3. Couple to interface
        {
            _children[_total++] = c;
        }

        public virtual void Traverse()
        {
            Console.WriteLine(_value + "  ");
            for (var i = 0; i < _total; i++)
            {
                _children[i].Traverse(); // 4. Delegation and polymorphism
            }
        }
    }

    /// <summary>
    ///  Two different kinds of "con-tainer" classes.  Most of the "meat" is in the Composite base class.
    /// </summary>
    internal class Row : Composite
    {
        public Row(int val) : base(val)
        {
        }

        public override void Traverse()
        {
            Console.WriteLine("Row");
            base.Traverse();
        }

        private class Column : Composite
        {
            public Column(int val) : base(val)
            {
            }

            public override void Traverse()
            {
                Console.WriteLine("Col");
                base.Traverse();
            }
        }

        public class CompositeDemo
        {
            public static void Main(String[] args)
            {
                Composite first = new Row(1);          // Row1
                Composite second = new Column(2);       //   |
                Composite third = new Column(3);       //   +-- Col2
                Composite fourth = new Row(4);          //   |     |
                Composite fifth = new Row(5);          //   |     +-- 7
                first.Add(second);                      //   +-- Col3
                first.Add(third);                      //   |     |
                third.Add(fourth);                      //   |     +-- Row4
                third.Add(fifth);                      //   |     |     |
                first.Add(new Primitive(6));         //   |     |     +-- 9
                second.Add(new Primitive(7));         //   |     +-- Row5
                third.Add(new Primitive(8));         //   |     |     |
                fourth.Add(new Primitive(9));         //   |     |     +-- 10
                fifth.Add(new Primitive(10));         //   |     +-- 8
                first.Traverse();                         //   +-- 6

                Console.ReadLine();
            }
        }
    }
}