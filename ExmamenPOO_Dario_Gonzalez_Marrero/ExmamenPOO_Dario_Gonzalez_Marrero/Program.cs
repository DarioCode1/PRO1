namespace dario
{
    class Program
    {
        public static void Main(string[] args)
        {
            string nombre;
            int telefono;
            List<Juego> catalogo = new List<Juego> { 
                new Juego("Zelda",35.70m,new Alquiler()),
                new Juego("Mario",30m,new Alquiler()),
                new Juego("Sonic",27.40m,new Alquiler()),
                new Juego("Alex Kid",15.20m,new Alquiler()),
                new Juego("Wonder Boy",21.90m,new Alquiler())
            };
            Console.WriteLine("Escribe el nombre del encargado");
            nombre = Funciones.RecogerEncargado();
            Console.WriteLine("Escribe el numero de telefono del encargado");
            telefono = Funciones.RecogerTelefono();
            Tienda tienda = new Tienda(nombre,telefono,catalogo);
            int opcion = 0;
            do
            {
                Menu.VerMenu();
                opcion = Menu.LeerOpcion();
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        tienda.AlquilarJuego(Funciones.RecogerUsuario());
                        Console.ReadKey();
                        Console.WriteLine("\nPulsa una tecla para continuar...");
                        break;
                    case 2:
                        Console.Clear();
                        tienda.DevolverJuego(Funciones.RecogerUsuario());
                        Console.ReadKey();
                        Console.WriteLine("\nPulsa una tecla para continuar...");
                        break;
                    case 3:
                        Console.Clear();
                        tienda.InformacionTienda();
                        Console.ReadKey();
                        ; break;
                    case 4:
                        Console.Clear();
                        string juego = Funciones.Juego(tienda);
                        if (juego == null)
                            Console.WriteLine("El juego no existe");
                        else
                        {
                            Console.Clear();
                            tienda.VerHistorial(juego);
                            Console.ReadKey();
                        }
                        break;
                    default: break;
                }
            } while (opcion != 5);
        }
    }
}