using System;

namespace SingleSpooler
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class SingleSpooler
    {
        private static void Main(string[] args)
        {
            //open one printer--this should always work
            Console.WriteLine("Opening one spooler");
            try
            {
                new Spooler();
            }
            catch (SingletonException e)
            {
                Console.WriteLine(e.Message);
            }

            //try to open another printer --should fail
            Console.WriteLine("Opening two spoolers");
            try
            {
                new Spooler();
            }
            catch (SingletonException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}