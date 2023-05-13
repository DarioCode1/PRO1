using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace dario
{
    internal class Tienda
    {
        private string encargado { get; set; }
        private int telefono { get; set; }
        private List<Juego> catalogo { get; set; }

        public Tienda() { }
        public Tienda(string encargado,int telefono, List<Juego> catologo)
        {
            this.encargado = encargado;
            this.telefono = telefono;
            this.catalogo = catologo;
        }
        public void SetEncargado (string encargado)
        {
            this.encargado = encargado;
        }
        public string GetEncargado ()
        {
            return this.encargado;
        }
        public void SetTelefono (int telefono)
        {
            this.telefono= telefono;
        }
        public int GetTelefono ()
        {
            return this.telefono;
        }
        public void SetCatalogo(Juego juego)
        {
            if (catalogo != null)
                catalogo.Add(juego);
            else
                catalogo = new List<Juego>();
        }
        public List<Juego> GetCatalogo ()
        {
            return catalogo;
        }

        public void VerCatalogo ()
        {
            catalogo.ForEach(Juego => Console.WriteLine(Juego.ToString()));
        }
        public void AlquilarJuego (int usuario)
        {
            string nombreJuego;
            List<Juego> juegosDisponible = catalogo.FindAll(Juego => (!Juego.GetAlquiler().GetEstado()));
            Console.WriteLine("Elige el juego que deseas alquilar");
            juegosDisponible.ForEach(Juego => Console.WriteLine(Juego.ToString()));
            nombreJuego = Console.ReadLine();
            bool confirmarAlquiler = false;
            Juego ?usuarioConAlquiler = catalogo.Find(Juego => (Juego.GetAlquiler().GetUsuarioActual()==usuario));
            if (usuarioConAlquiler==null)
            {
                for (int i = 0; i < juegosDisponible.Count; i++)
                {
                    if (juegosDisponible[i].GetNombre() == nombreJuego)
                    {
                        juegosDisponible[i].GetAlquiler().SetEstado(true);
                        juegosDisponible[i].GetAlquiler().SetUsuarioActual(usuario);
                        confirmarAlquiler = true;
                    }
                }
                if (confirmarAlquiler)
                    Console.WriteLine("Se ha alquilado con exito");
                else
                    Console.WriteLine("El juego no existe o no se encuentra dispoible");
            }
            else
                Console.WriteLine("El usuario selecionado ya tiene un juego alquilado en estos momentos.\nDevuelve el juego primero si quieres alquilar otro");
        }
        public void DevolverJuego (int usuario)
        {
            bool confirmarAlquiler = false;
            for (int i = 0; i < catalogo.Count; i++)
            {
                if (catalogo[i].GetAlquiler().GetUsuarioActual() == usuario)
                {
                    catalogo[i].GetAlquiler().SetUsuarioActual(0);
                    catalogo[i].GetAlquiler().SetHistorial(usuario);
                    catalogo[i].GetAlquiler().SetEstado(false);
                    confirmarAlquiler = true;
                }
            }
            if (confirmarAlquiler)
                Console.WriteLine("Se ha devulto el juego correctamente");
            else
                Console.WriteLine("El usuario seleccina no tiene ningun juego en alquiler");
        }
        public void InformacionTienda()
        {
            List<Juego> juegosDisponible = catalogo.FindAll(Juego => (!Juego.GetAlquiler().GetEstado()));
            List<Juego> juegosAlquilados = catalogo.FindAll(Juego => (Juego.GetAlquiler().GetEstado()));
            Console.WriteLine("Encargado de tienda: " + encargado);
            Console.WriteLine("Telefono de tienda: " + telefono);
            Console.WriteLine("Juegos disponibles: ");
            juegosDisponible.ForEach(Juego => Console.WriteLine(Juego.ToString()));
            Console.WriteLine("\nJuegos alquilados: ");
            juegosAlquilados.ForEach(Juego => Console.WriteLine(Juego.ToString()));
        }
        public void VerHistorial(string juego)
        {
            Juego ?juegoSeleccionado = catalogo.Find(Juego=>(Juego.GetNombre()==juego));
            if (juegoSeleccionado != null)
            {
                Console.WriteLine(juegoSeleccionado.GetNombre());
                Console.WriteLine(juegoSeleccionado.GetPrecio());
                juegoSeleccionado.GetAlquiler().GetHistorial().ForEach(usuario => Console.WriteLine("Codigo usuario" + usuario));
                Console.WriteLine("\nEste juego a generado un total de: "+(juegoSeleccionado.GetPrecio()* juegoSeleccionado.GetAlquiler().GetHistorial().Count));
            }
        }
    }
}
