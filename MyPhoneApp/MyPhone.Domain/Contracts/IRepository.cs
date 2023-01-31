namespace MyPhone.Domain.Contracts
{
    public interface IRepository<T>
    {
        Task Create(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetByID(int ID);
        void Update(T entity);
    }
}
