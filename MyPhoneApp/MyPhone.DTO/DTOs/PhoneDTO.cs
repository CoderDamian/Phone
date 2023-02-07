namespace MyPhone.DTO.DTOs
{
    public class PhoneDTO
    {
        public int ID { get; set; }
        public string Owner { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
    }
}