using System;

namespace CommandPatternExample
{
    class Program
    {
        // MainApp test applicatio
        class MainApp
        {
            static void Main()
            {
                // Create receiver, command, and invoker
                Receiver receiver = new Receiver();
                Command command = new ConcreteCommand(receiver);
                Invoker invoker = new Invoker();
                // Set and execute command
                invoker.SetCommand(command);

                invoker.ExecuteCommand();
            }
            abstract class Command
            {
                protected Receiver receiver;
                // Constructor
                public Command()
                { }
                public abstract void Execute();
            }
            // "ConcreteCommand"
            class ConcreteCommand : Command
            {
                // Constructor
                public ConcreteCommand(Receiver receiver)
                {
                    this.receiver = receiver;
                }
                public override void Execute()
                {
                    receiver.Action();
                }
            }

            // "Receiver"
            class Receiver
            {
                public void Action()
                {
                    Console.WriteLine(" Hello, I received your command");
                }
            }
            // "Invoker"
            class Invoker
            {
                private Command command;
                public void SetCommand(Command command)
                {
                    this.command = command;
                }
                public void ExecuteCommand()
                {
                    command.Execute();
                }
            }
        }
   }
}
