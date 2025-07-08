using EducationApp.Core.Enums;

namespace EducationApp.Core.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }

        public Student Student { get; set; }
        public Group Group { get; set; }
        public Subject Subject { get; set; }
    }
}