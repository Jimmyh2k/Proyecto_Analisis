using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Analisis.Model
{
    public class Factura
    {

        public int CodigoFactura { get; set; }

        public DateTime FechaEmision { get; set; }

        public string NombreComercial { get; set; }

        public int Cod_MetodoPago { get; set; }

        public int MontoTotal { get; set; }

    }
}
