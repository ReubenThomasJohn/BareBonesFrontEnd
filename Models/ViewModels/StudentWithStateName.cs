namespace BareBonesFrontEnd.Models.ViewModels;

public class StudentWithStateName
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Rank { get; set; }
    public required int StateId { get; set; }
    public string StateName { get; set; }
}

