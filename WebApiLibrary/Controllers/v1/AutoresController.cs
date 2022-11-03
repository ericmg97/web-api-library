using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiLibrary.DTOs;
using WebApiLibrary.Models;

namespace WebApiLibrary.Controllers.v1
{
    [ApiController]
    [Route("api/v1.0/library/authors")]
    [Produces("application/json")]
    public class AutoresController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AutoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorDTO>>> Get()
        {
            var entitys = await context.Autores.ToListAsync();
            var dtos = mapper.Map<List<AutorDTO>>(entitys);
            return dtos;

        }

        [HttpGet("{id:int}", Name ="getAuthors")]
        public async Task<ActionResult<AutorDTO>> Get(int id)
        {
            var entity = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<AutorDTO>(entity);
            return dto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AutorDTO authorDto)
        {
            var author = mapper.Map<Autor>(authorDto);
            context.Add(author);
            await context.SaveChangesAsync();

            return new CreatedAtRouteResult("getAuthors", new { id = author.Id }, authorDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] AutorDTO authorDto)
        {
            var author = mapper.Map<Autor>(authorDto);
            author.Id = id;
            context.Entry(author).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await context.Autores.AnyAsync(x => x.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            context.Remove(new Autor { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
