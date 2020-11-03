using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Analisis.Model
{
    public class Inventario
    {
        [Key]
        public int ID_Inventario { get; set; }

        public int ID_Producto { get; set; }

        public int Cantidad { get; set; }
    }
}
