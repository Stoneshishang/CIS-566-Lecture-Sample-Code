using System;

namespace CommandPatternExercise
{
    class Program
    {
        // "Command_order"
        abstract class Command_order
        {
            protected Receiver_Cook Receiver_Cook;
            public Command_order()
            {
            }
            public abstract void Execute_Orderup();
        }


        // "ConcreteCommand_order"
        class ConcreteCommand_order : Command_order
        {
            // Constructor
            public ConcreteCommand_order(Receiver_Cook Receiver_Cook)
            {
                this.Receiver_Cook = Receiver_Cook;
            }
            public override void Execute_Orderup()
            {
                Receiver_Cook.MakeBurger();
                Receiver_Cook.MakeShake();
            }
        }

        // "Receiver_Cook"
        class Receiver_Cook
        {
            public void MakeBurger()
            {
                Console.WriteLine("Make a Cheese Burger");
            }
            public void MakeShake()
            {
                Console.WriteLine("Make a Malt Shake");
            }
        }

        // "invoker_Waitress"
        class invoker_Waitress
        {
            private Command_order command_order;
            public void SetCommand_TakeOrder(Command_order command_order)
            {
                this.command_order = command_order;
            }
            public void Orderup()
            {
                command_order.Execute_Orderup();
            }
        }

        static void Main()
        {
            // Create Receiver_Cook, command, and invoker_Waitress
            Receiver_Cook Receiver_Cook = new Receiver_Cook();
            Command_order command_order = new ConcreteCommand_order(Receiver_Cook);
            invoker_Waitress invoker_Waitress = new invoker_Waitress();
            // Set and execute command_order
            invoker_Waitress.SetCommand_TakeOrder(command_order);
            invoker_Waitress.Orderup();
            // Wait for user
            Console.Read();
        }
    }
}
