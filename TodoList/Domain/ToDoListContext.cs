using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Domain
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<ToDoTask> ToDoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>().HasData(new ToDoTask
            {
                ToDoTaskID = Guid.NewGuid(),
                Title = "Zakupy",
                Description = "Makaron, mięso",
                FinishDate = new DateTime(2020, 08, 05, 18, 00, 00),
                IsDone = false,
                PriorityStatus = Priority.High
            },
            new ToDoTask
            {
                ToDoTaskID = Guid.NewGuid(),
                Title = "Zrobić pranie",
                Description = "",
                FinishDate = DateTime.Now.AddDays(1),
                IsDone = false,
                PriorityStatus = Priority.Medium
            },
            new ToDoTask
            {
                ToDoTaskID = Guid.NewGuid(),
                Title = "Zrobić kolację",
                Description = "Spaghetti",
                FinishDate = new DateTime(2020, 08, 05, 19, 00, 00),
                IsDone = false,
                PriorityStatus = Priority.High
            },
            new ToDoTask
            {
                ToDoTaskID = Guid.NewGuid(),
                Title = "Odebrać dzieci ze szkoły",
                Description = "",
                FinishDate = new DateTime(2020, 08, 05, 15, 00, 00),
                IsDone = true,
                PriorityStatus = Priority.High
            },
            new ToDoTask
            {
                ToDoTaskID = Guid.NewGuid(),
                Title = "Zaplanować weekend",
                Description = "Czas dla rodziny",
                FinishDate = new DateTime(2020, 08, 07, 15, 00, 00),
                IsDone = false,
                PriorityStatus = Priority.Low
            },
            new ToDoTask
            {
                ToDoTaskID = Guid.NewGuid(),
                Title = "Trening",
                Description = "",
                FinishDate = new DateTime(2020, 08, 06, 20, 00, 00),
                IsDone = false,
                PriorityStatus = Priority.Medium
            });
        }
    }
}
