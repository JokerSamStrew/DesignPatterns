using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace DesignPatterns.BehavioralPatterns.Command
{
    //
    // Formal form
    //
    abstract class Command
    {
        public abstract void Execute();
        public abstract void Undo();
    }
    class ConcreteCommand : Command
    {
        Receiver receiver;
        public ConcreteCommand(Receiver r)
        {
            receiver = r;
        }
        public override void Execute()
        {
            receiver.Operation();
        }

        public override void Undo() {}
    }

    class Receiver
    {
        public void Operation() { }
    }

    class Invoker
    {
        Command command;
        public void SetCommand(Command c)
        {
            command = c;
        }
        public void Run()
        {
            command.Execute();
        }
        public void Cancel()
        {
            command.Undo();
        }
    }
    class Client
    {
        void Main()
        {
            Invoker invoker = new Invoker();
            Receiver receiver = new Receiver();
            ConcreteCommand command = new ConcreteCommand(receiver);
            invoker.SetCommand(command);
            invoker.Run();
        }
    }

    //      
    //  Example
    //      
    
    class Program
    {
        static void Main(string[] args)
        {
            TV  tv = new TV();
            Volume volume = new Volume();
            MultiPult mPult = new MultiPult();
            mPult.SetCommand(0, new TVOnCommand(tv));
            mPult.SetCommand(1, new VolumeCommand(volume));

            mPult.PressButton(0);

            mPult.PressButton(1);
            mPult.PressButton(1);
            mPult.PressButton(1);

            mPult.PressUndoButton();
            mPult.PressUndoButton();
            mPult.PressUndoButton();
            mPult.PressUndoButton();
        }
    }
    interface ICommand
    {
        public abstract void Execute();
        public abstract void Undo();
    }

    class TV
    {
        public void On()
        {
            Console.WriteLine("TV is ON");
        }
        public void Off()
        {
            Console.WriteLine("TV is Off");
        }
    }

    class TVOnCommand : ICommand
    {
        TV tv;
        public TVOnCommand(TV tvSet)
        {
            tv = tvSet;
        }
        public void Execute()
        {
            tv.On();
        }
        public void Undo()
        {
            tv.Off();
        }
    }
    class Volume
    {
        public const int OFF = 0;
        public const int HIGH = 20;
        private int _level;
        public Volume()
        {
            _level = OFF;
        }
        public void RaiseLevel()
        {
            if (_level < HIGH)
                _level++;
            Console.WriteLine("Volume Level {0}", _level);
        }
        public void DropLevel()
        {
            if (_level > OFF)
                _level--;
            Console.WriteLine("Volume Level {0}", _level);
        }
    }
    class VolumeCommand : ICommand
    {
        Volume _volume;
        public VolumeCommand(Volume v)
        {
            _volume = v;
        }
        public void Execute()
        {
            _volume.RaiseLevel();
        }
        public void Undo()
        {
            _volume.DropLevel();
        }
    }

    class NoCommand : ICommand
    {
        public void Execute() { }
        public void Undo() { }
    }

    class MultiPult
    {
        ICommand[] buttons;
        Stack<ICommand> commandsHistory;

        public MultiPult()
        {
            buttons = new ICommand[2];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new NoCommand();
            }
            commandsHistory = new Stack<ICommand>();
        }
        public void SetCommand(int number, ICommand com)
        {
            buttons[number] = com;
        }
        public void PressButton(int number)
        {
            buttons[number].Execute();
            commandsHistory.Push(buttons[number]);
        }
        public void PressUndoButton()
        {
            if(commandsHistory.Count > 0)
            {
                ICommand undoCommand = commandsHistory.Pop();
                undoCommand.Undo();
            }
        }
    }

}
