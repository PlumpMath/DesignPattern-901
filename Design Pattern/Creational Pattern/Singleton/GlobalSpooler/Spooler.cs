namespace GlobalSpooler
{
    /// <summary>
    /// Summary description for Spooler.
    /// </summary>
    public class Spooler
    {
        private static bool _instanceFlag;

        private Spooler()
        {
        }

        public static Spooler GetSpooler()
        {
            if (_instanceFlag)
            {
                return null;
            }
            _instanceFlag = true;
            return new Spooler();
        }
    }
}