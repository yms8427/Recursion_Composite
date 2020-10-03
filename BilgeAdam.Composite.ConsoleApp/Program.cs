using BilgeAdam.OOP.Composite.Enums;
using BilgeAdam.OOP.Composite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Composite.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Recursive Sample
            //var bs = new BasicSample();
            //var f1 = bs.GetFactorial(5);
            //var f2 = bs.GetFactorial(4);
            //var f3 = bs.GetFactorial(7);
            //Console.WriteLine(f1);
            //Console.WriteLine(f2);
            //Console.WriteLine(f3);
            //Console.ReadKey(); 
            #endregion

            var root = LoadHierarchy();
            PrintHierarchy(root);
            Console.ReadLine();
        }

        private static void PrintHierarchy(Person root)
        {
            var dash = string.Concat(Enumerable.Repeat("-", root.Level * 2));
            if (!string.IsNullOrEmpty(dash))
            {
                Console.Write("|");
            }
            Console.WriteLine($"{dash}> {root.FullName}".TrimStart());
            if (root.HasChildren)
            {
                foreach (var child in root.Children)
                {
                    PrintHierarchy(child);
                }
            }
        }

        private static Person LoadHierarchy()
        {
            var person = new Person("Ahmet Yıldız", Gender.Male);
            var c1 = new Person("Güliz Ayla", Gender.Female);
            var c2 = new Person("Gülay Demir", Gender.Female);
            person.AddChild(c1);
            person.AddChild(c2);
            var c11 = new Person("Ayla Perk", Gender.Female);
            var c12 = new Person("Ferhat Ayla", Gender.Male);
            var c13 = new Person("Serhat Ayla", Gender.Male);
            c1.AddChildren(c11, c12, c13);
            var c22 = new Person("Cenk Demir", Gender.Male);
            var c23 = new Person("Berk Demir", Gender.Male);
            c2.AddChildren(c22, c23);
            var c111 = new Person("Can Perk", Gender.Male);
            var c112 = new Person("Canan Perk", Gender.Female);
            c11.AddChildren(c111, c112);

            return person;
        }
    }

    class BasicSample
    {
        public int GetFactorial(int number)
        {
            var result = 1;
            if (number > 1)
            {
                result = number * GetFactorial(number - 1);
            }

            return result;
        }
    }
}
