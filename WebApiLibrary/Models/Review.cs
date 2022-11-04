namespace WebApiLibrary.Models
{
    public enum EnumCalificacion
    {
        MuyMala = 1,
        Mala,
        Regular,
        Buena,
        MuyBuena
    }

    public class Review
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }
        public EnumCalificacion Calificacion { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        public Libro Libro { get; set; }
        public Usuario Usuario { get; set; }
    }
}
