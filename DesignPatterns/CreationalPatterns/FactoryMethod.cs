using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace DesignPatterns.CreationalPatterns.FactoryMethod
{
    //
    // Formal Form
    //

    abstract class Product
    { }

    class ConcreteProductA : Product
    { }

    class ConcreteProductB : Product
    { }

    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    // 
    // Example
    //

    abstract class House
    { }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Panel house is built");
        }
    }

    class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("Wood house is built");
        }
    }

    abstract class Developer
    {
        public string Name { get; set; }

        public Developer (string n)
        {
            this.Name = n;
        }

        abstract public House Create();
    }

    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new PanelHouse();
        }
    }

    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    class Program
    {
        static void Main()
        {
            Developer dev = new PanelDeveloper("BrickHouseBuilder");
            House brick_house = dev.Create();

            dev = new WoodDeveloper("WoodHouseBuilder");
            House wood_house = dev.Create();
        }
    }
}
