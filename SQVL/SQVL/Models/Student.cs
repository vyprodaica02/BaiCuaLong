using System;
using System.Collections.Generic;

namespace SQVL.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
