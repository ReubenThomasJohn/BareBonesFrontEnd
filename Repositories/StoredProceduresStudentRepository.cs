using BareBonesFrontEnd.Data;
using Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using StudentApi.Repositories;
using Models;

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
            string sql = $"EXECUTE dbo.CreateOneStudentWithId '{student.Name}', {student.Rank}, '{student.StateId}'";
            dbContext.Database.ExecuteSqlRaw(sql);
            return student;
        }

        public async Task<Student> DeleteAsync(int id)
        {
            string findStudentString = $"EXEC GetOneStudentDataWithStateId '{id}'";
            var foundStudent = dbContext.Students.FromSqlRaw(findStudentString).ToList()[0];
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
            string findStudentString = $"EXEC GetOneStudentDataWithStateId '{id}'";
            var foundStudent = dbContext.Students
                                        .FromSqlRaw(findStudentString)
                                        .ToList();
            if (foundStudent != null)
            {

            }
            else
            {

            }
            return Task.FromResult(foundStudent[0]);
        }

        public Task<List<Student>> GetAllAsync()
        {
            string getAllStudentsString = "EXEC GetAllStudentsWithStateId ";

            var foundStudents = dbContext.Students
                .FromSqlRaw(getAllStudentsString)
                .ToList();

            return Task.FromResult(foundStudents);
        }

        public async Task<Student> UpdateAsync(Student updatedStudent)
        {
            string findStudentString = $"EXECUTE dbo.GetOneStudentDataWithStateId '{updatedStudent.Id}'";
            var foundStudent = dbContext.Students.FromSqlRaw(findStudentString).ToList()[0];
            if (foundStudent != null)
            {
                string updateStudentString = $"EXECUTE dbo.UpdateStudentStateId '{updatedStudent.Id}', '{updatedStudent.Name}', {updatedStudent.Rank}, {updatedStudent.StateId}";
                dbContext.Database.ExecuteSqlRaw(updateStudentString);
            }
            else
            {

            }
            return foundStudent;
        }

    }
}