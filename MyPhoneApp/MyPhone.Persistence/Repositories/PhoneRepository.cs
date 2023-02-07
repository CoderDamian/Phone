using MyPhone.Domain.Contracts;
using MyPhone.Domain.Entities;
using MyPhone.DTO.DTOs;
using MyPhone.Persistence.Data;
using MyPhone.Persistence.Seedwork;

namespace MyPhone.Persistence.Repositories
{
    public class PhoneRepository : RepositoryBase<Phone>, IPhoneRepository
    {
        public PhoneRepository(MyDBContext myDBContext)
            : base(myDBContext)
        {
        }

        public IEnumerable<PhoneDTO> GetPhonesWithOwner()
        {
            IEnumerable<PhoneDTO> phoneDTOs = from phone in base._myDBContext.Phones
                                              join person in base._myDBContext.People
                                              on phone.PersonFK equals person.ID
                                              select new PhoneDTO()
                                              {
                                                  ID = phone.ID,
                                                  Owner = person.Name,
                                                  Numero = phone.Numero,
                                                  Tipo = phone.Tipo
                                              };
            return phoneDTOs.ToList();
        }
    }
}
