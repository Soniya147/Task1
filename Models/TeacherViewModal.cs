namespace Task1.Models
{
    public class TeacherViewModal
    {
        public int TeacherId { get; set; }

        public string TeacherName { get; set; } = null!;

        public int Age { get; set; }

        public IFormFile Photo { get; set; }

        public string Gender { get; set; } = null!;

        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();
    }
}
