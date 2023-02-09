using AutoMapper;
using MyPhone.ApplicationService.Contracts;
using MyPhone.Domain.Entities;
using MyPhone.DTO.DTOs;
using MyPhone.Persistence.Contracts;

namespace MyPhone.ApplicationService.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public PersonService(IRepositoryWrapper repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task Add(PersonCreateDTO personCreateDTO)
        {
            if (personCreateDTO == null)
                throw new NullReferenceException(nameof(personCreateDTO));

            Person person = _mapper.Map<Person>(personCreateDTO);
            person.Phones = _mapper.Map<ICollection<Phone>>(personCreateDTO.PhonesDTO);

            await _repository.PersonRepository.Create(person).ConfigureAwait(false);
        }

        public async Task Delete(int ID)
        {
            Person? personToDelete = await _repository.PersonRepository.GetByID(ID).ConfigureAwait(false);

            if (personToDelete == null)
                throw new NullReferenceException(nameof(personToDelete));

            _repository.PersonRepository.Delete(personToDelete);
        }

        public async Task<IEnumerable<PersonDTO>> GetAll()
        {
            IEnumerable<Person> people =  await _repository.PersonRepository.GetAll().ConfigureAwait(false);

            IEnumerable<PersonDTO> peopleDTO;

            peopleDTO = _mapper.Map<IEnumerable<PersonDTO>>(people);

            return peopleDTO;
        }

        public async Task<PersonDTO> GetByID(int ID)
        {
            Person? person = await _repository.PersonRepository.GetByID(ID).ConfigureAwait(false);

            if (person == null)
                throw new NullReferenceException(nameof(person));

            PersonDTO personDTO;

            personDTO = _mapper.Map<PersonDTO>(person);

            return personDTO;
        }

        public async Task SaveAsync()
        {
            await _repository.SaveAsync().ConfigureAwait(false);
        }

        public async Task Update(int ID, PersonUpdateDTO entity)
        {
            Person? person = await _repository.PersonRepository.GetByID(ID).ConfigureAwait(false);

            if (person == null)
                throw new NullReferenceException(nameof(person));

            _mapper.Map(entity, person);

            _repository.PersonRepository.Update(person);
        }
    }
}
