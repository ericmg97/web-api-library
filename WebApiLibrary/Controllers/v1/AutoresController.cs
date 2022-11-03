using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiLibrary.DTOs;
using WebApiLibrary.Models;
using WebApiLibrary.Services;

namespace WebApiLibrary.Controllers.v1
{
    [ApiController]
    [Route("api/v1.0/library/authors")]
    [Produces("application/json")]
    public class AutoresController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly EmailSender emailSender;

        public AutoresController(ApplicationDbContext context, IMapper mapper, IConfiguration configuration, EmailSender emailSender)
        {
            this.context = context;
            this.mapper = mapper;
            this.configuration = configuration;
            this.emailSender = emailSender;
        }

        [HttpGet("{id:int}", Name ="getAuthor")]
        public async Task<ActionResult<AutorDTO>> Get(int id)
        {
            var entity = await context.Autores
                .Include(autoresdb => autoresdb.Libros)
                .Include(autoresdb => autoresdb.UsuariosSuscritos)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<AutorDTO>(entity);
            return dto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AutorCreacionDTO authorDto)
        {
            var author = mapper.Map<Autor>(authorDto);
            context.Add(author);
            await context.SaveChangesAsync();

            return new CreatedAtRouteResult("getAuthor", new { id = author.Id }, authorDto);
        }

        [HttpPost("{id:int}/books")]
        public async Task<ActionResult> Post(int id, LibroCreacionDTO libroDto)
        {
            var book = mapper.Map<Libro>(libroDto);
            book.AutorId = id;
            context.Add(book);
            await context.SaveChangesAsync();

            var author = await context.Autores
                .Include(authordb => authordb.UsuariosSuscritos)
                .FirstOrDefaultAsync(authorbd => authorbd.Id == id);

            foreach (var user in author.UsuariosSuscritos)
            {
                await emailSender.SendEmailAsync(
                    configuration["EmailSettings:Sender"],
                    user.Email,
                    configuration["EmailSettings:Subject"],
                    $"{author.Nombre}, uno de tus autores favoritos ha publicado el libro {book.Titulo}. " +
                    $"Puedes descargarlo en la URL: {book.URLDescarga}"
                );

            }

            return new CreatedAtRouteResult("getBook", new { id = book.Id }, libroDto);
        }
    }
}
