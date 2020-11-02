using Proyecto_Analisis.DA;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Analisis.BL
{
    class RepositorioDelProyecto : IRepositorioDelProyecto
    {

        private ContextoDeBaseDeDatos ElContextoDeBaseDeDatos;
        public RepositorioDelProyecto(ContextoDeBaseDeDatos contexto)
        {
            ElContextoDeBaseDeDatos = contexto;

        }

    }
}
