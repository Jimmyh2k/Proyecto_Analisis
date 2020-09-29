using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Analisis.Model
{
    class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public EmailAddressAttribute Correo { get; set; }

        public Roles rol { get; set; }
    }
}
