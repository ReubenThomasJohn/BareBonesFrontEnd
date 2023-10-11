using BareBonesFrontEnd.Data;
using BareBonesFrontEnd.Models.ViewModels;
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
        public async Task<CreateStudentRequest> CreateAsync(CreateStudentRequest student)
        {
            string sql = $"EXEC CreateOneStudent '{student.Name}', {student.Rank}, '{student.StateName}'";
            dbContext.Database.ExecuteSqlRaw(sql);
            return student;
        }

        public async Task<Student> DeleteAsync(int id)
        {
            string findStudentString = $"EXEC GetOneStudentDataWithStateName '{id}'";
            var foundStudent = dbContext.Students.FromSqlRaw(findStudentString);
            if (foundStudent != null)
            {
                string sql = $"EXEC DeleteStudentById '{id}'";
                dbContext.Database.ExecuteSqlRaw(sql);
            }
            else
            {

            }
            return foundStudent.ToList()[0];
        }

        public Task<Student>? GetAsync(int id)
        {
            string findStudentString = $"EXEC GetOneStudentDataWithStateName '{id}'";
            var foundStudent = dbContext.Students.FromSqlRaw(findStudentString);
            if (foundStudent != null)
            {

            }
            else
            {

            }
            return Task.FromResult(foundStudent.ToList()[0]);
        }

        public Task<IEnumerable<Student>> GetAllAsync()
        {
            string getAllStudentsString = $"EXEC GetStudentDataWithStateName";
            var foundStudents = dbContext.Students.FromSqlRaw(getAllStudentsString);
            IEnumerable<Student> students = foundStudents;
            return Task.FromResult(students);
        }

        public Task<Student> UpdateAsync(UpdateStudentRequest updatedStudent)
        {
            string findStudentString = $"EXEC GetOneStudentDataWithStateName '{updatedStudent.Id}'";
            var foundStudent = dbContext.Students.FromSqlRaw(findStudentString);
            if (foundStudent != null)
            {
                string updateStudentString = $"EXEC UpdateStudent '{updatedStudent.Name}', {updatedStudent.Rank}, '{updatedStudent.StateName}'";
                dbContext.Database.ExecuteSqlRaw(updateStudentString);
            }
            else
            {

            }
            return Task.FromResult(foundStudent.ToList()[0]);
        }

    }
}