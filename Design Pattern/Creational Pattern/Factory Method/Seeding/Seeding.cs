using System.Collections;

namespace Seeding
{
    /// <summary>
    /// Summary description for Seeding.
    /// </summary>
    public abstract class Seeding
    {
        protected int NumLanes;
        protected int[] Lanes;

        public abstract IEnumerator GetSwimmers();

        public abstract int GetCount();

        public abstract int GetHeats();

        protected abstract void Seed();

        //--------------------------------
        protected void CalcLaneOrder()
        {
            Lanes = new int[NumLanes];
            var mid = NumLanes / 2;
            if (Odd(NumLanes))
                mid = mid + 1;       //start in middle lane
            var incr = 1;
            var ln = mid;
            //create array of lanes from
            //center to outside
            for (var i = 0; i < NumLanes; i++)
            {
                Lanes[i] = ln;
                ln = mid + incr;
                incr = -incr;
                if (incr > 0)
                    incr = incr + 1;
            }
        }

        //--------------------------------
        private static bool Odd(int x)
        {
            return (((x / 2) * 2) != x);
        }
    }
}