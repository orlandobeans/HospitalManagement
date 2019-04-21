using HMS.Core.Domain;

namespace HMS.Infrastructure
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HospitalContext : DbContext
    {
        public HospitalContext()
            : base("name=Hospital")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalContext, Configuration>());
        }
        

        public virtual DbSet<Affiliated_With> Affiliated_With { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Block> Blocks { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<Nurse> Nurses { get; set; }
        public virtual DbSet<On_Call> On_Call { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Physician> Physicians { get; set; }
        public virtual DbSet<Prescribe> Prescribes { get; set; }
        public virtual DbSet<Procedure> Procedures { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Stay> Stays { get; set; }
        public virtual DbSet<Trained_In> Trained_In { get; set; }
        public virtual DbSet<Undergo> Undergoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasMany(e => e.Prescribes)
                .WithOptional(e => e.Appointment1)
                .HasForeignKey(e => e.Appointment);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Affiliated_With)
                .WithRequired(e => e.Department1)
                .HasForeignKey(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medication>()
                .HasMany(e => e.Prescribes)
                .WithRequired(e => e.Medication1)
                .HasForeignKey(e => e.Medication)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nurse>()
                .HasMany(e => e.Appointments)
                .WithOptional(e => e.Nurse)
                .HasForeignKey(e => e.PrepNurse);

            modelBuilder.Entity<Nurse>()
                .HasMany(e => e.Undergoes)
                .WithOptional(e => e.Nurse)
                .HasForeignKey(e => e.AssistingNurse);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Patient1)
                .HasForeignKey(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Prescribes)
                .WithRequired(e => e.Patient1)
                .HasForeignKey(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Stays)
                .WithRequired(e => e.Patient1)
                .HasForeignKey(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Undergoes)
                .WithRequired(e => e.Patient1)
                .HasForeignKey(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Physician>()
                .HasMany(e => e.Affiliated_With)
                .WithRequired(e => e.Physician1)
                .HasForeignKey(e => e.Physician)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Physician>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Physician1)
                .HasForeignKey(e => e.Physician)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Physician>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.Physician)
                .HasForeignKey(e => e.Head)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Physician>()
                .HasMany(e => e.Patients)
                .WithRequired(e => e.Physician)
                .HasForeignKey(e => e.PCP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Physician>()
                .HasMany(e => e.Prescribes)
                .WithRequired(e => e.Physician1)
                .HasForeignKey(e => e.Physician)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Physician>()
                .HasMany(e => e.Trained_In)
                .WithRequired(e => e.Physician1)
                .HasForeignKey(e => e.Physician)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Physician>()
                .HasMany(e => e.Undergoes)
                .WithRequired(e => e.Physician1)
                .HasForeignKey(e => e.Physician)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Procedure>()
                .HasMany(e => e.Trained_In)
                .WithRequired(e => e.Procedure)
                .HasForeignKey(e => e.Treatment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Procedure>()
                .HasMany(e => e.Undergoes)
                .WithRequired(e => e.Procedure1)
                .HasForeignKey(e => e.Procedure)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Stays)
                .WithRequired(e => e.Room1)
                .HasForeignKey(e => e.Room)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stay>()
                .HasMany(e => e.Undergoes)
                .WithRequired(e => e.Stay1)
                .HasForeignKey(e => e.Stay)
                .WillCascadeOnDelete(false);
        }
    }
}
