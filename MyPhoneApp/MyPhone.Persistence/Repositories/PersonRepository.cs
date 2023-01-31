using MyPhone.Domain.Contracts;
using MyPhone.Domain.Entities;
using MyPhone.Persistence.Data;
using MyPhone.Persistence.Seedwork;

namespace MyPhone.Persistence.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(MyDBContext myDBContext)
            : base(myDBContext)
        {

        }
    }
}
