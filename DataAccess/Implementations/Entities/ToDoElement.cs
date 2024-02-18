using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.DataAccess.Implementations.Entities
{

    [Table("to_do_elements")]
    public class ToDoElement : BaseEntity
    {
        [Column("text")]
        public string Text {get; set;}

        [Column("completed")]
        public bool Completed {get; set;}
    }
}