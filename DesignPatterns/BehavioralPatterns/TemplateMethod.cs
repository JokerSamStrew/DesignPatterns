using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralPatterns.TemplateMethod
{
    //
    // Formal form
    //
    abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            Operation1();
            Operation2();
        }
        public abstract void Operation1();
        public abstract void Operation2();
    }
    class ConcreteClass : AbstractClass
    {
        public override void Operation1() { }
        public override void Operation2() { }
    }

    //
    // Example
    //
    class Program
    {
        static void Main()
        {
            School school = new School();
            University university = new University();

            school.Learn();
            university.Learn();
        }
    }
    abstract class Education
    {
        public void Learn()
        { 
            Enter();
            Study();
            PassExams();
            GetDocument();
        }
        public abstract void Enter();
        public abstract void Study();
        public virtual void PassExams()
        { 
            Console.WriteLine("Passing final exams");
        }
        public abstract void GetDocument();
    }
    class School : Education
    {
        public override void Enter() 
        { 
            Console.WriteLine("Go to first grade");
        }
        public override void Study() 
        { 
            Console.WriteLine("Take lessons and do homework");
        }
        public override void GetDocument() 
        {
            Console.WriteLine("Get attestat");
        }
    }

    class University : Education
    {
        public override void Enter() 
        { 
            Console.WriteLine("Pass entering exam and enter the University");
        }
        public override void Study() 
        {
            Console.WriteLine("Take lectures");
            Console.WriteLine("Pass Practice");
        }
        public override void PassExams()
        { 
            Console.WriteLine("Passing spiality exams");
        }
        public override void GetDocument() 
        {
            Console.WriteLine("Get University Diploma");
        }
    }
}
