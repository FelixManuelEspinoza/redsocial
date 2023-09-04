using BDRedSocial.Data.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDRedSocial.Data
{
    public class DBcontext :DbContext 
    {
        public DbSet<CargoRed> CargosRed { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<Puesto> puestos { get; set; }

        
        public DBcontext(DbContextOptions options): base(options) 
        {
          
        }
    } 
}
