using Models;

namespace BareBonesFrontEnd.Models.ViewModels;

public class UpdateStudentViewModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Rank { get; set; }

    // Required Foreign key property
    public int SelectedStateId { get; set; }
    public List<State>? States { get; set; }
}