using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPIMVC8CRUD.Models;

public partial class Mvc8crudDbContext : DbContext
{
    public Mvc8crudDbContext()
    {
    }

    public Mvc8crudDbContext(DbContextOptions<Mvc8crudDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
     //   => optionsBuilder.UseSqlServer("Server=DESKTOP-6JBC82E;Database=MVC8CrudDb;Integrated Security=True;TrustServerCertificate=True");

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
        //OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
