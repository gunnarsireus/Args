using System;

namespace Args
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Args arg = new Args("l,p#,d*", args);
                bool logging = arg.getBoolean('l');
                int port = arg.getInt('p');
                string directory = arg.getString('d');
                executeApplication(logging, port, directory);
            }
            catch (ArgsException e)
            {
                Console.Write("Argument error: {0}\n", e.errorMessage());
            }
        }
        private static void executeApplication(bool logging, int port, string directory)
        {
            Console.Write("logging is {0}, port:{1:D}, directory:{2}\n", logging, port, directory);
            Console.ReadKey();
        }
    }
}
