using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoList.Domain;
using X.PagedList;

namespace TodoList.Repository
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly ToDoListContext _toDoListContext;

        public ToDoTaskRepository(ToDoListContext toDoListContext)
        {
            _toDoListContext = toDoListContext;
        }

        public Task<ToDoTask> Add(ToDoTask entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ToDoTask entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoTask>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDoTask>> GetAll(int page)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoTask> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<ToDoTask>> GetPage(int page)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<ToDoTask>> GetPage(int page, Expression<Func<ToDoTask, bool>> where)
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

        public Task<ToDoTask> Update(ToDoTask entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateToDoTaskIsDone(ToDoTask toDoTaskToUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateToDoTaskPriorityStatus(ToDoTask toDoTaskToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
