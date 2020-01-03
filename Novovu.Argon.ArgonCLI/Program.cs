using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Novovu.Argon;
namespace Novovu.Argon.ArgonCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the test case builder.
            if (args.Length > 0)
            {
                if (args[0] == "-r")
                {
                    if (args.Length > 2)
                    {
                        string comp = args[1];
                        string output = args[2];
                        Console.WriteLine("Starting Composition Render of " + comp);
                        Argon.ReadComposition(comp, output);

                    }
                    else
                    {
                        Console.WriteLine("Composition is not specified.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Argument");
                }
            }
            else
            {
                Console.WriteLine("Invalid Paramters.");
            }
        }
    }
    
}
