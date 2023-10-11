using StudentFrontEnd.Models;

namespace BareBonesFrontEnd.Models;

public class State
{
    public int Id { get; set; }
    public required string StateName { get; set; }

    // Navigation Property for students
    public ICollection<Student> Students { get; set; } = new List<Student>();
}