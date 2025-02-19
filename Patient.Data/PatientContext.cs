﻿using Microsoft.EntityFrameworkCore;

namespace Patient.Data
{
    public class PatientContext : DbContext
    {
        public PatientContext (DbContextOptions<PatientContext> options) : base(options) 
        {
        }

        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<SpecialityToSymptom> SpecialityToSymptoms { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().Property(m => m.FirstName).HasMaxLength(50);
            builder.Entity<User>().Property(m => m.LastName).HasMaxLength(50);
            builder.Entity<User>().Property(m => m.Latitude).HasMaxLength(200);
            builder.Entity<User>().Property(m => m.Longitude).HasMaxLength(200);

            builder.Entity<Staff>().Property(m => m.FirstName).HasMaxLength(50);
            builder.Entity<Staff>().Property(m => m.LastName).HasMaxLength(50);
            builder.Entity<Staff>().Property(m => m.Latitude).HasMaxLength(200);
            builder.Entity<Staff>().Property(m => m.Longitude).HasMaxLength(200);
        }
    }
}