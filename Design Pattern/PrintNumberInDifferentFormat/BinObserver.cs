using System;
using static System.Console;

namespace PrintNumberInDifferentFormat
{
    internal class BinObserver : Observer
    {
        public BinObserver(Subject s)
        {
            Subj = s;
            Subj.Attach(this);
        } // Observers register themselves 
        public override void Update()
        {
            WriteLine("{0}", Convert.ToString(Subj.GetState(), 2));
        }
    }
}