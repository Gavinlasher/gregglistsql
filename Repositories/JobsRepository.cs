using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using gregglistsql.Models;
using Dapper;

namespace gregglistsql.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<Job> Get()
    {
      string sql = "SELECT * FROM Jobs;";
      return _db.Query<Job>(sql).ToList();
    }
    internal Job Create(Job newJob)
    {
      string sql = @"
    INSERT INTO Jobs
    (title,wage)
    VALUES
   (@Title,@Wage)
   SELECT LAST_INSERT_ID();
    ";
      int id = _db.ExecuteScalar<int>(sql, newJob);
      newJob.Id = id;
      return newJob;
    }

  }
}