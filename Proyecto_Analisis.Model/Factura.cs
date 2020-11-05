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

        [Display(Name = "Fecha de Emisión")]
        public DateTime? FechaEmision { get; set; }

        [Display(Name = "Nombre Comercial")]
        public string ?NombreComercial { get; set; }

        [Display(Name = "MontoTotal")]
        public int ? MontoTotal { get; set; }

    }
}
