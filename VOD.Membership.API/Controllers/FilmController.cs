using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VOD.common.DTOs;
using VOD.Membership.Data.Context;
using VOD.Membership.Data.Entities;
using VOD.Membership.Data.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VOD.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmController : ControllerBase
{
    private readonly IDbService _db;

    public FilmController(VOD_Service db)
    {
        _db = db;
    }

    // GET: api/<FilmController>
    [HttpGet]
    public async Task<IResult> Get() =>
        Results.Ok(await _db.GetAllAsync<Film, FilmDTO>());

    // GET api/<FilmController>/5
    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        var entity = _db.GetSingleAsync<Film>(e=> e.Id == id);
        if (entity == null) return Results.NotFound();
        else return Results.Ok(entity);
    }

    // POST api/<FilmController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] FilmDTO Dto)
    {
        try
        {
            var entity = await _db.AddAsync<Film, FilmDTO>(Dto);
            if (await _db.SaveChangesAsync())
            {
                var node = typeof(Film).Name.ToLower();
                return Results.Created($"Created post: /{node}/{entity.Id}", entity);
            }
            else return Results.BadRequest();
        }
        catch (Exception)
        {
            return Results.BadRequest();
        }
    }

    // PUT api/<FilmController>/5
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] FilmDTO Dto)
    {
        try
        {
            if (!await _db.AnyAsync<Film>(e => e.Id == id)) { return Results.NotFound(); }

            _db.Update<FilmDTO, Film>(id, Dto);
            if (await _db.SaveChangesAsync()) { return Results.NoContent(); }
        }
        catch (Exception)
        {
            return Results.BadRequest();
        }
        return Results.BadRequest();
    }

    // DELETE api/<FilmController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        try
        {
            if (!await _db.DeleteAsync<Film>(id)) return Results.NotFound();
            if (await _db.SaveChangesAsync()) return Results.NoContent();
        }
        catch (Exception)
        {
            return Results.BadRequest();
        }
        return Results.BadRequest();
    }
}
