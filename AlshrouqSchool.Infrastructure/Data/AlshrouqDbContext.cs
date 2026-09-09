using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlshrouqSchool.Infrastructure.Data;

public class AlshrouqDbContext(DbContextOptions<AlshrouqDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<AcademicYear> AcademicYears => Set<AcademicYear>(); public DbSet<GradeLevel> GradeLevels => Set<GradeLevel>();
    public DbSet<Section> Sections => Set<Section>(); public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<Teacher> Teachers => Set<Teacher>(); public DbSet<Student> Students => Set<Student>(); public DbSet<Parent> Parents => Set<Parent>();
    public DbSet<StudentParent> StudentParents => Set<StudentParent>(); public DbSet<StudentEnrollment> StudentEnrollments => Set<StudentEnrollment>();
    public DbSet<TeachingAssignment> TeachingAssignments => Set<TeachingAssignment>(); public DbSet<ClassSchedule> ClassSchedules => Set<ClassSchedule>();
    public DbSet<Lesson> Lessons => Set<Lesson>(); public DbSet<LessonSection> LessonSections => Set<LessonSection>();
    public DbSet<Quiz> Quizzes => Set<Quiz>(); public DbSet<Question> Questions => Set<Question>(); public DbSet<AnswerChoice> AnswerChoices => Set<AnswerChoice>();
    public DbSet<StudentQuizAttempt> StudentQuizAttempts => Set<StudentQuizAttempt>(); public DbSet<StudentAnswer> StudentAnswers => Set<StudentAnswer>();
    public DbSet<Media> Media => Set<Media>(); public DbSet<Post> Posts => Set<Post>(); public DbSet<PostMedia> PostMedia => Set<PostMedia>(); public DbSet<LessonMedia> LessonMedia => Set<LessonMedia>();
    public DbSet<AttendanceSession> AttendanceSessions => Set<AttendanceSession>(); public DbSet<AttendanceRecord> AttendanceRecords => Set<AttendanceRecord>();
    public DbSet<LiveSession> LiveSessions => Set<LiveSession>(); public DbSet<StudentLiveSessionAttendance> StudentLiveSessionAttendances => Set<StudentLiveSessionAttendance>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);
        foreach (var type in mb.Model.GetEntityTypes().Where(x => typeof(BaseEntity).IsAssignableFrom(x.ClrType)))
            mb.Entity(type.ClrType).Property(nameof(BaseEntity.CreatedAtUtc)).HasDefaultValueSql("SYSUTCDATETIME()");

        mb.Entity<ApplicationUser>(b => { b.Property(x => x.FirstName).HasMaxLength(100).IsRequired(); b.Property(x => x.LastName).HasMaxLength(100).IsRequired(); b.Property(x => x.ProfilePictureUrl).HasMaxLength(2048); });
        mb.Entity<AcademicYear>(b => { b.Property(x => x.Name).HasMaxLength(30); b.HasIndex(x => x.Name).IsUnique(); });
        mb.Entity<GradeLevel>(b => { b.Property(x => x.Name).HasMaxLength(100); b.HasIndex(x => x.LevelNumber).IsUnique(); });
        mb.Entity<Section>(b => { b.Property(x => x.Name).HasMaxLength(50); b.HasIndex(x => new { x.GradeLevelId, x.AcademicYearId, x.Name }).IsUnique(); b.HasOne(x => x.GradeLevel).WithMany(x => x.Sections).HasForeignKey(x => x.GradeLevelId).OnDelete(DeleteBehavior.Restrict); b.HasOne(x => x.AcademicYear).WithMany(x => x.Sections).HasForeignKey(x => x.AcademicYearId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<Subject>(b => { b.Property(x => x.Name).HasMaxLength(150); b.Property(x => x.Code).HasMaxLength(30); b.HasIndex(x => new { x.GradeLevelId, x.Code }).IsUnique(); b.HasOne(x => x.GradeLevel).WithMany(x => x.Subjects).HasForeignKey(x => x.GradeLevelId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<Teacher>(b => { b.Property(x => x.UserId).HasMaxLength(450); b.HasIndex(x => x.UserId).IsUnique(); b.HasIndex(x => x.EmployeeNumber).IsUnique(); b.HasOne(x => x.User).WithOne(x => x.Teacher).HasForeignKey<Teacher>(x => x.UserId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<Student>(b => { b.Property(x => x.UserId).HasMaxLength(450); b.Property(x => x.StudentNumber).HasMaxLength(50); b.HasIndex(x => x.UserId).IsUnique(); b.HasIndex(x => x.StudentNumber).IsUnique(); b.HasOne(x => x.User).WithOne(x => x.Student).HasForeignKey<Student>(x => x.UserId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<Parent>(b => { b.Property(x => x.UserId).HasMaxLength(450); b.HasIndex(x => x.UserId).IsUnique(); b.HasOne(x => x.User).WithOne(x => x.Parent).HasForeignKey<Parent>(x => x.UserId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<StudentParent>(b => { b.Property(x => x.Relationship).HasMaxLength(50); b.HasIndex(x => new { x.StudentId, x.ParentId }).IsUnique(); b.HasOne(x => x.Student).WithMany(x => x.Parents).HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.Cascade); b.HasOne(x => x.Parent).WithMany(x => x.Students).HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<StudentEnrollment>(b => { b.HasIndex(x => new { x.StudentId, x.SectionId }).IsUnique(); b.HasOne(x => x.Student).WithMany(x => x.Enrollments).HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.Cascade); b.HasOne(x => x.Section).WithMany(x => x.Enrollments).HasForeignKey(x => x.SectionId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<TeachingAssignment>(b => { b.HasIndex(x => new { x.TeacherId, x.SectionId, x.SubjectId, x.AcademicYearId }).IsUnique(); b.HasOne(x => x.Teacher).WithMany(x => x.TeachingAssignments).HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.Restrict); b.HasOne(x => x.Section).WithMany(x => x.TeachingAssignments).HasForeignKey(x => x.SectionId).OnDelete(DeleteBehavior.Restrict); b.HasOne(x => x.Subject).WithMany(x => x.TeachingAssignments).HasForeignKey(x => x.SubjectId).OnDelete(DeleteBehavior.Restrict); b.HasOne(x => x.AcademicYear).WithMany(x => x.TeachingAssignments).HasForeignKey(x => x.AcademicYearId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<ClassSchedule>(b => { b.HasIndex(x => new { x.TeachingAssignmentId, x.Day, x.StartTime }).IsUnique(); b.HasCheckConstraint("CK_ClassSchedules_TimeRange", "[EndTime] > [StartTime]"); b.HasOne(x => x.TeachingAssignment).WithMany(x => x.ClassSchedules).HasForeignKey(x => x.TeachingAssignmentId).OnDelete(DeleteBehavior.Cascade); });
        mb.Entity<Lesson>(b => { b.Property(x => x.Title).HasMaxLength(250); b.HasIndex(x => new { x.SubjectId, x.DisplayOrder }); b.HasOne(x => x.Teacher).WithMany(x => x.Lessons).HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.Restrict); b.HasOne(x => x.Subject).WithMany(x => x.Lessons).HasForeignKey(x => x.SubjectId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<LessonSection>(b => { b.HasIndex(x => new { x.LessonId, x.SectionId }).IsUnique(); b.HasOne(x => x.Lesson).WithMany(x => x.Sections).HasForeignKey(x => x.LessonId).OnDelete(DeleteBehavior.Cascade); b.HasOne(x => x.Section).WithMany().HasForeignKey(x => x.SectionId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<Quiz>(b => { b.Property(x => x.TotalMarks).HasPrecision(8, 2); b.Property(x => x.PassingMarks).HasPrecision(8, 2); b.HasOne(x => x.Lesson).WithMany(x => x.Quizzes).HasForeignKey(x => x.LessonId).OnDelete(DeleteBehavior.Cascade); });
        mb.Entity<Question>(b => { b.Property(x => x.Marks).HasPrecision(8, 2); b.HasIndex(x => new { x.QuizId, x.DisplayOrder }).IsUnique(); b.HasOne(x => x.Quiz).WithMany(x => x.Questions).HasForeignKey(x => x.QuizId).OnDelete(DeleteBehavior.Cascade); });
        mb.Entity<AnswerChoice>(b => { b.HasIndex(x => new { x.QuestionId, x.DisplayOrder }).IsUnique(); b.HasIndex(x => x.QuestionId).HasFilter("[IsCorrect] = 1").IsUnique(); b.HasOne(x => x.Question).WithMany(x => x.Choices).HasForeignKey(x => x.QuestionId).OnDelete(DeleteBehavior.Cascade); });
        mb.Entity<StudentQuizAttempt>(b => { b.Property(x => x.Score).HasPrecision(8, 2); b.HasOne(x => x.Student).WithMany(x => x.QuizAttempts).HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.Restrict); b.HasOne(x => x.Quiz).WithMany(x => x.Attempts).HasForeignKey(x => x.QuizId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<StudentAnswer>(b => { b.Property(x => x.AwardedMarks).HasPrecision(8, 2); b.HasIndex(x => new { x.StudentQuizAttemptId, x.QuestionId }).IsUnique(); b.HasOne(x => x.StudentQuizAttempt).WithMany(x => x.Answers).HasForeignKey(x => x.StudentQuizAttemptId).OnDelete(DeleteBehavior.Cascade); b.HasOne(x => x.Question).WithMany().HasForeignKey(x => x.QuestionId).OnDelete(DeleteBehavior.Restrict); b.HasOne(x => x.SelectedAnswerChoice).WithMany().HasForeignKey(x => x.SelectedAnswerChoiceId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<Media>(b => { b.Property(x => x.FileName).HasMaxLength(260); b.Property(x => x.FilePath).HasMaxLength(2048); b.Property(x => x.MimeType).HasMaxLength(100); });
        mb.Entity<Post>(b => { b.Property(x => x.Title).HasMaxLength(250); b.Property(x => x.Slug).HasMaxLength(250); b.HasIndex(x => x.Slug).IsUnique(); });
        mb.Entity<PostMedia>(b => { b.HasIndex(x => new { x.PostId, x.MediaId }).IsUnique(); b.HasOne(x => x.Post).WithMany(x => x.Media).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade); b.HasOne(x => x.Media).WithMany(x => x.Posts).HasForeignKey(x => x.MediaId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<LessonMedia>(b => { b.HasIndex(x => new { x.LessonId, x.MediaId }).IsUnique(); b.HasOne(x => x.Lesson).WithMany(x => x.Media).HasForeignKey(x => x.LessonId).OnDelete(DeleteBehavior.Cascade); b.HasOne(x => x.Media).WithMany(x => x.Lessons).HasForeignKey(x => x.MediaId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<AttendanceSession>(b => { b.HasIndex(x => new { x.ClassScheduleId, x.Date }).IsUnique(); b.HasOne(x => x.ClassSchedule).WithMany(x => x.AttendanceSessions).HasForeignKey(x => x.ClassScheduleId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<AttendanceRecord>(b => { b.HasIndex(x => new { x.AttendanceSessionId, x.StudentId }).IsUnique(); b.HasOne(x => x.AttendanceSession).WithMany(x => x.Records).HasForeignKey(x => x.AttendanceSessionId).OnDelete(DeleteBehavior.Cascade); b.HasOne(x => x.Student).WithMany().HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<LiveSession>(b => { b.Property(x => x.RoomName).HasMaxLength(200); b.HasIndex(x => x.RoomName).IsUnique(); b.HasOne(x => x.Lesson).WithMany(x => x.LiveSessions).HasForeignKey(x => x.LessonId).OnDelete(DeleteBehavior.Restrict); b.HasOne(x => x.Teacher).WithMany(x => x.LiveSessions).HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.Restrict); b.HasOne(x => x.Section).WithMany().HasForeignKey(x => x.SectionId).OnDelete(DeleteBehavior.Restrict); });
        mb.Entity<StudentLiveSessionAttendance>(b => { b.HasIndex(x => new { x.LiveSessionId, x.StudentId }).IsUnique(); b.HasOne(x => x.LiveSession).WithMany(x => x.StudentAttendances).HasForeignKey(x => x.LiveSessionId).OnDelete(DeleteBehavior.Cascade); b.HasOne(x => x.Student).WithMany().HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.Restrict); });
    }
    public override int SaveChanges() { StampUpdates(); return base.SaveChanges(); }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) { StampUpdates(); return base.SaveChangesAsync(cancellationToken); }
    private void StampUpdates() { foreach (var entry in ChangeTracker.Entries<BaseEntity>().Where(x => x.State == EntityState.Modified)) entry.Entity.UpdatedAtUtc = DateTime.UtcNow; }
}
