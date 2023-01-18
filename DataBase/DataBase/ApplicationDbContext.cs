using DataBase.Models;
using Hospital.Application.Interfaces;
using Hospital.Domain;
using Hospital.Persistence;
using Hospital.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DataBase;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<DoctorModel> Doctors { get; set; }
    public DbSet<ScheduleModel> Schedules { get; set; }
    public DbSet<AppointmentModel> Appointments { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<UserModel>().HasKey(model => model.Id);
        modelBuilder.Entity<UserModel>().HasIndex(model => model.Name);
    }
}