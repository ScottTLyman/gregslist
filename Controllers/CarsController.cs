using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslist.Models;
using gregslist.Services;

namespace gregslist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
  private readonly CarsService _cs;

  public CarsController(CarsService cs)
  {
    _cs = cs;
  }
  [HttpGet]
  public ActionResult<List<Car>> Get()
  {
    try
    {
      List<Car> cars = _cs.Get();
      return Ok(cars);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<Car> Get(int id)
  {
    try
    {
      Car car = _cs.Get(id);
      return Created($"api/cars/{car.Id}", car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPost]
  public ActionResult<Car> Create([FromBody] Car newCar)
  {
    try
    {
      Car car = _cs.Create(newCar);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public ActionResult<Car> Update(int id, [FromBody] Car updates)
  {
    try
    {
      updates.Id = id;
      Car updated = _cs.Update(updates);
      return Ok(updated);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public ActionResult<String> Delete(int id)
  {
    try
    {
      _cs.Delete(id);
      return Ok("Removed");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}