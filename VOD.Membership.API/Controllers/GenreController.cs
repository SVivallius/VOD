using Microsoft.AspNetCore.Mvc;
using VOD.common.DTOs;
using VOD.Membership.Data.Entities;
using VOD.Membership.Data.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VOD.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IDbService _db;

        public GenreController(IDbService db)
        {
            _db = db;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public async Task<IResult> Get() =>
            Results.Ok(await _db.GetAllAsync<Genre, GenreDTO>());

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            var entity = await _db.GetSingleAsync<Genre>(e => e.Id == id);
            if (entity == null) { return Results.NotFound(); }
            return Results.Ok(entity);
        }

        // POST api/<GenreController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] GenreDTO Dto)
        {
            try
            {
                var entity = await _db.AddAsync<Genre, GenreDTO>(Dto);
                if (await _db.SaveChangesAsync())
                {
                    var node = typeof(Genre).Name.ToLower();
                    return Results.Created($"Created post: \\{node}\\{entity.Id}", entity);
                }
            }
            catch (Exception)
            {
                return Results.BadRequest();
            }
            return Results.BadRequest();
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] GenreDTO Dto)
        {
            try
            {
                if (!await _db.AnyAsync<Genre>(e => e.Id == id)) { return Results.NotFound(); }

                _db.Update<GenreDTO, Genre>(id, Dto);
                if (await _db.SaveChangesAsync()) { return Results.NoContent(); }
            }
            catch (Exception)
            {
                return Results.BadRequest();
            }
            return Results.BadRequest();
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                if (!await _db.DeleteAsync<Genre>(id)) { return Results.NotFound(); }
                if (await _db.SaveChangesAsync()) { return Results.NoContent(); }
            }
            catch (Exception)
            {
                return Results.BadRequest();
            }
            return Results.BadRequest();
        }
    }
}
