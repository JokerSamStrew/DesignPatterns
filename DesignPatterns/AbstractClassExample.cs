using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClassExample
{
    public abstract class Vehicle
    {
        public abstract void Move();
    }

    public class Car : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Car is moving");
        }
    }

    public class Bus : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Bus is moving");
        }
    }
}
