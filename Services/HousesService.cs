using System;
using System.Collections.Generic;
using gregslist.Models;
using gregslist.Repositories;

namespace gregslist.Services
{

  public class HousesService
  {
    private readonly HousesRepository _repo;

    public HousesService(HousesRepository repo)
    {
      _repo = repo;
    }
    internal List<House> Get()
    {
      return _repo.Get();
    }

    internal House Get(int id)
    {
      House found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal House Create(House houseData)
    {
      return _repo.Create(houseData);
    }

    internal House Update(House houseData)
    {
      House original = Get(houseData.Id);
      original.Bedrooms = houseData.Bedrooms ?? original.Bedrooms;
      original.Bathrooms = houseData.Bathrooms ?? original.Bathrooms;
      original.Year = houseData.Year ?? original.Year;
      original.Description = houseData.Description ?? original.Description;
      original.Price = houseData.Price ?? original.Price;
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