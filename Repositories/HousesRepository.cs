using System.Collections.Generic;
using System.Data;
using System.Linq;
using gregslist.Models;
using Dapper;
using System;

namespace gregslist.Repositories
{
  public class HousesRepository
  {
    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<House> Get()
    {
      string sql = "SELECT * FROM houses;";
      return _db.Query<House>(sql).ToList();
    }
    internal House Get(int id)
    {
      string sql = "SELECT * FROM  houses WHERE id = @id;";
      return _db.QueryFirstOrDefault<House>(sql, new { id });
    }
    internal House Create(House houseData)
    {
      string sql = @"
      INSERT INTO houses
      (bedrooms, bathrooms, year, description, price)
      VALUES
      (@Bedrooms, @Bathrooms, @Year, @Description, @Price);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, houseData);
      houseData.Id = id;
      return houseData;
    }
    internal void Update(House original)
    {
      string sql = @"
      UPDATE houses
      SET
      bedrooms=@Bedrooms,
      bathrooms=@Bathrooms,
      year=@Year,
      description=@Description,
      price=@Price
      WHERE id = @Id;";
      _db.Execute(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM houses WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}