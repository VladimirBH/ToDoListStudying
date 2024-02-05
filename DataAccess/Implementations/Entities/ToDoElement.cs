using System.Runtime.CompilerServices;
using ToDoList.DataAccess.Implementations.Entities;

namespace ToDoList.DataAccess.Implementations.Entities
{
    public enum Status
    {
        NotStarted,
        InProgress,
        Completed
    }
    public class ToDoElement : BaseEntity
    {
        public string Text {get; set;}
        public Status ElementStatus {get; set;}
    }
}