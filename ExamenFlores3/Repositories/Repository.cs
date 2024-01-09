using ExamenFlores3.Models.Entities;

namespace ExamenFlores3.Repositories
{

    public class Repository<T> where T : class
    {

        public Repository(FloresContext context)
        {
            Context = context;
        }

        public FloresContext Context { get; }

        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public virtual T? Get(object id)
        {
            return Context.Find<T>(id);
        }

        public virtual void Insert(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            Context.Update(entity);
            Context.SaveChanges();

        }

        public virtual void Delete(T entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

    }
}
