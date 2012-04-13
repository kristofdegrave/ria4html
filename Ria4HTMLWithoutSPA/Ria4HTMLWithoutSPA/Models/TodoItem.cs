using System.ComponentModel.DataAnnotations;

namespace Ria4HTMLWithoutSPA.Models
{
    public class TodoItem
    {
        [Key]
        public int TodoItemId { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}