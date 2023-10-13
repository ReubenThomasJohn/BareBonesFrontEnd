using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BareBonesFrontEnd.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BareBonesFrontEnd.Repositories
{
    public class StoredProceduresStateRepository : IStateRepository
    {
        private readonly StudentListContext dbContext;

        public StoredProceduresStateRepository(StudentListContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<State> GetStateById()
        {
            throw new NotImplementedException();
        }

        public Task<List<State>> GetStates()
        {
            string getAllStatesString = $"EXECUTE dbo.SelectAllStates";
            var states = dbContext.States.FromSqlRaw(getAllStatesString).ToList();
            return Task.FromResult(states);
        }
    }
}