using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Domain;
using TodoList.Helper;
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

        public async Task<ToDoTask> AddToDoTask(ToDoTask toDoTask)
        {
            var toDoTasks = await _toDoTaskRepository.GetAll();

            if (toDoTasks == null)
            {
                throw new Exception(ExceptionMessages.NoToDoTasksInDatabase);
            }

            if (toDoTasks.Any(x => x.ToDoTaskID == toDoTask.ToDoTaskID))
            {
                throw new Exception(ExceptionMessages.ToDoTaskAlreadyExisted);
            }

            if (toDoTasks.Any(x => x.Title == toDoTask.Title))
            {
                throw new Exception(ExceptionMessages.ToDoTaskTitleAlreadyExisted);
            }

            return await _toDoTaskRepository.Add(toDoTask);
        }

        public async Task<bool> DeleteToDoTask(Guid toDoTaskID)
        {
            var toDoTasks = await _toDoTaskRepository.GetAll();

            if (toDoTasks == null)
            {
                throw new Exception(ExceptionMessages.NoToDoTasksInDatabase);
            }

            var toDoTaskToDelete = toDoTasks.FirstOrDefault(x => x.ToDoTaskID == toDoTaskID);

            if (toDoTaskToDelete == null)
            {
                throw new Exception(ExceptionMessages.ToDoTaskIsNotExisted);
            }

            return await _toDoTaskRepository.Delete(toDoTaskToDelete);
        }

        public async Task<IEnumerable<ToDoTask>> GetAllToDoTasks(int page)
        {
            return await _toDoTaskRepository.GetAll(page);
        }

        public async Task<ToDoTask> GetToDoTask(Guid toDoTaskID)
        {
            return await _toDoTaskRepository.GetById(toDoTaskID);
        }

        public async Task<IEnumerable<ToDoTask>> GetToDoTasksByDescription(int page, string description)
        {
            return await _toDoTaskRepository.GetToDoTasksByDescription(page, description);
        }

        public async Task<IEnumerable<ToDoTask>> GetToDoTasksByIsDoneStatus(int page, IsDoneFiltration isDoneFiltration)
        {
            return await _toDoTaskRepository.GetToDoTasksByIsDoneStatus(page, isDoneFiltration);
        }

        public async Task<IEnumerable<ToDoTask>> GetToDoTasksByTitle(int page, string title)
        {
            return await _toDoTaskRepository.GetToDoTasksByTitle(page, title);
        }

        public async Task<ToDoTask> UpdateToDoTask(Guid id, ToDoTask toDoTask)
        {
            var toDoTasks = await _toDoTaskRepository.GetAll();

            if (toDoTasks == null)
            {
                throw new Exception(ExceptionMessages.NoToDoTasksInDatabase);
            }

            var toDoTaskToUpdate = toDoTasks.FirstOrDefault(x => x.ToDoTaskID == id);

            if (toDoTaskToUpdate == null)
            {
                throw new Exception(ExceptionMessages.ToDoTaskIsNotExisted);
            }

            SetNewValuesTaskToUpdate(toDoTask, toDoTaskToUpdate);
            CheckPriorityLevel(toDoTaskToUpdate);

            return await _toDoTaskRepository.Update(toDoTaskToUpdate);
        }

        private static void CheckPriorityLevel(ToDoTask toDoTaskToUpdate)
        {
            if (toDoTaskToUpdate.PriorityStatus == Priority.High)
            {
                TaskHighlightHelper.HighlightTask(toDoTaskToUpdate);
            }
            else if (toDoTaskToUpdate.PriorityStatus != Priority.High && toDoTaskToUpdate.Title.Contains("\u2605"))
            {
                TaskHighlightHelper.StopHighlightTask(toDoTaskToUpdate);
            }
        }

        private void SetNewValuesTaskToUpdate(ToDoTask toDoTask, ToDoTask toDoTaskToUpdate)
        {
            toDoTaskToUpdate.Description = toDoTask.Description;
            toDoTaskToUpdate.FinishDate = toDoTask.FinishDate;
            toDoTaskToUpdate.Title = toDoTask.Title;
            toDoTaskToUpdate.IsDone = toDoTask.IsDone;
            toDoTaskToUpdate.PriorityStatus = toDoTask.PriorityStatus;
        }

        public async Task<bool> UpdateToDoTaskIsDone(Guid id, bool isDone)
        {
            var toDoTasks = await _toDoTaskRepository.GetAll();

            if (toDoTasks == null)
            {
                throw new Exception(ExceptionMessages.NoToDoTasksInDatabase);
            }

            var toDoTaskToUpdate = toDoTasks.FirstOrDefault(x => x.ToDoTaskID == id);

            if (toDoTaskToUpdate == null)
            {
                throw new Exception(ExceptionMessages.ToDoTaskIsNotExisted);
            }

            toDoTaskToUpdate.IsDone = isDone;

            return await _toDoTaskRepository.UpdateToDoTaskIsDone(toDoTaskToUpdate);
        }

        public async Task<bool> UpdateToDoTaskPriorityStatus(Guid id, Priority priorityStatus)
        {
            var toDoTasks = await _toDoTaskRepository.GetAll();

            if (toDoTasks == null)
            {
                throw new Exception(ExceptionMessages.NoToDoTasksInDatabase);
            }

            var toDoTaskToUpdate = toDoTasks.FirstOrDefault(x => x.ToDoTaskID == id);

            if (toDoTaskToUpdate == null)
            {
                throw new Exception(ExceptionMessages.ToDoTaskIsNotExisted);
            }

            toDoTaskToUpdate.PriorityStatus = priorityStatus;

            CheckPriorityLevel(toDoTaskToUpdate);

            return await _toDoTaskRepository.UpdateToDoTaskPriorityStatus(toDoTaskToUpdate);
        }
    }
}
