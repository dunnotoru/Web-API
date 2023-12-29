using Microsoft.EntityFrameworkCore;
using Web_API.Database.Contexts;
using Web_API.Domain.Entities.Joke;
using Web_API.Domain.Repositories;

namespace Web_API.Database.Repositories
{
    public class JokeRepository : IJokeRepository
    {
        private ApplicationContext _context;

        public JokeRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task<int> CreateAsync(JokeDto dto)
        {
            Joke create = new Joke()
            {
                Header = dto.Header,
                Body = dto.Body,
            };

            await _context.Jokes.AddAsync(create);
            await _context.SaveChangesAsync();

            return create.Id;
        }

        public async Task DeleteAsync(int id)
        {
            Joke stored = await _context.Jokes.FirstAsync(j => j.Id == id);
            _context.Jokes.Remove(stored);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Joke>> GetAll()
        {
            return await _context.Jokes.ToListAsync();
        }

        public async Task<IEnumerable<Joke>> GetByBodyAsync(string substring)
        {
            return await _context.Jokes.Where(o => o.Body.Contains(substring)).ToListAsync();
        }

        public async Task<IEnumerable<Joke>> GetByHeaderAsync(string substring)
        {
            return await _context.Jokes.Where(o => o.Header.Contains(substring)).ToListAsync();
        }

        public async Task<Joke> GetByIdAsync(int id)
        {
            return await _context.Jokes.FirstAsync(o => o.Id == id);
        }

        public async Task UpdateAsync(int id, JokeDto dto)
        {
            Joke stored = await _context.Jokes.FirstAsync(j => j.Id == id);
            
            stored.Header = dto.Header;
            stored.Body = dto.Body;

            await _context.SaveChangesAsync();
        }
    }
}
