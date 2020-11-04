    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Analisis.Model
{
    public class Factura
    {
        [Key]
        public int CodigoFactura { get; set; }

        public DateTime? FechaEmision { get; set; }

        public string ?NombreComercial { get; set; }

        public int ? MontoTotal { get; set; }

    }
}
