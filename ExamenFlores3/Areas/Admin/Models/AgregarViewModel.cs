namespace ExamenFlores3.Areas.Admin.Models
{
    public class AgregarViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Origen { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public IFormFile? Imagen { get; set; }
    }
}
