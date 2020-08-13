using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace DesignPatterns.CreationalPatterns.Singleton
{
    class Singleton
    {
        private static Singleton instance;

        private Singleton()
        { }

        public static Singleton getInstance()
        {
            if (instance ==  null)
                instance = new Singleton();
            return instance;
        }
    }

    public class SingletonInternal
    {
        public string Date { get; private set; }
        public static string text = "hello";
        private SingletonInternal()
        {
            Console.WriteLine($"Singleton ctor {DateTime.Now.TimeOfDay}");
            Date = DateTime.Now.TimeOfDay.ToString();
        }

        public static SingletonInternal GetInstance()
        {
            Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
            Thread.Sleep(500);
            return Nested.instance;
        }

        private class Nested
        {
            static Nested() { }
            internal static readonly SingletonInternal instance = new SingletonInternal();
        }
    }
    public class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> _lazy =
            new Lazy<SingletonLazy>(() => new SingletonLazy());

        public string Name { get; private set; }

        private SingletonLazy()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static SingletonLazy GetInstance()
        {
            return _lazy.Value;
        }
    }

    class OS
    {
        private static OS _instance;
        private static object _syncRoot = new Object();

        public string Name { get; private set; }

        protected OS(string name)
        {
            this.Name = name;
        }

        public static OS getInstance(string name)
        {
            if (_instance == null)
                lock (_syncRoot)
                {
                    if (_instance == null)
                        _instance = new OS(name);
                }
            
            return _instance;
        }
    }
}
