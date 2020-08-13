using DesignPatterns.BehavioralPatterns.Mediator;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DesignPatterns.StructurePatterns.Facade
{
    //
    // Formal form
    //
    class SubsystemA
    {
        public void A1() { }
    }
    class SubsystemB
    {
        public void B1() { }
    }
    class SubsystemC
    {
        public void C1() { }
    }
    class Facade
    {
        SubsystemA _subsystemA;
        SubsystemB _subsystemB;
        SubsystemC _subsystemC;

        public Facade(SubsystemA sa, SubsystemB sb, SubsystemC sc)
        {
            _subsystemA = sa;
            _subsystemB = sb;
            _subsystemC = sc;
        }
        public void Operation1()
        {
            _subsystemA.A1();
            _subsystemB.B1();
            _subsystemC.C1();
        }
        public void Operation2()
        {
            _subsystemB.B1();
            _subsystemC.C1();
        }
    }
    class Client
    {
        public void Main()
        {
            Facade facade = new Facade(
                    new SubsystemA(),
                    new SubsystemB(),
                    new SubsystemC()
                    );
            facade.Operation1();
            facade.Operation2();
        }
    }
    //
    // Example
    //
    class Program
    {
        static void Main()
        {
            TextEditor textEditor = new TextEditor();
            Compiler compiler = new Compiler();
            CLR clr = new CLR();

            VisualStudioFacade ide = new VisualStudioFacade(textEditor, compiler, clr);

            Programmer programmer = new Programmer();
            programmer.CreateApplication(ide);
        }
    }
    class TextEditor
    {
        public void CreateCode()
        {
            Console.WriteLine("Writing code");
        }
        public void Save()
        {
            Console.WriteLine("Save code");
        }
    }
    class Compiler
    {
        public void Compile()
        {
            Console.WriteLine("Compiling application");
        }
    }
    class CLR
    {
        public void Execute()
        {
            Console.WriteLine("Application execution");
        }
        public void Finish()
        {
            Console.WriteLine("Finishing app work");
        }
    }
    class VisualStudioFacade
    {
        TextEditor textEditor;
        Compiler compiler;
        CLR clr;
        public VisualStudioFacade(TextEditor te, Compiler compiler, CLR clr)
        {
            this.textEditor = te;
            this.compiler = compiler;
            this.clr = clr;
        }
        public void Start()
        {
            textEditor.CreateCode();
            textEditor.Save();
            compiler.Compile();
            clr.Execute();
        }
        public void Stop()
        {
            clr.Finish();
        }
    }
    class Programmer
    {
        public void CreateApplication(VisualStudioFacade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }
}
