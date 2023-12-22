using domain;
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
        public DbSet<MajorSubject> majorSubjects { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<RoomAttendance> RoomAttendances { get; set; } = null!;
        public DbSet<Attendance> Attendances { get; set; } = null!;
        public DbSet<Slot> Slots { get; set; } = null!;
        public DbSet<SubjectComponent> SubjectComponents { get; set; } = null!;
        public DbSet<Timetable> Timetables { get; set; } = null!;
        public DbSet<Week> Weeks { get; set; } = null!;
    }
}
