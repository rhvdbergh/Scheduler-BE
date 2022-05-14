using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Scheduler.Core.Models.Shared;

namespace Scheduler.Core.Models;

public class ProfessorPreference
{
    [Key]
    public Guid Id { get; set; }
    
    public DayOfTheWeek? PreferredDay { get; set; } 
    public TimeOnly? PreferredTime { get; set; }
    public DayOfTheWeek? NotPreferredDay { get; set; }
    public TimeOnly? NotPreferredTime { get; set; }

    public Guid ProfessorId { get; set; }
    public Professor? Professor { get; set; }
}