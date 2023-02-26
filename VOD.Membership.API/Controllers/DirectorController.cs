using Microsoft.AspNetCore.Mvc;
using VOD.common.DTOs;
using VOD.Membership.Data.Entities;
using VOD.Membership.Data.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VOD.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Director_Controller : ControllerBase
    {
        private readonly IDbService _db;

        public Director_Controller(VOD_Service db)
        {
            _db = db;
        }

        // GET: api/<Director_Controller>
        [HttpGet]
        public async Task<IResult> Get() =>
            Results.Ok(await _db.GetAllAsync<Director, DirectorDTO>());

        // GET api/<Director_Controller>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            var result = await _db.GetSingleAsync<Director>(e => e.Id == id);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }

        // POST api/<Director_Controller>
        [HttpPost]
        public async Task<IResult> Post([FromBody] DirectorDTO dto)
        {
            try
            {
                var entity = await _db.AddAsync<Director, DirectorDTO>(dto);
                if (await _db.SaveChangesAsync())
                {
                    var node = typeof(Director).Name.ToLower();
                    return Results.Created($"Created post: /{node}/{entity.Id}", entity);
                }
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Could not post entity: {typeof(Director).Name}");
            }
            return Results.BadRequest();
        }

        // PUT api/<Director_Controller>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] DirectorDTO Dto)
        {
            try
            {
                if (!await _db.AnyAsync<Director>(e => e.Id == id)) { return Results.NotFound(); }

                _db.Update<DirectorDTO, Director>(id, Dto);
                if(await _db.SaveChangesAsync()) return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Failed to update: {typeof(Director).Name}\n{ex.Message}");
            }
            return Results.BadRequest();
        }

        // DELETE api/<Director_Controller>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                if (!await _db.DeleteAsync<Director>(id)) { return Results.NotFound(); }
                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }
            catch (Exception)
            {
                return Results.BadRequest();
            }
            return Results.BadRequest();
        }
    }
}
