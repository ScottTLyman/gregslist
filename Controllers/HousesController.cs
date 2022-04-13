using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslist.Models;
using gregslist.Services;

namespace gregslist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{
  private readonly HousesService _hs;

  public HousesController(HousesService hs)
  {
    _hs = hs;
  }
  [HttpGet]
  public ActionResult<List<House>> Get()
  {
    try
    {
      List<House> houses = _hs.Get();
      return Ok(houses);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<House> Get(int id)
  {
    try
    {
      House house = _hs.Get(id);
      return Ok(house);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPost]
  public ActionResult<House> Create([FromBody] House houseData)
  {
    try
    {
      House house = _hs.Create(houseData);
      return Created($"api/houses/{house.Id}", house);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public ActionResult<House> Update(int id, [FromBody] House updates)
  {
    try
    {
      updates.Id = id;
      House updated = _hs.Update(updates);
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
      _hs.Delete(id);
      return Ok("Removed");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}