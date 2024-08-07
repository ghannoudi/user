using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back.Models;

namespace back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _userContext;
        public UsersController(UserContext userContext)
        {
            _userContext = userContext;
        }

        // Get : api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_userContext.Users == null)
            {
                return NotFound();
            }
            return await _userContext.Users.ToListAsync();
        }

        // Get : api/Users/2
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetMovie(int id)
        {
            if (_userContext.Users is null)
            {
                return NotFound();
            }
            var movie = await _userContext.Users.FindAsync(id);
            if (movie is null)
            {
                return NotFound();
            }
            return movie;
        }

        // Post : api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostMovie(User user)
        {
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }

        // Put : api/Users/2
        [HttpPut]
        public async Task<ActionResult<User>> PutMovie(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            _userContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _userContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id)) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }

        private bool MovieExists(long id)
        {
            return (_userContext.Users?.Any(movie => movie.Id == id)).GetValueOrDefault();
        }

        // Delete : api/Users/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteMovie(int id)
        {
            if (_userContext.Users is null)
            {
                return NotFound();
            }
            var movie = await _userContext.Users.FindAsync(id);
            if (movie is null)
            {
                return NotFound();
            }
            _userContext.Users.Remove(movie);
            await _userContext.SaveChangesAsync();
            return NoContent();
        }


    }
}