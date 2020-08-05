using Microsoft.EntityFrameworkCore;
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

        public Task<ToDoTask> Add(ToDoTask toDoTaskToAdd)
        {
            return Task.Run(() =>
            {
                if (_toDoListContext != null)
                {
                    _toDoListContext.Add(toDoTaskToAdd);
                    _toDoListContext.SaveChanges();
                    return toDoTaskToAdd;
                }
                else
                {
                    return null;
                }
            });
        }

        public Task<bool> Delete(ToDoTask toDoTaskToDelete)
        {
            return Task.Run(() =>
            {
                if (_toDoListContext != null)
                {
                    _toDoListContext.Remove(toDoTaskToDelete);
                    _toDoListContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }

        public Task<List<ToDoTask>> GetAll()
        {
            return Task.Run(async () => await _toDoListContext.ToDoTasks.ToListAsync());
        }

        public async Task<IEnumerable<ToDoTask>> GetAll(int page)
        {
            return await GetPage(page);
        }

        public Task<ToDoTask> GetById(Guid id)
        {
            return Task.Run(() => _toDoListContext.ToDoTasks.Where(e => e.ToDoTaskID == id).FirstOrDefaultAsync());
        }

        public Task<IPagedList<ToDoTask>> GetPage(int page)
        {
            return Task.Run(() =>
            {
                var products = _toDoListContext.ToDoTasks.OrderByDescending(x => x.PriorityStatus).ThenBy(x => x.Title);
                var pageNumber = (page != 0) ? page : 1;

                return products.ToPagedList(pageNumber, 3);
            });
        }

        public Task<IPagedList<ToDoTask>> GetPage(int page, Expression<Func<ToDoTask, bool>> where)
        {
            return Task.Run(() =>
            {
                var products = _toDoListContext.ToDoTasks.Where(where).OrderByDescending(x => x.PriorityStatus).ThenBy(x => x.Title);
                var pageNumber = (page != 0) ? page : 1;

                return products.ToPagedList(pageNumber, 3);
            });
        }

        public async Task<IEnumerable<ToDoTask>> GetToDoTasksByDescription(int page, string description)
        {
            return await GetPage(page, x => x.Description.Contains(description));
        }

        public async Task<IEnumerable<ToDoTask>> GetToDoTasksByIsDoneStatus(int page, IsDoneFiltration isDoneFiltration)
        {
            return isDoneFiltration switch
            {
                IsDoneFiltration.OnlyUndone => await GetPage(page, e => !e.IsDone),
                IsDoneFiltration.OnlyDone => await GetPage(page, e => e.IsDone),
                IsDoneFiltration.All => await GetPage(page),
                _ => null,
            };
        }

        public async Task<IEnumerable<ToDoTask>> GetToDoTasksByTitle(int page, string title)
        {
            return await GetPage(page, x => x.Title.Contains(title));
        }

        public Task<ToDoTask> Update(ToDoTask toDoTask)
        {
            return Task.Run(() =>
            {
                if (_toDoListContext != null)
                {
                    _toDoListContext.Update(toDoTask);
                    _toDoListContext.SaveChanges();
                    return toDoTask;
                }
                else
                {
                    return null;
                }
            });
        }

        public Task<bool> UpdateToDoTaskIsDone(ToDoTask toDoTaskToUpdate)
        {
            return Task.Run(() =>
            {
                if (_toDoListContext != null)
                {
                    _toDoListContext.Update(toDoTaskToUpdate);
                    _toDoListContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }

        public Task<bool> UpdateToDoTaskPriorityStatus(ToDoTask toDoTaskToUpdate)
        {
            return Task.Run(() =>
            {
                if (_toDoListContext != null)
                {
                    _toDoListContext.Update(toDoTaskToUpdate);
                    _toDoListContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }
    }
}
