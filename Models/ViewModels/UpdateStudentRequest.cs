namespace Models.ViewModels;

public class UpdateStudentRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Rank { get; set; }
    public string StateName { get; set; }
}