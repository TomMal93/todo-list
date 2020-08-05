using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain
{
    public class ToDoTask
    {
        [Key]
        public Guid ToDoTaskID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsDone { get; set; }
        public Priority PriorityStatus { get; set; }
    }

    public enum Priority
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
}
