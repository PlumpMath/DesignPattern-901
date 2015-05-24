namespace Seeding
{
    /// <summary>
    ///class describes an event that will be swum twice
    /// </summary>
    public class TimedFinalEvent : Event
    {
        public TimedFinalEvent(string filename, int lanes)
            : base(filename, lanes)
        {
        }

        //return StraightSeeding class
        public override Seeding GetSeeding()
        {
            return new StraightSeeding(Swimmers, NumLanes);
        }

        public override bool IsPrelim()
        {
            return false;
        }

        public override bool IsFinal()
        {
            return false;
        }

        public override bool IsTimedFinal()
        {
            return true;
        }
    }
}