using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Analisis.Model
{
    public class CorreoElectronico
    {
        [Key]
        public int ID { get; set; }
        public String correoElectronico { get; set; }

    }
}
