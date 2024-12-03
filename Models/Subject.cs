using System;
using System.Collections.Generic;

namespace Task1.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public string Class { get; set; } = null!;

    public string? Language { get; set; }

    public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();
}
