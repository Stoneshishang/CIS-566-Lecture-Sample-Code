using System;

namespace ProxyPatternExercise
{
    public interface IClient
    {
        string GetAccountNo();
    }

    public class RealClient : IClient
    {
        private string accountNo = "12345";
        public RealClient()
        {
            Console.WriteLine("RealClient: Initialized");
        }
        public string GetAccountNo()
        {
            Console.WriteLine("RealClient's AccountNo: " + accountNo);
            return accountNo;
        }
    }

    public class ProtectionProxy : IClient
    {
        private string password;
        //password to get secret
        RealClient client;
        public ProtectionProxy(string pwd)
        {
            Console.WriteLine("ProtectionProxy:Initialized");
            password = pwd;
            client = new RealClient();
        }
    

    // Authenticate the user and return the Account Number
        public String GetAccountNo()
        {
        Console.Write("Password: ");
        string tmpPwd = Console.ReadLine();
        if (tmpPwd == password)
        {
            return client.GetAccountNo();
        }
        else
        {
            Console.WriteLine(" Illegal password!");
            return "";
        }
        }
    }
    class ProtectionProxyExample
    {
        public static void Main(string[] args)
        {
            IClient client = new ProtectionProxy("thePassword");
            Console.WriteLine();
            Console.WriteLine("main received: " + client.GetAccountNo());
            Console.WriteLine("\nPress any key to continue . . .");
            Console.Read();
        }
    }
}
