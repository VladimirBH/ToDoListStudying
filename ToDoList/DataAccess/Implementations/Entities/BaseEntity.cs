using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoList.DataAccess.Contracts;

namespace ToDoList.DataAccess.Implementations.Entities
{
    public class BaseEntity:IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}