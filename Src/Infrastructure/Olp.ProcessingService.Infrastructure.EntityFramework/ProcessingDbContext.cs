using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Olp.ProcessingService.Core.Domain.Entities;

namespace Olp.ProcessingService.Infrastructure.EntityFramework;

public class ProcessingDbContext : DbContext
{
    public DbSet<Operation> Operations { get; set; }

    public DbSet<OperationStep> OperationSteps { get; set; }

    public ProcessingDbContext(DbContextOptions<ProcessingDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Operation>()
            .HasMany(operation => operation.OperationSteps)
            .WithOne(operationStep => operationStep.Operation)
            .IsRequired();

        modelBuilder.Entity<Operation>().Property(c => c.Name).HasMaxLength(128);
        modelBuilder.Entity<Operation>().Property(c => c.ErrorMessage).HasMaxLength(512);

        modelBuilder.Entity<OperationStep>().Property(c => c.Name).HasMaxLength(128);
        modelBuilder.Entity<OperationStep>().Property(c => c.ErrorMessage).HasMaxLength(512);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
}
