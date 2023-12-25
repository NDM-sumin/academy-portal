using domain;
using domain.CompositeKeys;
using Microsoft.EntityFrameworkCore;

namespace entityframework
{
    public class AppDbContext : DbContext
    {


        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> optionsBuilder) : base(optionsBuilder)
        {

        }

        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Score> Scores { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Semester> Semesters { get; set; } = null!;
        public DbSet<Class> Classes { get; set; } = null!;
        public DbSet<FeeDetail> FeeDetails { get; set; } = null!;
        public DbSet<Major> Majors { get; set; } = null!;
        public DbSet<MajorSubject> MajorSubjects { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<Attendance> Attendances { get; set; } = null!;
        public DbSet<SlotTimeTableAtWeek> SlotTimeTableAtWeeks { get; set; } = null!;
        public DbSet<Slot> Slots { get; set; } = null!;
        public DbSet<SubjectComponent> SubjectComponents { get; set; } = null!;
        public DbSet<Timetable> Timetables { get; set; } = null!;
        public DbSet<Week> Weeks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasQueryFilter(s => s.Role == domain.shared.Enums.Role.Student);
            modelBuilder.Entity<Account>().HasQueryFilter(s => s.Role == domain.shared.Enums.Role.Teacher);
            modelBuilder.Entity<Attendance>().HasKey(ra => new { ra.SlotTimeTableAtWeekId, ra.RoomId, ra.FeeDetailId });
            modelBuilder.Entity<MajorSubject>().HasIndex(ra => new { ra.MajorId, ra.SubjectId }).IsUnique();
            //modelBuilder.Entity<FeeDetail>().HasKey(ra => new { ra.SemesterId, ra.StudentId, ra.SubjectId, ra.ClassId });
            modelBuilder.Entity<FeeDetail>().HasIndex(ra => new { ra.SemesterId, ra.StudentId, ra.SubjectId, ra.ClassId }).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
