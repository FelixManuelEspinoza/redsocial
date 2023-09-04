using BDRedSocial.Data;
using BDRedSocial.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedSocial.Shared.ODT;

namespace RedSocial.Server.Controllers
{
    [ApiController]
    [Route("api/CargoRed")]
    public class CargoRedController : ControllerBase
    {
        private readonly DBcontext context;

        public CargoRedController(DBcontext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CargoRed>>> Get()
        {
            var pepe = await context.CargosRed.ToListAsync();
            return pepe;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CargoRed?>> Get(int id)
        {
            var existe = await context.CargosRed.AnyAsync(x => x.ID == id);
            if (!existe)
            {
                return NotFound($"El Cargo de Red {id} no existe");
            }
            return await context.CargosRed.FirstOrDefaultAsync(prof => prof.ID == id);
        }

        [HttpGet("{cod}")]
        public async Task<ActionResult<CargoRed>> Get(string cod)
        {
            var existe = await context.CargosRed.AnyAsync(x => x.CodCarRed == cod);
            if (!existe)
            {
                return NotFound($"La profesión de id={cod} no existe");
            }
            return await context.CargosRed.FirstOrDefaultAsync(prof => prof.CodCarRed == cod);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CargoRedODT profesion)
        {
            CargoRed pepe = new CargoRed();

            pepe.CodCarRed = profesion.CodCarRed;




            await context.AddAsync(pepe);
            await context.SaveChangesAsync();
            return pepe.ID;
        }


        
    }
}
