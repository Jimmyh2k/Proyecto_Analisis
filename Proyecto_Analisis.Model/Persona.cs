using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Analisis.Model
{
    public class Persona
    {
        public int ID { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string CorreoElectronico { get; set; }
        public int CodigoPais { get; set; }
        public int ID_Provincia { get; set; }
        public int ID_Canton { get; set; }
        public int ID_Distrito { get; set; }

    }
}
