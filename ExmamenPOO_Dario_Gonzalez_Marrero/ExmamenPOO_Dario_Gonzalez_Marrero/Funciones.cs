using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dario
{
    internal class Funciones
    {
        public static string RecogerEncargado ()
        {
            string encargado = Console.ReadLine();
            while (encargado.Length < 3)
            {
                Console.WriteLine("Error! el nombre del encargado tiene qu contener minimo 3 caracteres");
                encargado = Console.ReadLine();
            }
            return encargado;
        }
        public static int RecogerTelefono ()
        {
            string aux = Console.ReadLine();
            int telefono;
            while ((!int.TryParse(aux, out telefono)) || (aux.Length != 9) || (aux.Substring(0,3)!= "922"))
            {
                Console.WriteLine("Error! el telefono solo puede contener  9 digitos y debe empezar por 922");
                aux = Console.ReadLine();
            }

            return int.Parse(aux);
        }
        public static int RecogerUsuario()
        {
            int usuario;
            Console.WriteLine("Escribe el codigo del usuario");
            while((!int.TryParse(Console.ReadLine(), out usuario)) || (usuario < 100) || (usuario>999))
            {
                Console.WriteLine("Erro! el usuario tiene que ser un codigo de 3 digitos");
            }
            return usuario;
        }
        public static string Juego (Tienda tienda)
        {
            Console.WriteLine("Escribe el nombre del juego");
            string juego = Console.ReadLine();
            Juego ?juegoEncontrado = tienda.GetCatalogo().Find(Juego =>(Juego.GetNombre()==juego));
            if (juegoEncontrado == null)
                return "null";
            else
                return juego;
        }
    }
}
