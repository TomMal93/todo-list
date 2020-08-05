using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Domain;
using TodoList.Repository;

namespace TodoList.DomainService
{
    public interface IToDoTaskService
    {
        Task<IEnumerable<ToDoTask>> GetAllToDoTasks(int page);
        Task<ToDoTask> GetToDoTask(Guid toDoTaskID);
        Task<ToDoTask> AddToDoTask(ToDoTask toDoTask);
        Task<IEnumerable<ToDoTask>> GetToDoTasksByIsDoneStatus(int page, IsDoneFiltration isDoneFiltration);
        Task<ToDoTask> UpdateToDoTask(Guid id, ToDoTask toDoTask);
        Task<bool> UpdateToDoTaskIsDone(Guid id, bool isDone);
        Task<bool> UpdateToDoTaskPriorityStatus(Guid id, Priority priorityStatus);
        Task<bool> DeleteToDoTask(Guid toDoTaskID);
        Task<IEnumerable<ToDoTask>> GetToDoTasksByTitle(int page, string title);
        Task<IEnumerable<ToDoTask>> GetToDoTasksByDescription(int page, string description);
    }
}