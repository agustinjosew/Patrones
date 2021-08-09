using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sandwich> Sandwiches = new List<Sandwich>();
            Sandwiches.Add(new MilanesaSandwich());
            Sandwiches.Add(new JamonSandwich());

            foreach(var sandwich in Sandwiches)
            {
                Console.WriteLine("\nSandwich : " + sandwich.GetType().Name + " ");
                foreach(var ingrediente in sandwich.Ingredientes)
                {
                    Console.WriteLine("ingrediente: " + ingrediente.GetType().Name);
                }
            }
            Console.ReadKey();
        }   
    }
}
