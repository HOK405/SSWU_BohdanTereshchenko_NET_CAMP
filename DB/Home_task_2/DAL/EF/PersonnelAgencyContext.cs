using Home_task_2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.EF;

public partial class PersonnelAgencyContext : DbContext
{
    public PersonnelAgencyContext()
    {
    }

    public PersonnelAgencyContext(DbContextOptions<PersonnelAgencyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Cv> Cvs { get; set; }

    public virtual DbSet<Cvskill> Cvskills { get; set; }

    public virtual DbSet<Interview> Interviews { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Vacancy> Vacancies { get; set; }

    public virtual DbSet<VacancySkill> VacancySkills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("PersonnelAgencyConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.IdAddress);

            entity.ToTable("Address");

            entity.Property(e => e.IdAddress).HasColumnName("ID_Address");
            entity.Property(e => e.ApartmentNumber).HasMaxLength(10);
            entity.Property(e => e.BuildingNumber).HasMaxLength(10);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.PostalCode).HasMaxLength(30);
            entity.Property(e => e.Region).HasMaxLength(100);
            entity.Property(e => e.Street).HasMaxLength(100);

            entity.HasMany(d => d.IdCompanies).WithMany(p => p.IdAddresses)
                .UsingEntity<Dictionary<string, object>>(
                    "CompanyAddress",
                    r => r.HasOne<Company>().WithMany()
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CompanyAddress_Company"),
                    l => l.HasOne<Address>().WithMany()
                        .HasForeignKey("IdAddress")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CompanyAddress_Address"),
                    j =>
                    {
                        j.HasKey("IdAddress", "IdCompany");
                        j.ToTable("CompanyAddress");
                        j.IndexerProperty<int>("IdAddress").HasColumnName("ID_Address");
                        j.IndexerProperty<int>("IdCompany").HasColumnName("ID_Company");
                    });
        });

        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.IdApplicant);

            entity.ToTable("Applicant");

            entity.Property(e => e.IdApplicant).HasColumnName("ID_Applicant");
            entity.Property(e => e.AddressId).HasColumnName("Address_ID");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.Address).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_Applicant_Address");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.IdCompany);

            entity.ToTable("Company");

            entity.Property(e => e.IdCompany).HasColumnName("ID_Company");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Cv>(entity =>
        {
            entity.HasKey(e => e.IdCv);

            entity.ToTable("CV");

            entity.Property(e => e.IdCv).HasColumnName("ID_CV");
            entity.Property(e => e.ApplicantId).HasColumnName("ApplicantID");
            entity.Property(e => e.JobId).HasColumnName("JobID");

            entity.HasOne(d => d.Applicant).WithMany(p => p.Cvs)
                .HasForeignKey(d => d.ApplicantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CV_Applicant");

            entity.HasOne(d => d.Job).WithMany(p => p.Cvs)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CV_Job");
        });

        modelBuilder.Entity<Cvskill>(entity =>
        {
            entity.HasKey(e => new { e.IdCv, e.IdSkill });

            entity.ToTable("CVSkill");

            entity.Property(e => e.IdCv).HasColumnName("ID_CV");
            entity.Property(e => e.IdSkill).HasColumnName("ID_Skill");
            entity.Property(e => e.Description).HasMaxLength(100);

            entity.HasOne(d => d.IdCvNavigation).WithMany(p => p.Cvskills)
                .HasForeignKey(d => d.IdCv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CVSkill_CV");

            entity.HasOne(d => d.IdSkillNavigation).WithMany(p => p.Cvskills)
                .HasForeignKey(d => d.IdSkill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CVSkill_Skill");
        });

        modelBuilder.Entity<Interview>(entity =>
        {
            entity.HasKey(e => e.IdInterview);

            entity.ToTable("Interview");

            entity.Property(e => e.IdInterview).HasColumnName("ID_Interview");
            entity.Property(e => e.IdCv).HasColumnName("ID_CV");
            entity.Property(e => e.IdVacancy).HasColumnName("ID_Vacancy");
            entity.Property(e => e.InterviewDate).HasColumnType("date");

            entity.HasOne(d => d.IdCvNavigation).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.IdCv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interview_CV");

            entity.HasOne(d => d.IdVacancyNavigation).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.IdVacancy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interview_Vacancy");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.IdJob);

            entity.ToTable("Job");

            entity.Property(e => e.IdJob).HasColumnName("ID_Job");
            entity.Property(e => e.JobLevel).HasMaxLength(50);
            entity.Property(e => e.JobTitle).HasMaxLength(50);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.IdSkill);

            entity.ToTable("Skill");

            entity.Property(e => e.IdSkill).HasColumnName("ID_Skill");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Vacancy>(entity =>
        {
            entity.HasKey(e => e.IdVacancy);

            entity.ToTable("Vacancy");

            entity.Property(e => e.IdVacancy).HasColumnName("ID_Vacancy");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.JobId).HasColumnName("JobID");

            entity.HasOne(d => d.Company).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vacancy_Company");

            entity.HasOne(d => d.Job).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vacancy_Job");
        });

        modelBuilder.Entity<VacancySkill>(entity =>
        {
            entity.HasKey(e => new { e.IdSkill, e.IdVacancy });

            entity.ToTable("VacancySkill");

            entity.Property(e => e.IdSkill).HasColumnName("ID_Skill");
            entity.Property(e => e.IdVacancy).HasColumnName("ID_Vacancy");
            entity.Property(e => e.Description).HasMaxLength(100);

            entity.HasOne(d => d.IdSkillNavigation).WithMany(p => p.VacancySkills)
                .HasForeignKey(d => d.IdSkill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VacancySkill_Skill");

            entity.HasOne(d => d.IdVacancyNavigation).WithMany(p => p.VacancySkills)
                .HasForeignKey(d => d.IdVacancy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VacancySkill_Vacancy");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
