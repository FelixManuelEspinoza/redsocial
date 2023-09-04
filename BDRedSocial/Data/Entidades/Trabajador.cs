using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDRedSocial.Data.Entidades
{
    //[Index(nameof(Correo), Name ="Correo_Trabajador", IsUnique = true)]
    public class Trabajador
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el nombre")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La Edad es requerido")]
        [MaxLength(2, ErrorMessage = "Solo se aceptan hasta 2 caracteres en la Edad")]
        public string Edad { get; set; }

        [Required(ErrorMessage = "El Puesto es requerido")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el puesto")]
        public string Puesto { get; set; }

        [Required(ErrorMessage = "El Correo es requerido")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el correo")]
        public string Correo { get; set; }

        public int IdPuesto { get; set; }
        public Puesto Puestos { get; set; }

    }
}
