using Models.ViewModels;
using Models;

namespace StudentApi.Repositories
{
    public interface IStudentsRepository
    {
        Task<Student> CreateAsync(Student student);

        Task<Student?> DeleteAsync(int id);

        Task<Student> GetAsync(int id);

        Task<List<Student>> GetAllAsync();

        Task<Student?> UpdateAsync(Student updatedStudent);
    }
}