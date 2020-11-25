using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Analisis.Model
{
    public class CierresFacturas
    {
        public List<Factura> facturas { get; set; }
        [Display(Name = "Fecha de Emisión")]
        public int montoTotal { get; set; }

    }
}
