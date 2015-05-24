using System;

namespace SingleSpooler
{
    /// <summary>
    /// Prototype of Spooler Singleton
    /// such that only one instane can ever exist.
    /// </summary>
    public class Spooler
    {
        private static bool _instanceFlag; //true if one instance

        public Spooler()
        {
            if (_instanceFlag)
            {
                throw new SingletonException("Only one printer allowed");
            }

            _instanceFlag = true;     //set flag for one instance
            Console.WriteLine("printer opened");
        }
    }
}