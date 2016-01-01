using System;

namespace PrintNumberInDifferentFormat
{
    internal class HexObserver : Observer
    {
        public HexObserver(Subject s)
        {
            Subj = s;
            Subj.Attach(this);
        }

        public override void Update()
        {
            Console.WriteLine("{0:X} ", Subj.GetState());
        }
    }
}