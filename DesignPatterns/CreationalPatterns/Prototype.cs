using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DesignPatterns.CreationalPatterns.Prototype
{
    //
    // Formal form
    //
    class Client
    {
        void Operation()
        {
            Prototype prototype = new ConcretePrototype1(1);
            Prototype clone = prototype.Clone();
            prototype = new ConcretePrototype2(2);
            clone = prototype.Clone();
        }

    }
    abstract class Prototype
    {
        public int Id { get; private set; }
        public Prototype(int id)
        {
            this.Id = id;
        }
        public abstract Prototype Clone();
    }

    class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(int id) : base(id) { }
        public override Prototype Clone()
        {
            return new ConcretePrototype1(Id);
        }
    }

    class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(int id) : base(id) { }
        public override Prototype Clone()
        {
            return new ConcretePrototype2(this.Id);
        }
    }

    //
    // Example
    //

    class Program
    {
        static void Main(string[] args)
        {
            IFigure figure = new Rectangle(30, 40);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Circle(30);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();
        }
    }

    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    class Rectangle : IFigure
    {
        int width;
        int height;
        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }

        public IFigure Clone()
        {
            return new Rectangle(this.width, this.height);
        }

        public void GetInfo()
        {
            Console.WriteLine("Rect height {0} and width {1}", this.height, this.width);
        }
    }

    class Circle : IFigure
    {
        int radius;
        public Circle(int r)
        {
            radius = r;
        }

        public IFigure Clone()
        {
            return new Circle(this.radius);
        }

        public void GetInfo()
        {
            Console.WriteLine("Circle radius {0}", this.radius);
        }
    }

    //
    // Example DeepCopy
    //

    class ProgramS
    {
        static void Main(string[] args)
        {
            CircleS figure = new CircleS(30, 50, 60);
            CircleS clonedFigure = figure.DeepCopy() as CircleS;
            figure.Point.X = 100;
            figure.GetInfo();
            clonedFigure.GetInfo();
        }
    }

    [Serializable]
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    [Serializable]
    class CircleS : IFigure
    {
        int radius;
        public Point Point { get; set; }
        public CircleS(int r, int x, int y)
        {
            this.radius = r;
            this.Point = new Point { X = x, Y = y };
        }

        public IFigure Clone()
        {
            return this.MemberwiseClone() as IFigure;
        }

        public object DeepCopy()
        {
            object figure = null;
            using (MemoryStream tempStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));

                binaryFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);

                figure = binaryFormatter.Deserialize(tempStream);
            }
            return figure;
        }

        public void GetInfo()
        {
            Console.WriteLine("Circle radius {0} and in the point X={1}, Y={2}", radius, Point.X, Point.Y);
        }
    }
}
