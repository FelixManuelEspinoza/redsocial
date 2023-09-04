using BDRedSocial.Data;
using BDRedSocial.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace RedSocial.Server.Controllers
{
    [ApiController]
    [Route("api/Trabajador")]


    public class TrabajadorController : ControllerBase
    {
        private readonly DBcontext context;

        public TrabajadorController(DBcontext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Trabajador>>> Get()
        {
            return await context.Trabajadores.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Trabajador>> Get(int id)
        {
            var existe = await context.Trabajadores.FirstOrDefaultAsync(x => x.Id == id);
            if (existe is null)
            {
                return NotFound($"El Trabajador {id} no existe");
            }
            return (existe);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Trabajador Empleado)
        {
            context.Add(Empleado);
            await context.SaveChangesAsync();
            return Empleado.Id;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Trabajador entidad, int id)
        {
            if (id != entidad.Id)
            {
                return BadRequest("El id del Trabajador no corresponde.");
            }

            var existe = await context.Trabajadores.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"el Trabajador de id={id} no existe");
            }

            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Trabajadores.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El Trabajador de id={id} no existe");
            }
            Trabajador pepe = new Trabajador();
            pepe.Id = id;

            context.Remove(pepe);

            await context.SaveChangesAsync();

            return Ok();
        }
    }
}