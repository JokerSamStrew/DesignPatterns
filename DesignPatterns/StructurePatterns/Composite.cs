using DesignPatterns.StructurePatterns.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.StructurePatterns.Composite
{
    class Client
    {
        public void Main()
        {
            Component root = new Composite("Root");
            Component leaf = new Leaf("Leaf");
            Component subtree = new Composite("Subtree");
            root.Add(leaf);
            root.Add(subtree);
            root.Display();
        }
    }
    abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }
        public abstract void Display();
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
    }
    class Composite : Component
    {
        List<Component> children = new List<Component>();
        public Composite(string name) : base(name) { }
        public override void Display()
        {
            Console.WriteLine(name);
            foreach (Component component in children)
                component.Display();
        }
        public override void Add(Component c)
        {
            children.Add(c);
        }
        public override void Remove(Component c)
        {
            children.Remove(c);
        }
    }
    class Leaf : Component
    {
        public Leaf(string name) : base(name) { }
        public override void Display()
        {
            Console.WriteLine(name);
        }
        public override void Add(Component c)
        {
            throw new NotImplementedException();
        }
        public override void Remove(Component c)
        {
            throw new NotImplementedException();
        }
    }
}
