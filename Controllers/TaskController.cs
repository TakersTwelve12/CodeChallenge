
using DotnetAPI.Data;
using DotnetAPI.Dtos;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    DataContextDapper _dapper;
    public TaskController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }
    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }

    [HttpGet("GetTasks")]
    public IEnumerable<HMCTSTask> GetTasks()
    {
        string sql = @"
            SELECT [TaskId],
                [Title],
                [Description],
                [Status],
                [DueDateTime]
            FROM dbo.Tasks
        ";
        IEnumerable<HMCTSTask> tasks =_dapper.LoadData<HMCTSTask>(sql);
        Console.WriteLine(sql);
        return tasks;
    }

    [HttpGet("GetSingleTask/{taskId}")]
    public HMCTSTask GetSingleTask(int taskId)
    {
        string sql = @"
            SELECT [TaskId],
                [Title],
                [Description],
                [Status],
                [DueDateTime]
            FROM dbo.Tasks
            WHERE TaskId = " + taskId.ToString();
        HMCTSTask task = _dapper.LoadDataSingle<HMCTSTask>(sql);
        return task;
    }

        [HttpPut("EditTask")]
        public IActionResult EditStatusTask(EditStatusTaskDto task)
        {
            string sql = @"
            UPDATE dbo.Tasks
                SET [Status] = '" + task.Status + 
                "' WHERE TaskId = " + task.TaskId;

            Console.WriteLine(sql);

            if (_dapper.ExecuteSql(sql))
            {   
                return Ok();
            }

            throw new Exception("Failed to Update Task");
        }

        [HttpPost("AddTask")]
        public IActionResult AddTask(TaskToAddDto task)
        {
            string sql = @"
            INSERT dbo.Tasks(
                [Title],
                [Description],
                [Status],
                [DueDateTime]
                ) VALUES (" +
                "'" + task.Title +
                "', '" + task.Description +
                "', '" + task.Status +
                "', '" + task.DueDateTime +
                "')";

            Console.WriteLine(sql);

            if (_dapper.ExecuteSql(sql))
            {   
                return Ok();
            }

            throw new Exception("Failed to Add Task");
        
        }

        [HttpDelete("DeleteTask/{taskId}")]
            public IActionResult DeleteTask(int taskId)
        {
            string sql = @"
                DELETE 
                FROM dbo.Tasks
                WHERE TaskId = " + taskId.ToString();

                Console.WriteLine(sql);

            if (_dapper.ExecuteSql(sql))
            {   
                return Ok();
            }

            throw new Exception("Failed to Delete Task");
        }

}