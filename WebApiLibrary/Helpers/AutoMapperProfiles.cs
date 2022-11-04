using AutoMapper;
using WebApiLibrary.DTOs;
using WebApiLibrary.Models;

namespace WebApiLibrary.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Autor, AutorDTO>()
                .ForMember(
                    autorDTO => autorDTO.Libros,
                    opciones => opciones.MapFrom(MapLibroAutorDTO))
                .ForMember(
                    autorDTO => autorDTO.CantidadSuscriptores,
                    opciones => opciones.MapFrom(MapCantidadSuscriptores));

            CreateMap<AutorCreacionDTO, Autor>();
            CreateMap<Libro, LibroCreacionDTO>().ReverseMap();
            CreateMap<Libro, LibroDTO>()
                .ForMember(
                    libroDTO => libroDTO.NombreAutor,
                    opciones => opciones
                        .MapFrom(libro => libro.Autor.Nombre));
            CreateMap<Usuario, UsuarioCreacionDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(
                    usuariodto => usuariodto.CantidadSuscripciones,
                    opciones => opciones
                        .MapFrom(MapCantidadSuscripciones));
            CreateMap<UsuarioEdicionDTO, Usuario>();
            CreateMap<Review, ReviewCreacionDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>()
                .ForMember(
                    reviewdto => reviewdto.EmailUsuario,
                    opciones => opciones
                        .MapFrom(x => x.Usuario.Email));
        }

        private List<LibroAutorDTO> MapLibroAutorDTO(Autor autor, AutorDTO autordto)
        {
            var resultado = new List<LibroAutorDTO>();

            if (autor.Libros == null) { return resultado; }

            foreach (var libro in autor.Libros)
            {
                resultado.Add(new LibroAutorDTO
                {
                    ISBN = libro.ISBN,
                    Titulo = libro.Titulo,
                    FechaPublicacion = libro.FechaDePublicacion
                });
            }

            return resultado;
        }

        private int MapCantidadSuscriptores(Autor autor, AutorDTO autordto)
        {
            if (autor.UsuariosSuscritos == null) { return 0; }

            return autor.UsuariosSuscritos.Count;
        }

        private int MapCantidadSuscripciones(Usuario autor, UsuarioDTO autordto)
        {
            if (autor.Suscripciones == null) { return 0; }

            return autor.Suscripciones.Count;
        }
    }
}
