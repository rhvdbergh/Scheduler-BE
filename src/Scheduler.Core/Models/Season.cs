using System.ComponentModel.DataAnnotations;

namespace Scheduler.Core.Models;

public class Season
{
    [Key] 
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IList<LectureGroup>? LectureGroups { get; set; }
}