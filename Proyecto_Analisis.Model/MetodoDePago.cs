using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Analisis.Model
{
    public class MetodoDePago
    {
        [Key]
        public int Codigo { get; set; }

        public string metodoDePago { get; set; }

    }
}
