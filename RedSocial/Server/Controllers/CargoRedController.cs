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
            var cargo = await context.CargosRed.ToListAsync();
            return cargo;
        }

        /*[HttpGet("{id:int}")]
        public async Task<ActionResult<CargoRed?>> Get(int id)
        {
            var existe = await context.CargosRed.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El Cargo de Red {id} no existe");
            }
            return await context.CargosRed.FirstOrDefaultAsync(prof => prof.Id == id);
        }*/

        [HttpGet("{int:cod}")]
        public async Task<ActionResult<CargoRed>> Get(int cod)
        {
            var existe = await context.CargosRed.FirstOrDefaultAsync(x => x.CodCarRed == cod);
            if (existe is null)
            {
                return NotFound($"El codigo = {cod} e cargo de red no existe");
            }
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CargoRedODT cargoODT)
        {
            CargoRed cargo = new CargoRed();

            cargo.CodCarRed = cargoODT.CodCarRed;
            cargo.DescCargoRed = cargoODT.DescCargoRed;



            await context.AddAsync(cargo);
            await context.SaveChangesAsync();
            return Ok();
        }



        
    }
}
