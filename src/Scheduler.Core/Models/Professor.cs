using System.ComponentModel.DataAnnotations;

namespace Scheduler.Core.Models;

public class Professor
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
}