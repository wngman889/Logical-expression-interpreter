using System;
using System.Collections.Generic;
using System.IO;

namespace Kursowa_rabota_SAA
{
    class Program
    {
        static void Main(string[] args)
        {
            var cal = new Rpn();//new reverse polish notation
            cal.RegisterOperator(new LogicalAnd());//registering operators
            cal.RegisterOperator(new LogicalOr());
            cal.RegisterOperator(new LogicalNot());
            string expression;
            // string path;
            do
            {
                Console.Write("\nDEFINE: ");
                expression = Console.ReadLine();

                if (expression != null)
                    Console.WriteLine("Defined!");
                //if (!File.Exists(path))
                //{
                //    Console.WriteLine($"This file does not exists {path}");
                //    return;
                //}
                 //expression = File.ReadAllText(path);
                    var result = cal.Evaluate(expression);
                Console.Write($"\nResult: {result}");
                string file = Convert.ToString(result);
                File.WriteAllText(@"E:/container.txt", file);
            } while (expression != null); //&& expression != "");
            //if (File.Exists("@E:/storage.txt")
        }
    }
}
