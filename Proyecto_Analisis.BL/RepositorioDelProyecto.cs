using Proyecto_Analisis.DA;
using Proyecto_Analisis.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Proyecto_Analisis.BL
{
    public class RepositorioDelProyecto : IRepositorioDelProyecto
    {

        private ContextoDeBaseDeDatos ElContextoDeBaseDeDatos;
        public RepositorioDelProyecto(ContextoDeBaseDeDatos contexto)
        {
            ElContextoDeBaseDeDatos = contexto;

        }

        public List<Persona> ObtenerTodosLosClientes()
        {
            List<Persona> Lalista;
            Lalista = ElContextoDeBaseDeDatos.Persona.ToList();
            return Lalista;
        }
    }
}
