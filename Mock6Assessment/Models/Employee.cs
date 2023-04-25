using System;
using System.Collections.Generic;

namespace Mock6Assessment.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public int Age { get; set; }

    public decimal Salary { get; set; }
}
