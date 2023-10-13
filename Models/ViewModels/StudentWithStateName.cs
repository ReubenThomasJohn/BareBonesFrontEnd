namespace StudentFrontEnd.Models.ViewModels;

public class StudentWithStateName
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Rank { get; set; }
    public string StateName { get; set; }
}