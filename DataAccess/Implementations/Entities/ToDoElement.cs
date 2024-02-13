using System.ComponentModel.DataAnnotations.Schema;
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

    [Table("to_do_element")]
    public class ToDoElement : BaseEntity
    {
        [Column("text")]
        public string Text {get; set;}

        [Column("status")]
        public Status ElementStatus {get; set;}
    }
}