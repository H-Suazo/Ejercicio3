using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidad
{
    public class Usuario
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Clave { get; set; }
        public bool EstaActivo { get; set; }

        public Usuario()
        {
        }

        public Usuario(string codigo, string nombre, int edad, string clave, bool estaActivo)
        {
            Codigo = codigo;
            Nombre = nombre;
            Edad = edad;
            Clave = clave;
            EstaActivo = estaActivo;
        }
    }
}
