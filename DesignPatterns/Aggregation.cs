using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Relations.Aggregation
{
    public abstract class Engine
    {

    }

    public class Car
    {
        Engine engine;
        public Car(Engine eng)
        {
            engine = eng;
        }
    }
}
