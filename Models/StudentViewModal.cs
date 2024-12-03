namespace Task1.Models
{
    public class StudentViewModal
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; } = null!;

        public int Age { get; set; }

        public IFormFile Photo { get; set; }

        public string? Class { get; set; }

        public int RollNumber { get; set; }
    }
}
