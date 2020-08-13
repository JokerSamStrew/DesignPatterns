using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DesignPatterns.BehavioralPatterns.Observer
{
    //
    // Formal form
    //
    interface IObserver
    {
        void Update(Object ob = null);
    }
    interface IObservable
    { 
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
    
    class ConcreteObservable : IObservable
    {
        private List<IObserver> _observers;
        public ConcreteObservable()
        {
            _observers = new List<IObserver>();
        }

        public void AddObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }
        public void NotifyObservers()
        {
            foreach (IObserver observer  in _observers)
                observer.Update();
        }
    }

    class ConcreteObserver : IObserver
    {
        public void Update(object o = null) { }
    }
    
    //
    // Example
    //

    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            Bank bank = new Bank("UnitBank", stock);
            Broker broker = new Broker("Ivan Ivanych", stock);
            stock.Market();
            broker.StopTrade();
            stock.Market();
        }
    }

    class Stock : IObservable
    {
        StockInfo sInfo; 

        List<IObserver> _observers;
        public Stock()
        {
            _observers = new List<IObserver>();
            sInfo = new StockInfo();
        }
        public void AddObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }
        public void NotifyObservers()
        {
            foreach(IObserver o in _observers)
            {
                o.Update(sInfo);
            }
        }
        public void Market()
        {
            Random rnd = new Random();
            sInfo.USD = rnd.Next(20, 40);
            sInfo.Euro = rnd.Next(30, 50);
            NotifyObservers();
        }

    }


    class StockInfo
    {
        public int USD { get; set; }
        public int Euro { get; set; }
    }

    class Broker : IObserver
    {
        public string Name { get; set; }
        IObservable stock;
        public Broker(string name, IObservable obs)
        {
            this.Name = name;
            stock = obs;
            stock.AddObserver(this);
        }
        public void Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            if (sInfo.USD > 30)
                Console.WriteLine("Broker {0} sells dollars; Current exchange rate {1}", this.Name, sInfo.USD);
            else
                Console.WriteLine("Broker {0} buy dollars; Current exchange rate {1}", this.Name, sInfo.USD);
        }
        public void StopTrade()
        {
            stock.RemoveObserver(this);
            stock = null;
        }
    }
    class Bank : IObserver
    {
        public string Name { get; set; }
        IObservable stock;
        public Bank(string name, IObservable obs)
        {
            this.Name = name;
            stock = obs;
            stock.AddObserver(this);
        }
        public void Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            if (sInfo.Euro > 40)
                Console.WriteLine("Bank {0} sells euro; Current exchange rate {1}", this.Name, sInfo.Euro);
            else
                Console.WriteLine("Bank {0} buys euro; Current exchange rate {1}", this.Name, sInfo.Euro);
        }
    }
}
