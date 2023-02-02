using MyPhone.DTO.DTOs;

namespace MyPhone.ApplicationService.Contracts
{
    public interface IPersonService
    {
        Task Add(PersonCreateDTO personCreateDTO);
        Task Delete(int ID);
        Task<IEnumerable<PersonDTO>> GetAll();
        Task<PersonDTO> GetByID(int ID);
        Task Update(int ID, PersonUpdateDTO entity);
        Task SaveAsync();
    }
}
