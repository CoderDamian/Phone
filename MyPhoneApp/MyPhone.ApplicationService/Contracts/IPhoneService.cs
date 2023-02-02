using MyPhone.DTO.DTOs;

namespace MyPhone.ApplicationService.Contracts
{
    public interface IPhoneService
    {
        Task Add(PhoneCreateDTO phoneCreateDTO);
        Task Delete(int ID);
        Task<IEnumerable<PhoneDTO>> GetAll();
        Task<PhoneDTO> GetByID(int ID);
        Task Update(int ID, PhoneUpdateDTO entity);
        Task SaveAsync();

    }
}
