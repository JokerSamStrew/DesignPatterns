using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Relations.Implementation
{
    public interface IMovable
    {
        void Move();
    }

    public class Car : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Car is moving");
        }
    }
}
