using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gregglistsql.Services;
using Microsoft.AspNetCore.Mvc;
using gregglistsql.Models;
namespace gregglistsql.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {
    private readonly JobsService _js;

    public JobsController(JobsService js)
    {
      _js = js;
    }

    [HttpGet]
    public ActionResult<List<Job>> Get()
    {
      try
      {
        List<Job> jobs = _js.Get();
        return Ok(jobs);

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Job> GetById(int id)
    {
      try
      {
        Job job = _js.GetById(id);
        return Ok(job);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job newJob)
    {
      try
      {
        Job job = _js.Create(newJob);
        return Ok(job);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Job> Edit([FromBody] Job updates, int id)
    {
      try
      {
        Job JobtoDelete = _js.Edit(updates);
        return Ok(JobtoDelete);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<string> Remove(int id)
    {
      try
      {
        _js.Remove(id);
        return Ok("deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}