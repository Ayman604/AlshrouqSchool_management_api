using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace AlshrouqSchool.Infrastructure.Data;

public class AlshrouqDbContext(DbContextOptions<AlshrouqDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    #region DbSets 
    public DbSet<AcademicYear> AcademicYears => Set<AcademicYear>();
    public DbSet<GradeLevel> GradeLevels => Set<GradeLevel>();
    public DbSet<Section> Sections => Set<Section>();
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Parent> Parents => Set<Parent>();
    public DbSet<StudentParent> StudentParents => Set<StudentParent>();
    public DbSet<StudentEnrollment> StudentEnrollments => Set<StudentEnrollment>();
    public DbSet<TeachingAssignment> TeachingAssignments => Set<TeachingAssignment>();
    public DbSet<ClassSchedule> ClassSchedules => Set<ClassSchedule>();
    public DbSet<Lesson> Lessons => Set<Lesson>();
    public DbSet<LessonSection> LessonSections => Set<LessonSection>();
    public DbSet<Quiz> Quizzes => Set<Quiz>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<AnswerChoice> AnswerChoices => Set<AnswerChoice>();
    public DbSet<StudentQuizAttempt> StudentQuizAttempts => Set<StudentQuizAttempt>();
    public DbSet<StudentAnswer> StudentAnswers => Set<StudentAnswer>();
    public DbSet<Media> Media => Set<Media>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<PostMedia> PostMedia => Set<PostMedia>();
    public DbSet<LessonMedia> LessonMedia => Set<LessonMedia>();
    public DbSet<AttendanceSession> AttendanceSessions => Set<AttendanceSession>();
    public DbSet<AttendanceRecord> AttendanceRecords => Set<AttendanceRecord>();
    public DbSet<LiveSession> LiveSessions => Set<LiveSession>();
    public DbSet<StudentLiveSessionAttendance> StudentLiveSessionAttendances => Set<StudentLiveSessionAttendance>();

    #endregion
    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        base.OnModelCreating(modelbuilder);
        //foreach (var type in modelbuilder.Model.GetEntityTypes().Where(x => typeof(BaseEntity).IsAssignableFrom(x.ClrType)))
        //    modelbuilder.Entity(type.ClrType).Property(nameof(BaseEntity.CreatedAtUtc)).HasDefaultValueSql("SYSUTCDATETIME()");

        modelbuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        // Global query filters for soft deletes
        modelbuilder.Entity<Media>().HasQueryFilter(x => !x.IsDeleted && x.DeletedAtUtc == null);
        modelbuilder.Entity<Post>().HasQueryFilter(x => !x.IsDeleted && x.DeletedAtUtc == null);
    }
    public override int SaveChanges() { StampUpdates(); return base.SaveChanges(); }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) { StampUpdates(); return base.SaveChangesAsync(cancellationToken); }
    private void StampUpdates() { foreach (var entry in ChangeTracker.Entries<BaseEntity>().Where(x => x.State == EntityState.Modified)) entry.Entity.UpdatedAtUtc = DateTime.UtcNow; }
}
