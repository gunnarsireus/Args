using com.cleancoder.args;
using System;
using System.Globalization;

namespace com.cleancoder.args
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Args arg = new Args("l,p#,d*", new string[3] {"-l","-37","-hejsan" });
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
            Main(new string[13] { "-f", "-s", "Bob","-n", "1", "-a", "3.2", "-p", "e1", "-p", "e2", "-p", "e3" });
        }
    }
}
