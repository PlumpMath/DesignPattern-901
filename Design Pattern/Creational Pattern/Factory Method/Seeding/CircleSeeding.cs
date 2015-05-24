using System.Collections;

namespace Seeding
{
    /// <summary>
    /// Summary description for CircleSeeding.
    /// </summary>
    public class CircleSeeding : StraightSeeding
    {
        public CircleSeeding(ArrayList sw, int lanes)
            : base(sw, lanes)
        {
            Seed();
        }

        //----------------------------
        protected override void Seed()
        {
            base.Seed();        //do straight seed as default
            if (NumHeats >= 2)
            {
                var circle = 0;
                if (NumHeats >= 3)
                {
                    circle = 3;
                }
                else
                {
                    circle = 2;
                }
                var i = 0;
                for (var j = 0; j < NumLanes; j++)
                {
                    for (var k = 0; k < circle; k++)
                    {
                        Swmrs[i].setLane(Lanes[j]);
                        Swmrs[i++].setHeat(NumHeats - k);
                    }
                }
            }
        }
    }
}