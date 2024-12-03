using System;
using System.Collections.Generic;

namespace Task1.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string TeacherName { get; set; } = null!;

    public int Age { get; set; }

    public string Image { get; set; }

    public string Gender { get; set; } = null!;

    public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();
}
