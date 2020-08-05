using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Domain;
using TodoList.DomainService;
using TodoList.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoList.Controllers
{
    [Route("[controller]")]
    public class ToDoListController : Controller
    {
        private readonly IToDoTaskService _toDoTaskService;
        public ToDoListController(IToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
        }

        /// <summary>
        /// Get all todo tasks limited by pagination
        /// </summary>
        /// <param name="page">Page number to display</param>
        /// <returns>Ok/Bad Request</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Fail</response>
        [HttpGet("GetAllToDoTasks/{page}")]
        public IActionResult GetAllToDoTasks(int page = 1)
        {
            try
            {
                var allToDoTasks = _toDoTaskService.GetAllToDoTasks(page).Result;
                return Ok(allToDoTasks);
            }
            catch (Exception ex)
            {
                //TODO log exception 
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get single todo task
        /// </summary>
        /// <param name="id">Id of task to display</param>
        /// <returns>Ok/Bad Request</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Fail</response>
        [HttpGet("GetToDoTask/{id}")]
        public IActionResult GetToDoTask(Guid id)
        {
            try
            {
                var toDoTask = _toDoTaskService.GetToDoTask(id).Result;
                return Ok(toDoTask);
            }
            catch (Exception ex)
            {
                //TODO log exception 
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Get all done todo tasks limited by pagination
        /// </summary>
        /// <param name="isDoneFiltration">Filtration level - 0 - undone, 1 - done, 2 - all</param>
        /// <param name="page">Page number to display</param>
        /// <returns>Ok/Bad Request</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Fail</response>
        [HttpGet("GetToDoTasksByIsDoneStatus/{isDoneFiltration}/{page}")]
        public IActionResult GetToDoTasksByIsDoneStatus(IsDoneFiltration isDoneFiltration, int page = 1)
        {
            try
            {
                var toDoTask = _toDoTaskService.GetToDoTasksByIsDoneStatus(page, isDoneFiltration).Result;
                return Ok(toDoTask);
            }
            catch (Exception ex)
            {
                //TODO log exception 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetToDoTasksByTitle/{title}/{page}")]
        public IActionResult GetToDoTasksByTitle(string title, int page = 1)
        {
            try
            {
                var toDoTask = _toDoTaskService.GetToDoTasksByTitle(page, title).Result;
                return Ok(toDoTask);
            }
            catch (Exception ex)
            {
                //TODO log exception 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetToDoTasksByDescription/{description}/{page}")]
        public IActionResult GetToDoTasksByDescription(string description, int page = 1)
        {
            try
            {
                var toDoTask = _toDoTaskService.GetToDoTasksByDescription(page, description).Result;
                return Ok(toDoTask);
            }
            catch (Exception ex)
            {
                //TODO log exception 
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddToDoTask")]
        public IActionResult Post([FromBody] ToDoTask toDoTask)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var addedToDoTask = _toDoTaskService.AddToDoTask(toDoTask).Result;
                    return Ok(addedToDoTask);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                //TODO log Exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateToDoTask")]
        public IActionResult Put([FromBody] ToDoTask toDoTask)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updatedToDoTask = _toDoTaskService.UpdateToDoTask(toDoTask.ToDoTaskID, toDoTask).Result;
                    return Ok(updatedToDoTask);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                //TODO log Exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateToDoTaskIsDone/{id}/{isDone}")]
        public IActionResult Put(Guid id, bool isDone)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isUpdated = _toDoTaskService.UpdateToDoTaskIsDone(id, isDone).Result;
                    return Ok(isUpdated);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                //TODO log Exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateToDoTaskPriorityStatus/{id}/{priorityStatus}")]
        public IActionResult Put(Guid id, Priority priorityStatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isUpdated = _toDoTaskService.UpdateToDoTaskPriorityStatus(id, priorityStatus).Result;
                    return Ok(isUpdated);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                //TODO log Exception
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteToDoTasks/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                bool isDeleted = _toDoTaskService.DeleteToDoTask(id).Result;
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                //TODO log Exception
                return BadRequest(ex.Message);
            }
        }
    }
}
