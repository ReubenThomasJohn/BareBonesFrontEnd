using Models;

namespace BareBonesFrontEnd.Models.ViewModels;

public class StudentWithAllStateNames
{
    public Student? Student { get; set; }
    public List<State> States { get; set; }
}