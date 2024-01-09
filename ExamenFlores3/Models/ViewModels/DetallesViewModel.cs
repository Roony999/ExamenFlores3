namespace ExamenFlores3.Models.ViewModels
{
    public class DetallesViewModel
    {
        public uint Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Origen { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public IEnumerable<FlorModel> Flores { get; set; } = null!;


    }

    public class FlorModel
    {
        public string Nombre { get; set; } = null!;
    }
}
