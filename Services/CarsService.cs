using System;
using System.Collections.Generic;
using gregslist.Models;
using gregslist.Repositories;

namespace gregslist.Services
{

  public class CarsService
  {
    private readonly CarsRepository _repo;

    public CarsService(CarsRepository repo)
    {
      _repo = repo;
    }
    internal List<Car> Get()
    {
      return _repo.Get();
    }

    internal Car Get(int id)
    {
      Car found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Car Create(Car carData)
    {
      return _repo.Create(carData);
    }

    internal Car Update(Car carData)
    {
      Car original = Get(carData.Id);
      original.Make = carData.Make ?? original.Make;
      original.Model = carData.Model ?? original.Model;
      original.Year = carData.Year ?? original.Year;
      original.Description = carData.Description ?? original.Description;
      original.Price = carData.Price;
      _repo.Update(original);
      return original;
    }

    internal void Delete(int id)
    {
      Get(id);
      _repo.Delete(id);
    }
  }
}