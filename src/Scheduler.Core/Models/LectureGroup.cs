using System.ComponentModel.DataAnnotations;

namespace Scheduler.Core.Models;

public class LectureGroup
{
    [Key] public Guid Id { get; set; }
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public double Credits { get; set; } = 3;
    public int LectureDaysPerWeek { get; set; } = 2;
    public int MinutesPerLecture { get; set; }
    public Professor? Professor { get; set; }
    public Guid? ProfessorId { get; set; }
    public Guid SeasonId { get; set; }
    public Season? Season { get; set; }
}