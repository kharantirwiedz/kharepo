using System;
using System.Collections.Generic;

namespace EFC_models.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? LastName { get; set; }

    public int? ProfessionId { get; set; }

    public int? DepartmentId { get; set; }

    public int? ManagerId { get; set; }

    public int? Salary { get; set; }
}
