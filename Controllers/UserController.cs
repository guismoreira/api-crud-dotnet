using apiCrud.Entities;
using apiCrud.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace apiCrud.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UserController(UserDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var user = _context.Users.Where(d => !d.isDeleted).ToList();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _context.Users.SingleOrDefault(d => d.Id == id);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(User user)
        {
            _context.Users.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("id")]
        public IActionResult Update(Guid id, User userToUpdate)
        {
            var user = _context.Users.SingleOrDefault(d => d.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            user.Update(userToUpdate);

            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult Delete(Guid id)
        {
            var user = _context.Users.SingleOrDefault(d => d.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            user.Delete();

            return NoContent();
        }
    }
}
