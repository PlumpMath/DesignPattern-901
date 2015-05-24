using System.Collections;

namespace Seeding
{
    /// <summary>
    /// Summary description for Event.
    /// </summary>
    public abstract class Event
    {
        protected int NumLanes;
        protected ArrayList Swimmers;

        protected Event(string filename, int lanes)
        {
            NumLanes = lanes;
            Swimmers = new ArrayList();
            //read in swimmers from file
            var f = new CsFile(filename);
            f.OpenForRead();
            var s = f.ReadLine();
            while (s != null)
            {
                var sw = new Swimmer(s);
                Swimmers.Add(sw);
                s = f.ReadLine();
            }
            f.Close();
        }

        public abstract Seeding GetSeeding();

        public abstract bool IsPrelim();

        public abstract bool IsFinal();

        public abstract bool IsTimedFinal();
    }
}