using AbstractClassExample;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceExample
{
    public interface IMovable
    {
        void Move();
    }

    public abstract class Vihicle
    {

    }

    public class Car : Vehicle, IMovable
    {
        public override void Move()
        {
            Console.WriteLine("Car is moving");
        }
    }

    public class Bus : Vehicle, IMovable
    {
        public override void Move()
        {
            Console.WriteLine("Bus is moving");
        }
    }

    public class Horse : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Horse is moving");
        }
    }

    public class Aircraft : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Aircraft is moving");
        }
    }
}
