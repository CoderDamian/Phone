using AutoMapper;
using MyPhone.ApplicationService.Contracts;
using MyPhone.DTO.DTOs;
using MyPhone.Domain.Entities;
using MyPhone.Persistence.Contracts;

namespace MyPhone.ApplicationService.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public PhoneService(IRepositoryWrapper repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task Add(PhoneCreateDTO phoneCreateDTO)
        {
            Phone phone = _mapper.Map<Phone>(phoneCreateDTO);

            await _repository.PhoneRepository.Create(phone).ConfigureAwait(false);
        }
        
        public async Task Delete(int ID)
        {
            Phone? phone = await _repository.PhoneRepository.GetByID(ID).ConfigureAwait(false);

            if (phone == null)
                throw new NullReferenceException(nameof(phone));

            _repository.PhoneRepository.Delete(phone);
        }

        public async Task<IEnumerable<PhoneDTO>> GetAll()
        {
            IEnumerable<Phone> phones = await _repository.PhoneRepository.GetAll().ConfigureAwait(false);

            IEnumerable<PhoneDTO> phonesDTO = _mapper.Map<IEnumerable<PhoneDTO>>(phones);

            return phonesDTO;
        }

        public IEnumerable<PhoneDTO> GetPhonesWithOwner()
        {
            return _repository.PhoneRepository.GetPhonesWithOwner();
        }

        public async Task<PhoneDTO> GetByID(int ID)
        {
            Phone? phone = await _repository.PhoneRepository.GetByID(ID).ConfigureAwait(false);

            if (phone == null)
                throw new NullReferenceException(nameof(phone));

            PhoneDTO phoneDTO;

            phoneDTO = _mapper.Map<PhoneDTO>(phone);

            return phoneDTO;
        }

        public async Task SaveAsync()
        {
            await _repository.SaveAsync().ConfigureAwait(false);
        }

        public async Task Update(int ID, PhoneUpdateDTO entity)
        {
            Phone? phone = await _repository.PhoneRepository.GetByID(ID).ConfigureAwait(false);

            if (phone == null)
                throw new NullReferenceException(nameof(phone));

            _mapper.Map(entity, phone);

            _repository.PhoneRepository.Update(phone);
        }
    }
}
