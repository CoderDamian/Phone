using Microsoft.EntityFrameworkCore;
using MyPhone.Domain.Contracts;
using MyPhone.Persistence.Data;

namespace MyPhone.Persistence.Seedwork
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        //private readonly MyDBContext _myDBContext;
        public MyDBContext _myDBContext { get;private set; }

        public RepositoryBase(MyDBContext myDBContext)
        {
            this._myDBContext = myDBContext;
        }

        public async Task Create(T entity)
        {
            await _myDBContext.Set<T>().AddAsync(entity).ConfigureAwait(false);
        }

        public void Delete(T entity)
        {
            _myDBContext.Set<T>().Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _myDBContext.Set<T>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<T?> GetByID(int ID)
        {
            T? entity = await _myDBContext.Set<T>().FindAsync(ID).ConfigureAwait(false);

            return entity;
        }

        public void Update(T entity)
        {
            _myDBContext.Set<T>().Update(entity);
        }
    }
}
