using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial.Shared.ODT
{
    public class PuestoODT
    {
        [Required(ErrorMessage = "El Codigo de Cargo de Red es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el codigo de Cargo de Red")]
        public int CodPuesto { get; set; }

        [Required(ErrorMessage = "El Correo es requerido")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el correo")]
        public string Correo { get; set; }

    }
}
