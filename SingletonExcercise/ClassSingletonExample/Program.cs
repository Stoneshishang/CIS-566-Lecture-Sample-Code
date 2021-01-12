using System;

namespace ClassSingletonExample
{
    public class Spooler
    {
        private static bool instance_flag = false;
        private Spooler()
        {
        }
        public static Spooler getSpooler()
        {
            if (!instance_flag)
            {
                instance_flag = true;
                return new Spooler();
            }
            else
            {
                return null;
            }
        }
        class GlobSpooler
        {
            static void Main(string[] args)
            {
                Spooler sp1 = Spooler.getSpooler();
                if (sp1 != null)
                    Console.WriteLine("Got 1 spooler");
                Spooler sp2 = Spooler.getSpooler();
                if (sp2 == null)
                    Console.WriteLine("Can\'t get second spooler");
                //fails at compile time
                //Spooler sp3 = new Spooler ();
            }
        }
    }
}
