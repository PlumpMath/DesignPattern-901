using System;

namespace Point
{
    //1. Identify the desired unified interface for a set of subsystems
    //2. Design a "wrapper" class that can encapsulate the use of the subsystems
    //3. The client uses(is coupled to) the Facade
    //4. The facade/wrapper "maps" to the APIs of the subsystems

    internal class Program
    {
        private static void Main(string[] args)
        {
            var line1 = new Line(new Point(2, 4), new Point(5, 7));
            line1.Move(-2, -4);
            Console.WriteLine("after Move:  " + line1);
            line1.Rotate(45);
            Console.WriteLine("after Rotate: " + line1);
            var line2 = new Line(new Point(2, 1), new Point(2.866, 1.5));
            line2.Rotate(30);
            Console.WriteLine("30 degrees to 60 degrees: " + line2);

            Console.Read();
        }
    }

    /// <summary>
    /// subsystem
    /// </summary>
    internal class PointCarte
    {
        private double _x;
        private double _y;

        public PointCarte(double xx, double yy)
        {
            _x = xx;
            _y = yy;
        }

        public void Move(int dx, int dy)
        {
            _x += dx;
            _y += dy;
        }

        public override string ToString()
        {
            return "(" + _x + "," + _y + ")";
        }

        public double GetX()
        {
            return _x;
        }

        public double GetY()
        {
            return _y;
        }
    }

    /// <summary>
    /// subsystem
    /// </summary>
    internal class PointPolar
    {
        private double _radius;
        private double _angle;

        public PointPolar(double r, double a)
        {
            _radius = r;
            _angle = a;
        }

        public void Rotate(int ang)
        {
            _angle += ang % 360;
        }

        public override string ToString()
        {
            return "[" + _radius + "@" + _angle + "]";
        }
    }

    /// <summary>
    // 1. Desired interface: Move(), Rotate()
    /// </summary>
    internal class Point
    {
        private PointCarte pc; // 2. Design a "wrapper" class

        public Point(double xx, double yy)
        {
            pc = new PointCarte(xx, yy);
        }

        public override string ToString()
        {
            return pc.ToString();
        }

        // 4. Wrapper maps
        public void Move(int dx, int dy)
        {
            pc.Move(dx, dy);
        }

        public void Rotate(int angle, Point o)
        {
            double x = pc.GetX() - o.pc.GetX();
            double y = pc.GetY() - o.pc.GetY();
            PointPolar pp = new PointPolar(Math.Sqrt(x * x + y * y),
                Math.Atan2(y, x) * 180 / Math.PI);
            // 4. Wrapper maps
            pp.Rotate(angle);
            Console.WriteLine("  PointPolar is " + pp);
            String str = pp.ToString();
            int i = str.IndexOf('@');
            double r = Double.Parse(str.Substring(1, i - 1));
            double a = Double.Parse(str.Substring(i + 1, str.Length - 1 - i - 1));
            pc = new PointCarte(r * Math.Cos(a * Math.PI / 180) + o.pc.GetX(),
                r * Math.Sin(a * Math.PI / 180) + o.pc.GetY());

        }
    }

    internal class Line
    {
        private readonly Point _o;
        private readonly Point _e;

        public Line(Point ori, Point end)
        {
            _o = ori;
            _e = end;
        }

        public void Move(int dx, int dy)
        {
            _o.Move(dx, dy);
            _e.Move(dx, dy);
        }

        public void Rotate(int angle)
        {
            _e.Rotate(angle, _o);
        }

        public override string ToString()
        {
            return "origin is " + _o + ", end is " + _e;
        }
    }
}