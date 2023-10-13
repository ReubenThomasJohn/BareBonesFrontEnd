using Models;

namespace BareBonesFrontEnd.Repositories;

public interface IStateRepository
{
    Task<List<State>> GetStates();
    Task<State> GetStateById();
}