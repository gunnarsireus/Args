using com.cleancoder.args;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace com.cleancoder.args
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var arg = new Args("l,p#,d*", args);
                bool logging = arg.getBoolean('l');
                int port = arg.getInt('p');
                string directory = arg.getString('d');
                ExecuteApplication(logging, port, directory);
            }
            catch (ArgsException e)
            {
                Console.Write("Argument error: {0}\n", e.errorMessage());
                Console.ReadKey();
            }
        }
        private static void ExecuteApplication(bool logging, int port, string directory)
        {
            Console.Write("logging is {0}, port:{1:D}, directory:{2}\n", logging, port, directory);
            var args = new Args("f&", new string[] { "-f", "key1:val1" });
            IDictionary<string, string> map = args.getMap('f');
            Console.Write("map[key1]: " + map["key1"]);
            Console.ReadKey();
        }
    }
}
