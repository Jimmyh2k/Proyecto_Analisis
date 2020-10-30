using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Analisis.Model
{
    public class Factura
    {

        public string CodigoFactura { get; set; }

        public DateTime FechaEmision { get; set; }

        public string NombreComercial { get; set; }

        public string Cod_MetodoPago { get; set; }

        public int MontoTotal { get; set; }

    }
}
