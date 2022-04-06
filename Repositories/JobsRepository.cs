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
   (@Title,@Wage);
   SELECT LAST_INSERT_ID();
    ";
      int id = _db.ExecuteScalar<int>(sql, newJob);
      newJob.Id = id;
      return newJob;
    }

    internal void Edit(Job og)
    {
      string sql = @"
      UPDATE Jobs
      SET
       title = @Title,
       wage = @wage
      WHERE id = @Id;";
      _db.Execute(sql, og);
    }
    internal Job GetById(int id)
    {
      string sql = "SELECT * FROM Jobs WHERE id = @id;";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }

    internal void Remove(int id)
    {
      string sql = "DELETE FROM Jobs WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}