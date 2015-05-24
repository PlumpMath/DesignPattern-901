using System.Collections;

namespace Seeding
{
    /// <summary>
    /// Summary description for StraightSeeding.
    /// </summary>
    public class StraightSeeding : Seeding
    {
        protected ArrayList Swimmers;
        protected Swimmer[] Swmrs;
        protected int Count;
        protected int NumHeats;

        public StraightSeeding(ArrayList sw, int lanes)
        {
            Swimmers = sw;
            NumLanes = lanes;
            Count = sw.Count;
            CalcLaneOrder();
            Seed();
        }

        //--------------------------------
        protected override void Seed()
        {
            //loads the swmrs array and sorts it
            SortUpwards();

            var lastHeat = Count % NumLanes;
            if (lastHeat < 3)
            {
                lastHeat = 3;   //last heat must have 3 or more
            }
            var lastLanes = Count - lastHeat;
            NumHeats = Count / NumLanes;
            if (lastLanes > 0)
            {
                NumHeats++;
            }
            var heats = NumHeats;

            //place heat and lane in each swimmer's object
            var j = 0;
            for (var i = 0; i < lastLanes; i++)
            {
                var sw = Swmrs[i];
                sw.setLane(Lanes[j++]);
                sw.setHeat(heats);
                if (j >= NumLanes)
                {
                    heats--;
                    j = 0;
                }
            }
            //Add in last partial heat
            if (j < NumLanes)
            {
                heats--;
            }
            j = 0;
            for (var i = lastLanes - 1; i < Count; i++)
            {
                var sw = Swmrs[i];
                sw.setLane(Lanes[j++]);
                sw.setHeat(heats);
            }
            //copy from array back into ArrayList
            Swimmers = new ArrayList();
            for (var i = 0; i < Count; i++)
            {
                Swimmers.Add(Swmrs[i]);
            }
        }

        //--------------------------------
        protected void SortUpwards()
        {
            Swmrs = new Swimmer[Count];
            for (var i = 0; i < Count; i++)
            {
                Swmrs[i] = (Swimmer)Swimmers[i];
            }
            for (var i = 0; i < Count; i++)
            {
                for (var j = i; j < Count; j++)
                {
                    if (Swmrs[i].getTime() > Swmrs[j].getTime())
                    {
                        var swtemp = Swmrs[i];
                        Swmrs[i] = Swmrs[j];
                        Swmrs[j] = swtemp;
                    }
                }
            }
        }

        //--------------------------------
        public override int GetCount()
        {
            return Swimmers.Count;
        }

        public override IEnumerator GetSwimmers()
        {
            return Swimmers.GetEnumerator();
        }

        //----------------------------------
        public override int GetHeats()
        {
            return NumHeats;
        }
    }
}