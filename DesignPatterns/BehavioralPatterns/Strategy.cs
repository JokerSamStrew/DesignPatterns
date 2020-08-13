using AbstractClassExample;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DesignPatterns.BehavioralPatterns.Strategy
{
    //
    // Formal form
    //

    public interface IStrategy
    {
        void Algorithm();
    }

    public class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm() { }
    }

    public class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm() { }
    }

    public class Context
    {
        public IStrategy ContextStrategy { get; set; }

        public Context(IStrategy strategy)
        {
            this.ContextStrategy = strategy;
        }
        public void ExecuteAlgorithm()
        {
            this.ContextStrategy.Algorithm();
        }
    }

    //
    // Example
    //

    class Program
    {
        static void Main()
        {
            Car auto = new Car(4, "Volvo", new PetrolMove()); 
            auto.Move(); 
            auto.Movable = new ElectricMove();
            auto.Move();
        }
    }

    interface IMovable
    {
        void Move();
    }

    class PetrolMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Gas fuel moving");
        }
    }
    class ElectricMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Move by elecricity");
        }
    }
    class Car
    {
        protected int _passengers_num;
        protected string _model;
        
        public Car(int num, string model, IMovable mov)
        {
            _passengers_num = num;
            _model = model;
            Movable = mov;
        }
        public IMovable Movable { private get; set; }
        public void Move()
        {
            Movable.Move();
        }

    }
}
