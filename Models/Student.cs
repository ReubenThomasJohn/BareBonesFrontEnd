using System.ComponentModel.DataAnnotations;
using Models;


namespace Models;

public class Student
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Rank { get; set; }

    // Required Foreign key property
    public int StateId { get; set; }

    // Navigation property for the state
    public State State { get; set; } = null!;
}