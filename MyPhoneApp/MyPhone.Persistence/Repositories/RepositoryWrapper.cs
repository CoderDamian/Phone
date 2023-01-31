using MyPhone.Domain.Contracts;
using MyPhone.Persistence.Contracts;
using MyPhone.Persistence.Data;

namespace MyPhone.Persistence.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly MyDBContext _myDBContext;

        public RepositoryWrapper(MyDBContext myDBContext)
        {
            this._myDBContext = myDBContext;
        }

        private IPersonRepository _personRepository;

        public IPersonRepository PersonRepository
        {
            get
            {
                if (_personRepository == null)
                    _personRepository = new PersonRepository(_myDBContext);

                return _personRepository;
            }
        }

        private IPhoneRepository _phoneRepository;

        public IPhoneRepository PhoneRepository
        {
            get
            {
                if (_phoneRepository == null)
                    _phoneRepository = new PhoneRepository(_myDBContext);

                return _phoneRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _myDBContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
