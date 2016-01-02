using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    /// <summary>
    /// 
    /// 1. Standardize the skeleton of an algorithm in a base class "template" method
    /// 2. Common implementations of individual steps are defined in the base class
    /// 3. Steps requiring peculiar implementations are "placeholders" in base class
    /// 4. Derived classes can override placeholder methods
    /// 5. Derived classes can override implemented methods
    /// 6. Derived classes can override and "call back to" base class methods
    /// 
    /// </summary>
    class Program
    {
        static void Main()
        {
            Generalization algorithm = new Realization();
            algorithm.FindSolution();

            ReadKey();
        }
    }

    abstract class Generalization
    {
        // 1. Standardize the skeleton of an algorithm in a "template" method
        public void FindSolution()
        {
            StepOne();
            StepTwo();
            StepThr();
            StepFor();
        }

        // 2. Common implementations of individual steps are defined in base class
        protected void StepOne()
        {
            WriteLine("Generalization.StepOne");
        }

        // 3. Steps requiring peculiar impls are "placeholders" in the base class
        protected abstract void StepTwo();
        protected abstract void StepThr();

        protected virtual void StepFor()
        {
            WriteLine("Generalization.StepFor");
        }
    }


    abstract class Specialization : Generalization
    {
        // 4. Derived classes can override placeholder methods
        // 1. Standardize the skeleton of an algorithm in a "template" method
        protected override void StepThr()
        {
            step3_1();
            step3_2();
            step3_3();
        }
        // 2. Common implementations of individual steps are defined in base class
        protected void step3_1()
        {
            WriteLine("Specialization.step3_1");
        }
        // 3. Steps requiring peculiar impls are "placeholders" in the base class
        protected abstract void step3_2();

        protected void step3_3()
        {
            WriteLine("Specialization.step3_3");
        }
    }


    class Realization : Specialization
    {
        // 4. Derived classes can override placeholder methods
        protected override void StepTwo()
        {
            WriteLine("Realization   .StepTwo");
        }

        protected override void step3_2()
        {
            WriteLine("Realization   .step3_2");
        }
        // 5. Derived classes can override implemented methods
        // 6. Derived classes can override and "call back to" base class methods
        protected override void StepFor()
        {
            WriteLine("Realization   .StepFor");
            base.StepFor();
        }
    }
}
