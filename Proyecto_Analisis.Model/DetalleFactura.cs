using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Analisis.Model
{
          public class DetalleFactura
        {

        [Key]
        public int ID_DetalleFactura { get; set; }

        public int CodigoFactura { get; set; }

            public int ID_Producto { get; set; }

            public int ID_Persona { get; set; }
           


        
    }
}
