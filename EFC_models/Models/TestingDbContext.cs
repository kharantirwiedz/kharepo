using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFC_models.Models;

public partial class TestingDbContext : DbContext
{
    public TestingDbContext()
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Profession> Professions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\localdatabase;Database=TestingDB;Trusted_Connection=True;");
}
