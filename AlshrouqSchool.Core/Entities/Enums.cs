namespace AlshrouqSchool.Core.Entities
{
    public enum MediaType { Image = 1, Video = 2, Document = 3, Audio = 4 }
    public enum MediaCategory { News = 1, Gallery = 2, Lesson = 3, Profile = 4, OurPride = 5 , Other = 6}
    public enum PostType { News = 1, OurPride = 2, Activity = 3, Announcement = 4 }
    public enum AttendanceStatus { Present = 1, Absent = 2, Late = 3, Excused = 4 }
    public enum LiveSessionStatus { Scheduled = 1, Live = 2, Ended = 3, Cancelled = 4 }
    public enum DayOfWeekType { Saturday = 1, Sunday = 2, Monday = 3, Tuesday = 4, Wednesday = 5, Thursday = 6, Friday = 7 }
    public enum MediaRole { Cover = 1, Content = 2, Thumbnail = 3, Attachment = 4 }
}