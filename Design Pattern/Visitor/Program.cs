using static System.Console;

namespace Visitor
{
    /// <summary>
    /// 1. Add an accept(Visitor) method to the "element" hierarchy
    /// 2. Create a "visitor" base class w/ a Visit() method for every "element" type
    /// 3. Create a "visitor" derived class for each "operation" to do on "elements"
    /// 4. Client creates "visitor" objects and passes each to accept() calls
    /// </summary>
    internal class Program
    {
        public static IElement[] List = { new This(), new That(), new TheOther() };

        private static void Main()
        {
            var up = new UpVisitor();
            var down = new DownVisitor();
            foreach (var ele in List)
            {
                ele.Accept(up);
            }
            foreach (var ele in List)
            {
                ele.Accept(down);
            }
        }
    }

    internal interface IElement
    {
        // 1. accept(Visitor) interface
        void Accept(IVisitor v); // first dispatch
    }

    internal class This : IElement
    {
        // 1. accept(Visitor) implementation
        public void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        public string ThisString()
        {
            return "This";
        }
    }

    internal class That : IElement
    {
        public void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        public string ThatString()
        {
            return "That";
        }
    }

    internal class TheOther : IElement
    {
        public void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        public string TheOtherString()
        {
            return "TheOther";
        }
    }

    // 2. Create a "visitor" base class with a Visit() method for every "element" type
    internal interface IVisitor
    {
        void Visit(This e); // second dispatch

        void Visit(That e);

        void Visit(TheOther e);
    }

    // 3. Create a "visitor" derived class for each "operation" to perform on "elements"
    internal class UpVisitor : IVisitor
    {
        public void Visit(This e)
        {
            WriteLine("do Up on " + e.ThisString());
        }

        public void Visit(That e)
        {
            WriteLine("do Up on " + e.ThatString());
        }

        public void Visit(TheOther e)
        {
            WriteLine("do Up on " + e.TheOtherString());
        }
    }

    internal class DownVisitor : IVisitor
    {
        public void Visit(This e)
        {
            WriteLine("do Down on " + e.ThisString());
        }

        public void Visit(That e)
        {
            WriteLine("do Down on " + e.ThatString());
        }

        public void Visit(TheOther e)
        {
            WriteLine("do Down on " + e.TheOtherString());
        }
    }
}