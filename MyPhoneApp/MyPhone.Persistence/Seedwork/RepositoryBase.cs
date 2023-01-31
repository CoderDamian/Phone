using Microsoft.EntityFrameworkCore;
using MyPhone.Domain.Contracts;
using MyPhone.Persistence.Data;

namespace MyPhone.Persistence.Seedwork
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly MyDBContext _myDBContext;

        public RepositoryBase(MyDBContext myDBContext)
        {
            this._myDBContext = myDBContext;
        }

        public async Task Create(T entity)
        {
            await _myDBContext.Set<T>().AddAsync(entity).ConfigureAwait(false);
        }

        public async Task Delete(int ID)
        {
            T? entity = await GetByID(ID);

            _myDBContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _myDBContext.Set<T>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> GetByID(int ID)
        {
            T? entity = await _myDBContext.Set<T>().FindAsync(ID).ConfigureAwait(false);

            if (entity == null)
                throw new NullReferenceException(nameof(entity));

            return entity;
        }

        public void Update(T entity)
        {
            _myDBContext.Set<T>().Update(entity);
        }
    }
}
