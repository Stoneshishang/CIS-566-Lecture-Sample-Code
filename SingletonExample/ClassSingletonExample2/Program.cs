using System;

namespace ClassSingletonExample2
{
    // "Singleton"
    class Singleton
    {
        private static Singleton instance;
        protected Singleton()
        { }
        public static Singleton Instance()
        {
            // Use 'Lazy initialization'
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
    class MainApp
    {
        static void Main()
        {
            // Constructor is protected -- cannot use new
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();
            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }
            else
            {
                Console.WriteLine("Objects are different instance");
            }
               
            // Wait for user
            Console.Read();
        }
    }
}