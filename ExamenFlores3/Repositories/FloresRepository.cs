using ExamenFlores3.Models.Entities;

namespace ExamenFlores3.Repositories
{
    public class FloresRepository : Repository<Datos>
    {
        public FloresRepository(FloresContext context):base(context)
        { 
        }

        public Datos? GetByNombre(string nombre)
        {
            return Context.Datos.Where(x => x.NombreFlor == nombre).FirstOrDefault();
        }
    }
}
