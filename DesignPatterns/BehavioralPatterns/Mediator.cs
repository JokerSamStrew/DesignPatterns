using System;

namespace DesignPatterns.BehavioralPatterns.Mediator
{
    //
    // Formal form
    //
    abstract class Mediator1
    {
        public abstract void Send(string msg, Colleague1 colleage);
    }
    abstract class Colleague1
    {
        protected Mediator1 mediator;
        public Colleague1(Mediator1 mediator)
        {
            this.mediator = mediator;
        }
    }
    class ConcreteColleague1 : Colleague1
    {
        public ConcreteColleague1(Mediator1 mediator) : base(mediator) { }
        public void Send(string message)
        {
            mediator.Send(message, this);
        }
        public void Notify(string message) { }
    }
    class ConcreteColleague2 : Colleague1
    {
        public ConcreteColleague2(Mediator1 mediator) : base(mediator) { }
        public void Send(string message)
        {
            mediator.Send(message, this);
        }
        public void Notify(string message) { }
    }
    class ConcreteMediator : Mediator1
    {
        public ConcreteColleague1 Colleague1 { get; set; }
        public ConcreteColleague2 Colleague2 { get; set; }
        public override void Send(string msg, Colleague1 colleage)
        {
            if (Colleague1 == colleage)
                Colleague2.Notify(msg);
            else
                Colleague1.Notify(msg);
        }
    }
    //
    // Example
    //

    class Program
    {
        static void Main()
        {
            ManagerMediator mediator = new ManagerMediator();
            Colleague customer = new CustomerColleague(mediator);
            Colleague programmer = new ProgrammerColleague(mediator);
            Colleague tester = new TesterColleague(mediator);
            mediator.Customer = customer;
            mediator.Programmer = programmer;
            mediator.Tester = tester;
            customer.Send("New order, need to create program");
            programmer.Send("Program ready, need to test");
            tester.Send("Program tested and ready for deploying");
        }

    }
    abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }
    abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }
        public abstract void Notify(string message);
    }
    class CustomerColleague : Colleague
    {
        public CustomerColleague(Mediator mediator) : base(mediator) { }
        public override void Notify(string message)
        {
            Console.WriteLine("Message for stakeholder: " + message);
        }
    }
    class ProgrammerColleague : Colleague
    {
        public ProgrammerColleague(Mediator mediator) : base(mediator) { }
        public override void Notify(string message)
        {
            Console.WriteLine("Message for programmer: " + message);
        }
    }
    class TesterColleague : Colleague
    {
        public TesterColleague(Mediator mediator) : base(mediator) { }
        public override void Notify(string message)
        {
            Console.WriteLine("Message for tester: " + message);
        }
    }
    class ManagerMediator : Mediator
    {
        public Colleague Customer { get; set; }
        public Colleague Programmer { get; set; }
        public Colleague Tester{ get; set; }
        public override void Send(string msg, Colleague colleague)
        {
            if (Customer == colleague)
                Programmer.Notify(msg);
            else if (Programmer == colleague)
                Tester.Notify(msg);
            else if (Tester == colleague)
                Customer.Notify(msg);
        }
    }
}
