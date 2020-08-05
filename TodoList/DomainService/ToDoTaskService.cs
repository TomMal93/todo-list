using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Domain;
using TodoList.Repository;

namespace TodoList.DomainService
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;

        public ToDoTaskService(IToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
        }

        public Task<ToDoTask> AddToDoTask(ToDoTask toDoTask)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteToDoTask(Guid toDoTaskID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDoTask>> GetAllToDoTasks(int page)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoTask> GetToDoTask(Guid toDoTaskID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDoTask>> GetToDoTasksByDescription(int page, string description)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDoTask>> GetToDoTasksByIsDoneStatus(int page, IsDoneFiltration isDoneFiltration)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDoTask>> GetToDoTasksByTitle(int page, string title)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoTask> UpdateToDoTask(Guid Id, ToDoTask toDoTask)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateToDoTaskIsDone(Guid toDoTaskID, bool isDone)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateToDoTaskPriorityStatus(Guid id, Priority priorityStatus)
        {
            throw new NotImplementedException();
        }
    }
}
