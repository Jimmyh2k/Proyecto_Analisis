using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Analisis.Model
{
    public class Producto
    {
        [Key]
        public int ID_Producto { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public int PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

    }
}
