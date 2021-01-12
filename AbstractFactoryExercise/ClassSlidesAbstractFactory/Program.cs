using System;

namespace ClassSlidesAbstractFactory
{
    class Program
    {
        abstract class AbstractFactoryWidget
        {
            public abstract AbstractTextField
            CreateTextField();
            public abstract AbstractPushButton
            CreatePushButton();
        }

        class ConcreteWindow : AbstractFactoryWidget
        {
            public override AbstractTextField CreateTextField()
            {
                return new TextFieldWindow();
            }
            public override AbstractPushButton CreatePushButton()
            {
                return new PushButtonWindow();
            }
        }
        class ConcreteMac : AbstractFactoryWidget
        {
            public override AbstractTextField CreateTextField()
            {
                return new TextFieldMac();
            }
            public override AbstractPushButton CreatePushButton()
            {
                return new PushButtonMac();
            }
        }

        // "AbstractTextField"
        abstract class AbstractTextField
        {
            public abstract void DisplayName(AbstractTextField a);
        }
        // "AbstractPushButton"
        abstract class AbstractPushButton
        {
            public abstract void DisplayName(AbstractPushButton a);
        }

        // "Concrete TextFieldWindow"
        class TextFieldWindow : AbstractTextField
        {
            public override void DisplayName(AbstractTextField a)
            {
                Console.WriteLine(" This is Window Text Field as " + a.GetType().Name);
            }
        }
        // "Concrete PushButtonWindow"
        class PushButtonWindow : AbstractPushButton
        {
            public override void DisplayName(AbstractPushButton a)
            {
                Console.WriteLine(" This is Window Button as " + a.GetType().Name);
            }
        }
        // "Concrete TextFieldMac"
        class TextFieldMac : AbstractTextField
        {
            public override void DisplayName(AbstractTextField a)
            {
                Console.WriteLine(" This is Mac TextField as " + a.GetType().Name);
            }
        }
        // "Concrete PushButtonMac"
        class PushButtonMac : AbstractPushButton
        {
            public override void DisplayName(AbstractPushButton a)
            {
                Console.WriteLine(" This is Mac Button as " + a.GetType().Name);
            }
        }


        class Client
        {
            private AbstractTextField AbstractTextField;
            private AbstractPushButton AbstractPushButton;
            // Constructor
            public Client(AbstractFactoryWidget factory)
            {
                AbstractPushButton = factory.CreatePushButton();
                AbstractTextField = factory.CreateTextField();
            }
            public void Run()
            {
                AbstractPushButton.DisplayName(AbstractPushButton);
                AbstractTextField.DisplayName(AbstractTextField);
            }
        }



        static void Main(string[] args)
        {
            AbstractFactoryWidget FactoryWindow = new ConcreteWindow();
            Client c1 = new Client(FactoryWindow);
            c1.Run();
            AbstractFactoryWidget FactoryMac = new ConcreteMac();
            Client c2 = new Client(FactoryMac);
            c2.Run();
            Console.Read();
        }
    }
}

