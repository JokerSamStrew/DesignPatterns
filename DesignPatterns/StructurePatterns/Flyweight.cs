using DesignPatterns.BehavioralPatterns.Iterator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.StructurePatterns.Flyweight
{
    class FlyweightFactory
    {
        Hashtable flyweights = new Hashtable();
        public FlyweightFactory()
        {
            flyweights.Add("X", new ConcreteFlyweight());
            flyweights.Add("Y", new ConcreteFlyweight());
            flyweights.Add("Z", new ConcreteFlyweight());
        }
        public Flyweight GetFlyweight(string key)
        {
            if(!flyweights.ContainsKey(key))
                flyweights.Add(key, new ConcreteFlyweight());
            return flyweights[key] as Flyweight;
        }
    }
    abstract class Flyweight
    {
        public abstract void Operation(int extrinsicState);
    }
    class ConcreteFlyweight : Flyweight
    {
        int intrinsicState;
        public override void Operation(int extrinsicState) { }
    }
    class UnsharedConcreteFlyweight : Flyweight
    {
        int allState;
        public override void Operation(int extrinsicState)
        {
            allState = extrinsicState;
        }
    }
    class Client
    {
        void Main()
        {
            int extrinsicstate = 22;
            FlyweightFactory f = new FlyweightFactory();

            Flyweight fx = f.GetFlyweight("X");
            fx.Operation(--extrinsicstate);

            Flyweight fy = f.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);

            Flyweight fd = f.GetFlyweight("D");
            fd.Operation(--extrinsicstate);

            UnsharedConcreteFlyweight uf = new UnsharedConcreteFlyweight();

            uf.Operation(--extrinsicstate);
        }
    }

    //
    // Example
    //
    class Program
    {
        static void Main()
        {
            double longitude = 37.61;
            double latitude = 55.74;

            HouseFactory houseFactory = new HouseFactory();
            for (int i = 0; i < 5; i++)
            {
                House panelHouse = houseFactory.GetHouse("Panel");
                if (panelHouse != null)
                    panelHouse.Build(longitude, latitude);

                longitude += 0.1;
                latitude += 0.1;
            }

            for (int i = 0; i < 5; i++)
            {
                House brickHouse = houseFactory.GetHouse("Brick");
                if (brickHouse != null)
                    brickHouse.Build(longitude, latitude);

                longitude += 0.1;
                latitude += 0.1;
            }
        }
    }
    abstract class House
    {
        protected int stages;
        public abstract void Build(double longtitude, double latitude);
    }
    class PanelHouse : House
    {
        public PanelHouse()
        {
            stages = 16;
        }
        public override void Build(double longtitude, double latitude)
        {
            Console.WriteLine("Panel house built, 16 levels. Coords: {0} latitude and {1} longitude", latitude, longtitude);
        }
    }
    class BrickHouse : House
    {
        public BrickHouse()
        {
            stages = 5;
        }

        public override void Build(double longtitude, double latitude)
        {
            Console.WriteLine("Brick house built, 5 levels. Coords: {0} latitude and {1} longitude", latitude, longtitude);
        }
    }
    class HouseFactory
    {
        Dictionary<string, House> houses = new Dictionary<string, House>();
        public HouseFactory()
        {
            houses.Add("Panel", new PanelHouse());
            houses.Add("Brick", new BrickHouse());
        }
        public House GetHouse(string key)
        {
            if (houses.ContainsKey(key))
                return houses[key];
            else
                return null;
        }
    }
}
