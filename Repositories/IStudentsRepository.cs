using BareBonesFrontEnd.Models.ViewModels;
using StudentFrontEnd.Models;

namespace StudentApi.Repositories
{
    public interface IStudentsRepository
    {
        Task<CreateStudentRequest> CreateAsync(CreateStudentRequest student);

        Task<Student?> DeleteAsync(int id);

        Task<Student?> GetAsync(int id);

        Task<IEnumerable<Student>> GetAllAsync();

        Task<Student?> UpdateAsync(UpdateStudentRequest updatedStudent);
    }
}