using BareBonesFrontEnd.Data;
using StudentFrontEnd.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using StudentApi.Repositories;
using StudentFrontEnd.Models;

namespace BareBonesFrontEnd.Repositories
{
    public class StoredProceduresStudentRepository : IStudentsRepository
    {
        private readonly StudentListContext dbContext;

        public StoredProceduresStudentRepository(StudentListContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Student> CreateAsync(Student student)
        {
            string sql = $"EXECUTE dbo.CreateOneStudent '{student.Name}', {student.Rank}, '{student.StateId}'";
            dbContext.Database.ExecuteSqlRaw(sql);
            return student;
        }

        public async Task<Student> DeleteAsync(int id)
        {
            string findStudentString = $"EXEC GetOneStudentDataWithStateName '{id}'";
            var foundStudent = dbContext.Students.FromSqlRaw(findStudentString).FirstOrDefault();
            if (foundStudent != null)
            {
                string sql = $"EXEC DeleteStudentById '{id}'";
                dbContext.Database.ExecuteSqlRaw(sql);
            }
            else
            {

            }
            return foundStudent;
        }

        public Task<Student>? GetAsync(int id)
        {
            string findStudentString = $"EXEC GetOneStudentDataWithStateName '{id}'";
            var foundStudent = dbContext.Students
                                        .FromSqlRaw(findStudentString)
                                        .FirstOrDefault();
            if (foundStudent != null)
            {

            }
            else
            {

            }
            return Task.FromResult(foundStudent);
        }

        public Task<List<Student>> GetAllAsync()
        {
            string getAllStudentsString = "EXEC GetStudentDataWithStateName";

            var foundStudents = dbContext.Students
                .FromSqlRaw(getAllStudentsString)
                .ToList();

            return Task.FromResult(foundStudents);
        }

        public async Task<Student> UpdateAsync(Student updatedStudent)
        {
            string findStudentString = $"EXECUTE dbo.GetOneStudentDataWithStateName '{updatedStudent.Id}'";
            var foundStudent = await dbContext.Students.FromSqlRaw(findStudentString).FirstOrDefaultAsync();
            if (foundStudent != null)
            {
                string updateStudentString = $"EXECUTE dbo.UpdateStudent '{updatedStudent.Name}', {updatedStudent.Rank}, '{updatedStudent.Id}'";
                dbContext.Database.ExecuteSqlRaw(updateStudentString);
            }
            else
            {

            }
            return foundStudent;
        }

    }
}