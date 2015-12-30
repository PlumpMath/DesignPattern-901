using System;
using System.Drawing;

namespace Circle
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }
    }

    public class CircleData
    {
        private double _radius;
        private Color _color;
        private Point _origin;

        public CircleData(double radius, Color color, Point origin)
        {
            this._radius = radius;
            this._color = color;
            this._origin = origin;
        }

        public double Radius
        {
            get { return this._radius; }
        }

        public Color Color
        {
            get { return this._color; }
        }

        public Point Origin
        {
            get { return this._origin; }
        }
    }

    public class Circle
    {
        private CircleData circleData;

        public Circle(double radius, Color color, Point origin)
        {
            this.circleData = new CircleData(radius, color, origin);
        }

        public double Circumference
        {
            get { return this.circleData.Radius * Math.PI; }
        }

        public double Diameter
        {
            get { return this.circleData.Radius * 2; }
        }

        public void Draw(Graphics graphics)
        {
            //...
        }
    }
}