namespace MyPhone.DTO.DTOs
{
    public class PersonCreateDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}
