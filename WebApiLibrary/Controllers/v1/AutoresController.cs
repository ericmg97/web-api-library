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

        [HttpGet("{id:int}", Name ="getAuthor")]
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

            return new CreatedAtRouteResult("getAuthor", new { id = author.Id }, authorDto);
        }
    }
}
