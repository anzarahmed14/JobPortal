using JobPortal.Model;
using JobPortal.Model.Job;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data
{
    public class JobPortalDbContext : DbContext
    {
        public JobPortalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User>  Users { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<AcademicInfo> AcademicInfos { get; set; } // Add this line

        public DbSet<Designation> Designations { get; set; }

        public DbSet<EmploymentInfo> EmploymentInfos { get; set; }

        public DbSet<ExperienceInfo> Experiences { get; set; }

        public DbSet<Country>  Countries { get; set; }
        public DbSet<State> States { get; set; }

        public DbSet<AddressInfo>  AddressInfos { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<TrainLine> TrainLines { get; set; }

        public DbSet<NoticePeriod> NoticePeriods { get; set; }

        public DbSet<Skill> Skills { get; set; }
        
        public DbSet<SkillCategory>  SkillCategories { get; set; }

        public DbSet<ExportLevel>  ExportLevels { get; set; }


        public DbSet<SkillInfo> SkillInfos { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<JobInfo>  JobInfos { get; set; }

        public DbSet<JobSkill> JobSkills { get; set; }

        public DbSet<JobCity> JobCities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }  

    }
}
