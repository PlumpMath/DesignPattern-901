using System;

namespace GlobalSpooler
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class GlobSpooler
    {
        static void Main(string[] args)
        {
            var sp1 = Spooler.GetSpooler();
            if (sp1 != null)
            {
                Console.WriteLine("Got 1 spooler");
            }
            var sp2 = Spooler.GetSpooler();
            if (sp2 == null)
            {
                Console.WriteLine("Can\'t get spooler");
            }
            Console.Read();
            //fails at compile time
            //var sp3 = new Spooler();
        }
    }
}
