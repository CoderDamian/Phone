using MyPhone.Domain.Contracts;
using MyPhone.Domain.Entities;
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
    }
}
