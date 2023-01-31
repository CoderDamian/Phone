namespace MyPhone.ApplicationService.DTOs
{
    public class PersonUpdateDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}
