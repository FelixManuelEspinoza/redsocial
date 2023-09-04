using BDRedSocial.Data;
using BDRedSocial.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedSocial.Shared.ODT;

namespace RedSocial.Server.Controllers
{
    [ApiController]
    [Route("api/Puesto")]
    public class PuestoController : ControllerBase
    {
        private readonly DBcontext context;

        public PuestoController(DBcontext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Puesto>>> Get()
        {
            var pepe = await context.Puestos.ToListAsync();
            if (pepe == null || pepe.Count == 0)
            {
                return BadRequest("No existen Puestos");
            }
            return pepe;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Puesto>> Get(int id)
        {
            var existe = await context.Puestos.FirstOrDefaultAsync(x => x.Id == id);
            if (existe is null)
            {
                return NotFound($"El cargo de {id} no existe");
            }
            return (existe);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(PuestoODT entidad)
        {
            try
            {
                var existe = await context.Trabajadores.AnyAsync(x => x.Id == entidad.CodPuesto);
                if (!existe)
                {
                    return NotFound($"El puesto de id={entidad.CodPuesto} no existe");
                }

                Puesto pepe = new Puesto();

                pepe.IdTrabajador = entidad.CodPuesto;
                pepe.CodPuesto = entidad.CodPuesto;

                await context.AddAsync(pepe);
                await context.SaveChangesAsync();
                return pepe.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Puesto entidad, int id)
        {
            if (id != entidad.Id)
            {
                return BadRequest("El id del Puesto no corresponde.");
            }

            var existe = await context.Puestos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El puesto de id={id} no existe");
            }

            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Puestos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El puesto de id={id} no existe");
            }
            Puesto pepe = new Puesto();
            pepe.Id = id;

            context.Remove(pepe);

            await context.SaveChangesAsync();

            return Ok();
        }

    }
}
