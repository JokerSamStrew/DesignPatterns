using DesignPatterns.StructurePatterns.Facade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DesignPatterns.StructurePatterns.Bridge
{
    //
    // Formal form
    //
    class Client
    {
        static void Main()
        {
            Abstraction abstraction;
            abstraction = new RefinedAbstraction(new ConcreteImplementorA());
            abstraction.Operation();
            abstraction.Implementor = new ConcreteImplementorB();
            abstraction.Operation();
        }
    }
    abstract class Abstraction
    {
        protected Implementor implementor;
        public Implementor Implementor
        {
            set { implementor = value; }
        }
        public Abstraction(Implementor imp)
        {
            implementor = imp;
        }
        public virtual void Operation()
        {
            implementor.OperationImp();
        }
    }
    abstract class Implementor
    {
        public abstract void OperationImp();
    }
    class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(Implementor imp) : base(imp)
        { }
        public override void Operation()
        { }
    }
    class ConcreteImplementorA : Implementor
    {
        public override void OperationImp() { }
    }
    class ConcreteImplementorB : Implementor
    {
        public override void OperationImp() { }
    }

    //
    // Example
    //
    class Program
    {
        static void Main()
        {
            Programmer freelancer = new FreelanceProgrammer(new CPPLanguage());
            freelancer.DoWork();
            freelancer.EarnMoney();
            freelancer.Language = new CSharpLanguage();
            freelancer.DoWork();
            freelancer.EarnMoney();
        }
    }
    interface ILanguage
    {
        void Build();
        void Execute();
    }
    class CPPLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("C++ code compilation");
        }
        public void Execute()
        {
            Console.WriteLine("Execute program");
        }
    }
    class CSharpLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("Roslyn code compilation");
        }
        public void Execute()
        {
            Console.WriteLine("JIT compilation to binary");
            Console.WriteLine("CLR execution");
        }
    }

    abstract class Programmer
    {
        protected ILanguage language;
        public ILanguage Language
        {
            set { language = value; }
        }
        public Programmer (ILanguage lang)
        {
            language = lang;
        }
        public virtual void DoWork()
        {
            language.Build();
            language.Execute();
        }
        public abstract void EarnMoney();
    }
    class FreelanceProgrammer : Programmer
    {
        public FreelanceProgrammer(ILanguage lang) : base(lang) { }
        public override void EarnMoney()
        {
            Console.WriteLine("Receive payment");
        }
    }
    class CorporateProgrammer : Programmer
    {
        public CorporateProgrammer(ILanguage lang) : base(lang) { }
        public override void EarnMoney()
        {
            Console.WriteLine("Receive month payment");
        }
    }
}

