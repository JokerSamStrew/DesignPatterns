using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;
using System.Text;

namespace DesignPatterns.BehavioralPatterns.State
{
    //
    // Formal form
    //
    class Client
    {
        static void Main()
        {
            Context context = new Context(new StateA());
            context.Request(); // StateB
            context.Request(); // StateA
        }
    }
    abstract class State
    {
        public abstract void Handle(Context context);
    }
    class StateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateB();
        }
    }
    class StateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateA();
        }
    }
    class Context
    {
        public State State { get; set; }
        public Context(State state)
        {
            this.State = state;
        }
        public void Request()
        {
            this.State.Handle(this);
        }
    }

    //
    // Example
    //
    class Program
    {
        static void Main()
        {
            Water water = new Water(new LiquidWaterState());
            water.Heat();
            water.Frost();
            water.Frost();
        }
    }
    class Water
    {
        public IWaterState State { get; set; }
        public Water(IWaterState ws)
        {
            State = ws;
        }
        public void Heat()
        {
            State.Heat(this);
        }
        public void Frost()
        {
            State.Frost(this);
        }
    }
    interface IWaterState
    {
        void Heat(Water water);
        void Frost(Water water);
    }
    class SolidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Turn ice to water");
            water.State = new LiquidWaterState();
        }
        public void Frost(Water water)
        {
            Console.WriteLine("Keep freezing ice");
        }
    }
    class LiquidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Turn water into steam");
            water.State = new GasWaterState();
        }
        public void Frost(Water water)
        {
            Console.WriteLine("Turn water into ice");
            water.State = new SolidWaterState();
        }
    }
    class GasWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Increase steam temperature");

        }
        public void Frost(Water water)
        {
            Console.WriteLine("Turn steam into water");
            water.State = new LiquidWaterState();

        }
    }
}
