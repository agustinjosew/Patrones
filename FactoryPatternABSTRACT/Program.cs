using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternABSTRACT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vos sos un (A)dulto o una (B)endi?");
            char opc    = Console.ReadKey().KeyChar;
            char opcion = char.ToUpper(opc);

            RecetaFactory factory;

            switch(opcion)
            {
                case 'A':
                    factory = new ComidaAdultosFactory();
                    Console.WriteLine("\nMenu de los adultos: ");
                    break;
                case 'B':
                    factory = new ComidaParaLasBendis();
                    Console.WriteLine("\nMenu de las bendis: ");
                    break;

                default:
                    throw new NotImplementedException();
            }

            var comida = factory.CrearPlatoPrincipal();
            var postre = factory.CrearPostre();

            Console.WriteLine("\nComida: " + comida.GetType().Name);
            Console.WriteLine("\nPostre: " + postre.GetType().Name);

            Console.ReadKey();
        }
    }
}
