using DesignPatterns.CreationalPatterns.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralPatterns.Memento
{
    //
    // Formal form
    //
    class Memento
    {
        public string State { get; private set; }
        public Memento(string state)
        {
            this.State = state;
        }
    }
    class Caretaker
    {
        public Memento Memento { get; set; }
    }
    class Originator
    {
        public string State { get; set; }
        public void SetMemento(Memento memento)
        {
            State = memento.State;
        }
        public Memento CreateMemento()
        {
            return new Memento(State);
        }
    }
    //
    // Example
    //
    class Program
    {
        static void Main()
        {
            Hero hero = new Hero();
            hero.Shoot();
            GameHistory game = new GameHistory();

            game.History.Push(hero.SaveState());
            hero.Shoot();
            hero.RestoreState(game.History.Pop());
            hero.Shoot();
        }
    }
    class Hero
    {
        private int patrons = 10;
        private int lives = 5;
        public void Shoot()
        {
            if (patrons > 0)
            {
                patrons--;
                Console.WriteLine("Make shoot, {0} bullets left", patrons);
            }
            else
                Console.WriteLine("No bullets left");
        }
        public HeroMemento SaveState()
        {
            Console.WriteLine("Save state. {0} bullets, {1} Lives", patrons, lives);
            return new HeroMemento(patrons, lives);
        }
        public void RestoreState(HeroMemento memento)
        {
            this.patrons = memento.Patrons;
            this.lives = memento.Lives;
            Console.WriteLine("Restore state. {0} bullets, {1} lives", patrons, lives);
        }
    }
    class HeroMemento
    {
        public int Patrons { get; private set; }
        public int Lives { get; private set; }
        public HeroMemento(int patrons, int lives)
        {
            this.Patrons = patrons;
            this.Lives = lives;
        }
    }
    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }
}
