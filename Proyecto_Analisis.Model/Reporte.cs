using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Analisis.Model
{
    public class Reporte
    {
        [Key]
        public int Cod_Reporte { get; set; }
        public int CodigoFactura { get; set; }
        public int ID_Producto { get; set; }
        public int CantidadProductosVendidos { get; set; }
        public int RecaudacionTotal { get; set; }
        


    }
}
