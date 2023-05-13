using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dario
{
    internal class Juego
    {
        private string nombre { get; set; }
        private decimal precio { get; set; }
        private Alquiler alquiler { get; set; }
        public Juego () { }
        public Juego (string nombre, decimal precio, Alquiler alquiler)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.alquiler = alquiler;
        }
        public void SetNombre (string nombre)
        {
            if (nombre == null)
                throw new ArgumentNullException("El nombre no puede ser nulo");
            else
                this.nombre = nombre;
        }
        public string GetNombre ()
        {
            return this.nombre;
        }
        public void SetPrecio(Decimal precio)
        {
            if (precio <= 0)
                throw new ArgumentNullException("El precio no puede ser menor que 0 o 0");
            else
                this.precio = precio;
        }
        public decimal GetPrecio()
        {
            return this.precio;
        }
        public void SetAlquiler(Alquiler alquiler)
        {
            this.alquiler = alquiler;
        }
        public Alquiler GetAlquiler()
        {
            return this.alquiler;
        }
        public override string ToString()
        {
            return GetNombre()+" - "+GetPrecio();
        }
    }
}
