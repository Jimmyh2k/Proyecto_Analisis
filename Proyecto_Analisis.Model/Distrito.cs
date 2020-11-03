using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Analisis.Model
{
    public class Distrito
    {
        public string CodigoPais { get; set; }
        public int ID_Provincia { get; set; }
        public int ID_Canton { get; set; }
        [Key]
        public int ID_Distrito { get; set; }
        public string Nombre { get; set; }


    }
}
