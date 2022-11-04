namespace WebApiLibrary.DTOs
{
    public class FiltroLibrosDTO: PaginacionDTO
    {
        public int? authorId { get; set; } = null;
        public string editorialName { get; set; } = null;
        public DateTime? before { get; set; } = null;
        public DateTime? after { get; set; } = null;
        public bool? order { get; set; } = null;


    }
}
