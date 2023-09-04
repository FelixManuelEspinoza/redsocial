using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace BDRedSocial.Data.Entidades
{
 //   [Index(nameof(CodPuesto), Name = "Codigo_Puesto", IsUnique = true)]
    public class Puesto
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "El Codigo de Cargo de Red es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el codigo de Cargo de Red")]
        public int CodPuesto { get; set; }

        [Required(ErrorMessage = "El Correo es requerido")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "el Trabajador es obligatorio")]
        public int IdTrabajador { get; set; }
        public List<Trabajador> Trabajadores { get; set; } = new List<Trabajador>();



    }
}
