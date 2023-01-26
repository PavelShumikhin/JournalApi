using JournalApi.Model.Entitys.Access;
using JournalApi.Model.Entitys.Journal;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace JournalApi.Data
{
    public class JournalDbContext:DbContext
    {
    //    public JournalDbContext(DbContextOptions<JournalDbContext> options)
    //: base(options)
    //    {
    //    }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersGroup> UsersGroups { get; set; }

        // таблицы Journal
        public DbSet<StudyGroup> StudyGroups { get; set; }
        public DbSet<StudySubject> StudySubjects { get; set; }
        public DbSet<StudyOccupation> StudyOccupations { get; set; }
        public DbSet<StudyStudent> StudyStudents { get; set; }
        public DbSet<StudyGrade> StudyGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UsersGroup>().ToTable("UsersGroups");
            modelBuilder.Entity<StudyGroup>().ToTable("StudyGroup");
            modelBuilder.Entity<StudySubject>().ToTable("StudySubject");
            modelBuilder.Entity<StudyOccupation>().ToTable("StudyOccupation");
            modelBuilder.Entity<StudyStudent>().ToTable("StudyStudent");
            modelBuilder.Entity<StudyGrade>().ToTable("StudyGrade");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключения
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("JournalDbConnection"));
        }
    }
}
