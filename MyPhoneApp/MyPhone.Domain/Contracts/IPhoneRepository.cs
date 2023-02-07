using MyPhone.Domain.Entities;
using MyPhone.DTO.DTOs;

namespace MyPhone.Domain.Contracts
{
    public interface IPhoneRepository : IRepository<Phone>
    {
        IEnumerable<PhoneDTO> GetPhonesWithOwner();
    }
}
