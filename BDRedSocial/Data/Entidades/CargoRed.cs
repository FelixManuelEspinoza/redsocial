using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDRedSocial.Data.Entidades
{
    [Index(nameof(CodCarRed), Name = "Codigo_Cargo_Red", IsUnique = true)]
    public class CargoRed
    {
        public int ID {get;set;}


        [Required(ErrorMessage = "El Codigo de Cargo de Red es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el codigo de Cargo de Red")]
        public int CodCarRed { get;set;}

        [Required(ErrorMessage = "La Descripción de la Cargo de Red es Obligatorio")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en la Descripción de la Especialidad")]
        public string DescCargoRed { get;set;}

        public List<Trabajador> Trabajadores { get; set; } = new List<Trabajador>();
    }
}
