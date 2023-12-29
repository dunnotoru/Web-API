using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Web_API.Domain.Entities.Joke;
using Web_API.Domain.Repositories;

namespace Web_API.Controllers
{
    [Route("api/jokes")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly IJokeRepository _jokeRepository;

        public JokesController(IJokeRepository jokeRepository)
        {
            _jokeRepository = jokeRepository;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] JokeDto jokeDto)
        {
            int id = await _jokeRepository.CreateAsync(jokeDto);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _jokeRepository.DeleteAsync(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] JokeDto jokeDto)
        {
            try
            {
                await _jokeRepository.UpdateAsync(id, jokeDto);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Joke>> GetById(int id)
        {
            try
            {
                Joke joke = await _jokeRepository.GetByIdAsync(id);
                return Ok(joke);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Joke>>> GetAll()
        {
            try
            {
                IEnumerable<Joke> jokes = await _jokeRepository.GetAll();
                return Ok(jokes);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
