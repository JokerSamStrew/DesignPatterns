using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DesignPatterns.BehavioralPatterns.Interpreter
{
    //
    // Formal form
    //

    class Client
    {
        void Main()
        {
            Context context = new Context();

            var expression = new NonTerminalExpression();
            expression.Interpret(context);
        }
    }

    //class Context { }

    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
        }
    }

    class NonTerminalExpression : AbstractExpression
    {
        AbstractExpression expression1;
        AbstractExpression expression2;
        public override void Interpret(Context context)
        {
        }
    }

    //
    // Example
    //

    /*  Grammatic 
        
        IExpression ::= NumberExpression | Constant | AddExpression | SubstractExpression 
        AddExpression ::= IExpression + IExpression
        SubstractExpression ::= IExpression - IExpression
        NumberExpression ::= [A-Z,a-z]+
        Constant ::= [1-9]+
    */

    class Program
    {
        static void Main()
        {
            Context context = new Context();
            int x = 5;
            int y = 8;
            int z = 2;

            context.SetVariable("x", x);
            context.SetVariable("y", y);
            context.SetVariable("z", z);

            IExpression expression = new SubtractExpression(
                new AddExpression(
                    new NumberExpression("x"),
                    new NumberExpression("y")
                    ),
                new NumberExpression("z")
               
            );

            int result = expression.Interpret(context);
            Console.WriteLine("Result: {0}", result);
        }
    }
    class Context
    {
        Dictionary<string, int> variables;
        public Context()
        {
            variables = new Dictionary<string, int>();
        }
        public int GetVariable(string name)
        {
            return variables[name];
        }
        public void SetVariable(string name, int value)
        {
            if (variables.ContainsKey(name))
                variables[name] = value;
            else
                variables.Add(name, value);
        }
    }
    interface IExpression
    {
        int Interpret(Context context);
    }
    class NumberExpression : IExpression
    {
        string name;
        public NumberExpression(string variableName)
        {
            name = variableName;
        }
        public int Interpret(Context context)
        {
            return context.GetVariable(name);
        }
    }
    class AddExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;

        public AddExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }
        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) + rightExpression.Interpret(context);
        }
    }
    class SubtractExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;
        public SubtractExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) - rightExpression.Interpret(context);
        }
    }
}
