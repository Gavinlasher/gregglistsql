using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gregglistsql.Models;

namespace gregglistsql.Services
{
  public class JobsService
  {

    private readonly JobsService _repo;

    public JobsService(JobsService repo)
    {
      _repo = repo;
    }

    internal List<Job> Get()
    {
      return _repo.Get();
    }

    internal Job GetById(int id)
    {
      Job found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("invaild Id");
      }
      return found;
    }

    internal Job Create(Job newJob)
    {
      return _repo.Create(newJob);
    }

    internal Job Edit(Job updates)
    {
      Job og = GetById(updates.Id);
      og.Title = updates.Title ?? og.Title;
      og.Wage = updates.Wage;
      _repo.Edit(og);
      return og;
    }

    internal void Remove(int id)
    {
      GetById(id);
      _repo.Remove(id);
    }
  }
}