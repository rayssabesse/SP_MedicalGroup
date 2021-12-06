using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SPMedicalGroup.Domains;

#nullable disable

namespace SPMedicalGroup.Context
{
    public partial class SPMedicalGroupContext : DbContext
    {
        public SPMedicalGroupContext()
        {
        }

        public SPMedicalGroupContext(DbContextOptions<SPMedicalGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DoctorJob> DoctorJobs { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Situation> Situations { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<Userr> Userrs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CYBERNOTE-02\\SQLEXPRESS; Initial Catalog=SPMedicalGroup; user id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.IdAppointment)
                    .HasName("PK__Appointm__44E34BD41B49915A");

                entity.ToTable("Appointment");

                entity.Property(e => e.IdAppointment).HasColumnName("idAppointment");

                entity.Property(e => e.DateAppointment)
                    .HasColumnType("date")
                    .HasColumnName("dateAppointment");

                entity.Property(e => e.DescriptionAppointment)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("descriptionAppointment");

                entity.Property(e => e.IdDoctor).HasColumnName("idDoctor");

                entity.Property(e => e.IdPatient).HasColumnName("idPatient");

                entity.Property(e => e.IdSituation).HasColumnName("idSituation");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__idDoc__5441852A");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__idPat__534D60F1");

                entity.HasOne(d => d.IdSituationNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdSituation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__idSit__5535A963");
            });

            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.HasKey(e => e.IdClinic)
                    .HasName("PK__Clinic__A0E463108DADDFEC");

                entity.ToTable("Clinic");

                entity.HasIndex(e => e.CnpjClinic, "UQ__Clinic__1DDBCCAEF9084B18")
                    .IsUnique();

                entity.HasIndex(e => e.SocialReason, "UQ__Clinic__CF12A7AB76E6E605")
                    .IsUnique();

                entity.Property(e => e.IdClinic).HasColumnName("idClinic");

                entity.Property(e => e.AddressClinic)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("addressClinic");

                entity.Property(e => e.CloseClinic).HasColumnName("closeClinic");

                entity.Property(e => e.CnpjClinic)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cnpjClinic")
                    .IsFixedLength(true);

                entity.Property(e => e.NameClinic)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameClinic");

                entity.Property(e => e.OpenClinic).HasColumnName("openClinic");

                entity.Property(e => e.SocialReason)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("socialReason");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("PK__Doctor__418956C3D0966056");

                entity.ToTable("Doctor");

                entity.HasIndex(e => e.IdUser, "UQ__Doctor__3717C9837A1F8B0F")
                    .IsUnique();

                entity.HasIndex(e => e.CrmDoctor, "UQ__Doctor__D0886D34B07EFBE0")
                    .IsUnique();

                entity.Property(e => e.IdDoctor).HasColumnName("idDoctor");

                entity.Property(e => e.CrmDoctor)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("crmDoctor");

                entity.Property(e => e.IdClinic).HasColumnName("idClinic");

                entity.Property(e => e.IdDoctorJob).HasColumnName("idDoctorJob");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.NameDoctor)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("nameDoctor");

                entity.HasOne(d => d.IdClinicNavigation)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.IdClinic)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Doctor__idClinic__4E88ABD4");

                entity.HasOne(d => d.IdDoctorJobNavigation)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.IdDoctorJob)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Doctor__idDoctor__4D94879B");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.Doctor)
                    .HasForeignKey<Doctor>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Doctor__idUser__4CA06362");
            });

            modelBuilder.Entity<DoctorJob>(entity =>
            {
                entity.HasKey(e => e.IdDoctorJob)
                    .HasName("PK__DoctorJo__C86D0603ABE88A8D");

                entity.ToTable("DoctorJob");

                entity.HasIndex(e => e.NameDoctorJob, "UQ__DoctorJo__FA96107ADE2AF1CD")
                    .IsUnique();

                entity.Property(e => e.IdDoctorJob).HasColumnName("idDoctorJob");

                entity.Property(e => e.NameDoctorJob)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameDoctorJob");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient)
                    .HasName("PK__Patient__8C2428058E05F5CE");

                entity.ToTable("Patient");

                entity.HasIndex(e => e.RgPatient, "UQ__Patient__0D3F0CA50828CCDC")
                    .IsUnique();

                entity.HasIndex(e => e.IdUser, "UQ__Patient__3717C983D79745EE")
                    .IsUnique();

                entity.HasIndex(e => e.CpfPatient, "UQ__Patient__8035269383D21610")
                    .IsUnique();

                entity.HasIndex(e => e.DobPatient, "UQ__Patient__AD16A59F76FFB899")
                    .IsUnique();

                entity.Property(e => e.IdPatient).HasColumnName("idPatient");

                entity.Property(e => e.AddressPatient)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("addressPatient");

                entity.Property(e => e.CpfPatient)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cpfPatient");

                entity.Property(e => e.DobPatient)
                    .HasColumnType("date")
                    .HasColumnName("dobPatient");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.NamePatient)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("namePatient");

                entity.Property(e => e.PhonePatient)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phonePatient");

                entity.Property(e => e.RgPatient)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("rgPatient");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.Patient)
                    .HasForeignKey<Patient>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Patient__idUser__412EB0B6");
            });

            modelBuilder.Entity<Situation>(entity =>
            {
                entity.HasKey(e => e.IdSituation)
                    .HasName("PK__Situatio__35C76303DD34A32F");

                entity.ToTable("Situation");

                entity.Property(e => e.IdSituation).HasColumnName("idSituation");

                entity.Property(e => e.TypeSituation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("typeSituation");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.IdUserType)
                    .HasName("PK__UserType__96375927A815D6EE");

                entity.ToTable("UserType");

                entity.HasIndex(e => e.UserType1, "UQ__UserType__87E78691789D71F7")
                    .IsUnique();

                entity.Property(e => e.IdUserType).HasColumnName("idUserType");

                entity.Property(e => e.UserType1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UserType");
            });

            modelBuilder.Entity<Userr>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Userr__3717C98237EC77B6");

                entity.ToTable("Userr");

                entity.HasIndex(e => e.EmailUser, "UQ__Userr__AF638C4CAAFC8223")
                    .IsUnique();

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.EmailUser)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("emailUser");

                entity.Property(e => e.IdUserType).HasColumnName("idUserType");

                entity.Property(e => e.PasswordUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("passwordUser");

                entity.HasOne(d => d.IdUserTypeNavigation)
                    .WithMany(p => p.Userrs)
                    .HasForeignKey(d => d.IdUserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Userr__idUserTyp__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
