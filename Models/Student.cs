using System;
using System.Collections.Generic;

namespace Task1.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public int Age { get; set; }

    public string Image { get; set; }

    public string? Class { get; set; }

    public int RollNumber { get; set; }
}
