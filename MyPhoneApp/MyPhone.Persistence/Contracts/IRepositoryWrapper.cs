using MyPhone.Domain.Contracts;

namespace MyPhone.Persistence.Contracts
{
    public interface IRepositoryWrapper
    {
        IPersonRepository PersonRepository { get; }
        IPhoneRepository PhoneRepository { get; }

        Task SaveAsync();
    }
}