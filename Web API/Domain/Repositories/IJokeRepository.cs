using Web_API.Domain.Entities.Joke;

namespace Web_API.Domain.Repositories
{
    public interface IJokeRepository
    {
        Task<int> CreateAsync(JokeDto dto);
        Task UpdateAsync(int id, JokeDto dto);
        Task DeleteAsync(int id);
        Task<Joke> GetByIdAsync(int id);
        Task<IEnumerable<Joke>> GetByHeaderAsync(string headerPart);
        Task<IEnumerable<Joke>> GetByBodyAsync(string bodyPart);
        Task<IEnumerable<Joke>> GetAll();
    }
}
