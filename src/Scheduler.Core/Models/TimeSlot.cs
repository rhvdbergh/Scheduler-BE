using System.ComponentModel.DataAnnotations;

namespace Scheduler.Core.Models;

public class TimeSlot
{
    [Key]
    public Guid Id { get; set; }
    public Guid SeasonId { get; set; }
    public Season? Season { get; set; }
    public bool IsBreak { get; set; }
    public DayOfWeek DayOfWeek { get; set; } 
    public TimeOnly StartTime { get; set; }
    public int DurationInMinutes { get; set; }
    public LectureGroup? LectureGroup { get; set; }
    public Guid? LectureGroupId { get; set; }
}