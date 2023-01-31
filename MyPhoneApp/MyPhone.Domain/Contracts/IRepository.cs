namespace MyPhone.Domain.Contracts
{
    public interface IRepository<T>
    {
        Task Create(T entity);
        Task Delete(int ID);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(int ID);
        void Update(T entity);
    }
}
