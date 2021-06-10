using System;
using System.Linq;
using oracleuuid.Converters;

namespace oracleuuid
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (!args.Any())
            {
                Console.WriteLine("no arguments");
                Console.WriteLine("Run 'oracleuuid --help' for more information.");
                return;
            }

            if (args[0] == "--help")
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine("Commands:");
                Console.WriteLine("   -h <hex value>      Convert hexadecimal to guid");
                Console.WriteLine("   -g <guid value>     Convert guid to hexadecimal");
                Console.WriteLine(string.Empty);

                return;
            }

            if (!UuIdConverter.TryParseType(args[0], out var type) || args.Length == 1)
            {
                Console.WriteLine("invalid argument");
                Console.WriteLine("Run 'oracleuui --help' for more information.");
                return;
            }

            var converted = UuIdConverter.ConvertFromString(type, args[1].Trim());

            Console.WriteLine(string.Empty);
            Console.WriteLine(converted);
        }
    }
}