namespace Seeding
{
    /// <summary>
    /// Summary description for PrelimEvent.
    /// </summary>
    public class PrelimEvent : Event
    {
        public PrelimEvent(string filename, int lanes)
            : base(filename, lanes)
        {
        }

        //return circle seeding
        public override Seeding GetSeeding()
        {
            return new CircleSeeding(Swimmers, NumLanes);
        }

        public override bool IsPrelim()
        {
            return true;
        }

        public override bool IsFinal()
        {
            return false;
        }

        public override bool IsTimedFinal()
        {
            return false;
        }
    }
}