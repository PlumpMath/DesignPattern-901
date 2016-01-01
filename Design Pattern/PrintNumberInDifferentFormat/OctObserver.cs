using System;
using System.Globalization;
using static System.Console;

namespace PrintNumberInDifferentFormat
{
    internal class OctObserver : Observer
    {
        public OctObserver(Subject s)
        {
            Subj = s;
            Subj.Attach(this);
        }

        public override void Update()
        {
            WriteLine(" {0}", Convert.ToString( Subj.GetState(), 8));
        }
    }
}