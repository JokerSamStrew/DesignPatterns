using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.StructurePatterns.Adapter
{
    //
    // Formal Form
    //
    class Client
    {
        public void Request(Target target)
        {
            target.Request();
        }
    }
    class Target
    {
        public virtual void Request() { }
    }
    class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();
        public override void Request()
        {
            adaptee.SpecificRequest();
        }
        class Adaptee
        {
            public void SpecificRequest() { }
        }
    }
    
    //
    // Example
    //
    class Program
    {
        static void Main()
        {
            Driver driver = new Driver();
            Auto auto = new Auto();
            driver.Travel(auto);
            Camel camel = new Camel();
            ITransport camelTransport = new CamelToTransportAdapter(camel);
            driver.Travel(camelTransport);
        }
    }
    interface ITransport
    {
        void Drive();
    }
    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Car moving on road");
        }
    }
    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
    interface IAnimal
    {
        void Move();
    }
    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Camel going in desert");
        }
    }
    
    class CamelToTransportAdapter : ITransport
    {
        Camel camel;
        public CamelToTransportAdapter(Camel c)
        {
            camel = c;
        }
        public void Drive()
        {
            camel.Move();
        }
    }
}
