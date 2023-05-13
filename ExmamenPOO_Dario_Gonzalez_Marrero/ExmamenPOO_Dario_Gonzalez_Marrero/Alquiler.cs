using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dario
{
    internal class Alquiler
    {
        private bool estado { get; set; }
        private int usuarioActual { get; set; }
        private List<int> historial { get; set; } = new List<int>();
        public Alquiler () { }
        public Alquiler(bool estado, int usuarioActual, List<int> historial)
        {
            this.estado = estado;
            this.usuarioActual = usuarioActual;
            this.historial = historial;
        }
        public void SetEstado(bool estado)
        {
            this.estado = estado;
        }
        public bool GetEstado()
        {
            return this.estado;
        }
        public void SetUsuarioActual(int usuario)
        {
            this.usuarioActual = usuario;
        }
        public int GetUsuarioActual()
        {
            return this.usuarioActual;
        }
        public void SetHistorial(int usuario)
        {
            historial.Add(usuario);
        }
        public List<int> GetHistorial()
        {
            return this.historial;
        }
    }
}
