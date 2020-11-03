using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Analisis.Model
{
    public class Provincia
    {
        public int CodigoPais { get; set; }
        [Key]
        public int ID_Provincia { get; set; }
        public string Nombre { get; set; }
    }
}
