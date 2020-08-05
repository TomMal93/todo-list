using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Domain;
using TodoList.Infrastructure;

namespace TodoList.Repository
{
    public interface IToDoTaskRepository : IRepository<ToDoTask>
    {
        Task<bool> UpdateToDoTaskIsDone(ToDoTask toDoTaskToUpdate);
        Task<bool> UpdateToDoTaskPriorityStatus(ToDoTask toDoTaskToUpdate);
        Task<IEnumerable<ToDoTask>> GetToDoTasksByIsDoneStatus(int page, IsDoneFiltration isDoneFiltration);
        Task<IEnumerable<ToDoTask>> GetToDoTasksByTitle(int page, string title);
        Task<IEnumerable<ToDoTask>> GetToDoTasksByDescription(int page, string description);
    }

    public enum IsDoneFiltration
    {
        OnlyUndone = 0,
        OnlyDone = 1,
        All = 2
    }
}
