using System.Drawing;

namespace Gardener
{
    /// <summary>
    /// Summary description for Plant.
    /// </summary>
    public class Plant
    {
        private readonly string _name;
        private readonly Brush _br;
        private readonly Font _font;

        public Plant(string pname)
        {
            _name = pname;     //save name
            _font = new Font("Arial", 12);
            _br = new SolidBrush(Color.Black);
        }

        //-------------
        public void Draw(Graphics g, int x, int y)
        {
            g.DrawString(_name, _font, _br, x, y);
        }
    }
}