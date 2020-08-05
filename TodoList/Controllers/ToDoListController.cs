using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.DomainService;

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
    }
}
