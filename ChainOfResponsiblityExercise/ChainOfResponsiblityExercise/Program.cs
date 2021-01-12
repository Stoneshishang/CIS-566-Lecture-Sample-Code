using System;

namespace ChainOfResponsiblityExercise
{
    // "Handler"
    abstract class PurchaseHandler
    {
        protected PurchaseHandler successor;
        public void SetSuccessor(PurchaseHandler successor)
        {
            this.successor = successor;
        }
        public abstract void HandleRequest(double PurchaseAmount);
    }

    // "ProgramManager"
    class ProgramManager : PurchaseHandler
    {
        public override void HandleRequest(double PurchaseAmount)
        {
            if (PurchaseAmount < 50000)
            {
                Console.WriteLine("Request was sent to {0} to approve amount ${1}",
                this.GetType().Name, PurchaseAmount);
            }
            else if (successor != null)
            {
                successor.HandleRequest(PurchaseAmount);
            }
        }
    }

    // "DistrictManager"
    class DistrictManager : PurchaseHandler
    {
        public override void HandleRequest(double PurchaseAmount)
        {
            if (PurchaseAmount >= 50000 && PurchaseAmount < 1000000)
            {
                Console.WriteLine("Request was sent to {0} to approve amount ${1}",
                this.GetType().Name, PurchaseAmount);
            }
            else if (successor != null)
            {
                successor.HandleRequest(PurchaseAmount);
            }
        }
    }

    // "COO"
    class COO : PurchaseHandler
    {
        public override void HandleRequest(double PurchaseAmount)
        {
            if (PurchaseAmount >= 1000000)
            {
                Console.WriteLine("Request was sent to {0} to approve amount ${1}",
                this.GetType().Name, PurchaseAmount);
            }
            else if (successor != null)
            {
                successor.HandleRequest(PurchaseAmount);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Setup Chain of Responsibility
            PurchaseHandler programmanager = new ProgramManager();
            PurchaseHandler districtmanager = new DistrictManager();
            PurchaseHandler coo = new COO();
            programmanager.SetSuccessor(districtmanager);
            districtmanager.SetSuccessor(coo);
            // Generate and process request
            double[] requests = { 42000, 55000, 114000, 920000, 1800000, 63000 };
            foreach (double PurchaseAmount in requests)
            {
                programmanager.HandleRequest(PurchaseAmount);
            }
            // Wait for user
            Console.Read();
        }
    }
}
