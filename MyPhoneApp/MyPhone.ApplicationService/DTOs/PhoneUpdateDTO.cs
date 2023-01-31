namespace MyPhone.ApplicationService.DTOs
{
    public class PhoneUpdateDTO
    {
        public int ID { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
    }
}
