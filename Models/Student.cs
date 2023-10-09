using System.ComponentModel.DataAnnotations;


namespace StudentFrontEnd.Models;

public class Student
{
[Key]
public int Id { get; set;}
[StringLength(50)]
public string Name { get; set; }
public int Rank { get; set;}
}