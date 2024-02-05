using ToDoList.DataAccess.Contracts;
using ToDoList.DataAccess.DBContexts;
using ToDoList.DataAccess.Implementations.Entities;

namespace ToDoList.DataAccess.Repositories
{
    public class ToDoElementRepository(ApplicationContext context, IConfiguration configuration) : GenericRepository<ToDoElement>(context, configuration), IToDoEntityRepository
    {
    }
}