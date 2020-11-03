using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Analisis.Model
{
    public class Pais
    {
        [Key]
        public int CodigoPais { get; set; }

        public string Nombre { get; set; }

    }
}
