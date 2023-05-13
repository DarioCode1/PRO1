using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dario
{
    internal class Menu
    {
        public static void VerMenu()
        {
            Console.Clear();
            Console.WriteLine("Elija un a de las siguientes opciones:");
            Console.WriteLine("1. Alquilar juego");
            Console.WriteLine("2. Devolver juego");
            Console.WriteLine("3. Mostrar info tienda");
            Console.WriteLine("4. Mostrar historial");
            Console.WriteLine("5. Cerrar programa...");
        }
        public static void Adios()
        {
            Console.WriteLine("Pulsa una tecla para finalizar...");
            Console.ReadKey();
        }
        public static int LeerOpcion()
        {
            ConsoleKeyInfo tecla;
            int valor;
            do
            {
                valor = 0;
                tecla = Console.ReadKey(true);
                switch (tecla.KeyChar)
                {
                    case '1': valor = 1; break;
                    case '2': valor = 2; break;
                    case '3': valor = 3; break;
                    case '4': valor = 4; break;
                    case '5': valor = 5; break;
                    default: break;
                }
            } while (valor == 0);
            return (valor);
        }
    }
}
