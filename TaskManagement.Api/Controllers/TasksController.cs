using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using TaskManagement.Api.Data;
using TaskManagement.Api.Dto;
using TaskManagement.Api.Models;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class TasksController : Controller
    {
        public readonly ApiResponse _response;
        public readonly AppDBContext _db;
        public TasksController(AppDBContext db)
        {
            _db = db;
            _response = new ApiResponse();
        }
        private string CurrentUserId =>
           User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            _response.Status = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = await _db.TaskItem.Where(u=>u.UserId==CurrentUserId).ToListAsync();
            return Ok(_response);
        }
        [HttpGet("{id:int}", Name = "GetTask")]
        public IActionResult GetTaskById(int id)
        {
            if (id <= 0)
            {
                _response.Status=HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.Errors.Add("invalid id");
                return BadRequest(_response);
            }
            TaskItem taskitem = _db.TaskItem.FirstOrDefault(u => u.Id ==id&&u.UserId==CurrentUserId);
            if (taskitem == null)
            {
                _response.Status = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.Errors.Add("Task Is Not Found");
                return NotFound(_response);
            }
            _response.Status = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = taskitem;
            return Ok(_response);

        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreatTask([FromForm] CreatTaskDto creatTaskDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TaskItem taskitem = new()
                    {
                        Title = creatTaskDto.Title,
                        Description = creatTaskDto.Description,
                        Status = creatTaskDto.Status,
                        UserId = CurrentUserId
                    };
                    _db.TaskItem.Add(taskitem);
                    await _db.SaveChangesAsync();
                    _response.Status = HttpStatusCode.Created;
                    _response.IsSuccess = true;
                    _response.Result = taskitem;
                    return CreatedAtAction(nameof(GetTaskById), new { id = taskitem.Id }, _response);
                }
                else
                {
                    _response.IsSuccess = false;
                }
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = [ex.Message];
            }
            return BadRequest(_response);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse>> UpdateTask( int id,[FromForm] UpdateTaskDto updateTaskDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TaskItem taskItemfromdb = await _db.TaskItem.FirstOrDefaultAsync(u => u.Id==id&&u.UserId==CurrentUserId);
                    if (taskItemfromdb == null)
                    {
                        _response.Status = HttpStatusCode.NotFound;
                        _response.IsSuccess = false;
                        _response.Errors.Add("Task Not Found");
                        return NotFound(_response);
                    }

                    taskItemfromdb.Title = updateTaskDto.Title;
                    taskItemfromdb.Description = updateTaskDto.Description;
                    taskItemfromdb.Status = updateTaskDto.Status;
                   
                    
                    _db.TaskItem.Update(taskItemfromdb);
                    await _db.SaveChangesAsync();
                    _response.Status = HttpStatusCode.NoContent;
                    return Ok(_response);
                    
                }
                else
                {
                    _response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = [ex.Message];
            }
            return BadRequest(_response);
        }
        [HttpDelete("{id:int}", Name = "DeletTask")]
        public async Task<ActionResult<ApiResponse>> DeletTaskById(int id)
        {
            if (id <= 0)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.Errors.Add("invalid id");
                return BadRequest(_response);
            }
            TaskItem taskitem = await _db.TaskItem.FirstOrDefaultAsync(u => u.Id == id&& u.UserId == CurrentUserId);
            if (taskitem == null)
            {
                _response.Status = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.Errors.Add("Task Is Not Found");
                return NotFound(_response);
            }
            _db.TaskItem.Remove(taskitem);
           await _db.SaveChangesAsync();

            return Ok(_response);

        }
    }

        }

