using System.ComponentModel.DataAnnotations;

namespace Scheduler.Core.Models;

public class Professor
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool isAdjunct { get; set; }
    public int MaxLectureGroups { get; set; } = 5;
    public IList<LectureGroup>? LectureGroups { get; set; }
    public IList<ProfessorPreference>? ProfessorPreferences { get; set; }
}