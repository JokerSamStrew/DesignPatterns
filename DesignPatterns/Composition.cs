using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Relations.Composition
{
    public class ElectricEngine
    {

    }

    public class Car
    {
        ElectricEngine engine;
        public Car()
        {
            engine = new ElectricEngine();
        }
    }
}
