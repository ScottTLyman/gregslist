using System.Collections.Generic;
using System.Data;
using System.Linq;
using gregslist.Models;
using Dapper;
using System;

namespace gregslist.Repositories
{
  public class CarsRepository
  {
    private readonly IDbConnection _db;

    public CarsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Car> Get()
    {
      string sql = "SELECT * FROM cars;";
      return _db.Query<Car>(sql).ToList();
    }
    internal Car Get(int id)
    {
      string sql = "SELECT * FROM  cars WHERE id = @id;";
      return _db.QueryFirstOrDefault<Car>(sql, new { id });
    }
    internal Car Create(Car carData)
    {
      string sql = @"
      INSERT INTO cars
      (make, model, year, description, price)
      VALUES
      (@Make, @Model, @Year, @Description, @Price);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, carData);
      carData.Id = id;
      return carData;
    }
    internal void Update(Car original)
    {
      string sql = @"
      UPDATE cars
      SET
      make = @Make,
      model = @Model,
      year = @Year,
      description = @Description,
      price = @Price
      WHERE id = @Id;";
      _db.Execute(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM cars WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}