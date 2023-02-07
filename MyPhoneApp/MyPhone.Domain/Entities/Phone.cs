using MyPhone.Domain.Seedwork;

namespace MyPhone.Domain.Entities
{
    public class Phone : EntityBase
    {
        public string Tipo { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public int PersonFK { get; set; }
        public Person Person { get; set; }
    }
}
