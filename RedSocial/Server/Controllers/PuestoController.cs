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
            var pepe = await context.puestos.ToListAsync();
            if (pepe == null || pepe.Count == 0)
            {
                return BadRequest("No existen Puestos");
            }
            return pepe;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Puesto>> Get(int id)
        {
            var existe = await context.puestos.AnyAsync(x => x.ID == id);
            if (!existe)
            {
                return NotFound($"La Especialidad {id} no existe");
            }
            return await context.puestos.FirstOrDefaultAsync(x => x.ID == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(PuestoODT entidad)
        {
            try
            {
                var existe = await context.Trabajadores.AnyAsync(x => x.ID == entidad.CodPuesto);
                if (!existe)
                {
                    return NotFound($"El puesto de id={entidad.CodPuesto} no existe");
                }

                Puesto pepe = new Puesto();

                pepe.IDTrabajador = entidad.CodPuesto;
                pepe.CodPuesto = entidad.CodPuesto;

                await context.AddAsync(pepe);
                await context.SaveChangesAsync();
                return pepe.ID;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Puesto entidad, int id)
        {
            if (id != entidad.ID)
            {
                return BadRequest("El id del Puesto no corresponde.");
            }

            var existe = await context.puestos.AnyAsync(x => x.ID == id);
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
            var existe = await context.puestos.AnyAsync(x => x.ID == id);
            if (!existe)
            {
                return NotFound($"El puesto de id={id} no existe");
            }
            Puesto pepe = new Puesto();
            pepe.ID = id;

            context.Remove(pepe);

            await context.SaveChangesAsync();

            return Ok();
        }

    }
}
