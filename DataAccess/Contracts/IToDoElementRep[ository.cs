using ToDoList.DataAccess.Implementations.Entities;

namespace ToDoList.DataAccess.Contracts
{
    public interface IToDoEntityRepository : IGenericRepository<ToDoElement>
    {
        
    }
}