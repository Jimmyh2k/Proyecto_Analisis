using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Analisis.Model
{
    public class FacturaDetallada
    {

        public DateTime? FechaEmision { get; set; }

        public string? NombreComercial { get; set; }

        public List<Producto>? ListaDeProductos { get; set; }

        public Persona Cliente { get; set; }

        public int? MontoTotal { get; set; }
    }
}
