using LearnWords.Infrastructure.Quiz;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearnWords.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository quizRepository;

        public QuizController(IQuizRepository quizRepository)
        {
            this.quizRepository = quizRepository;
        }

        // GET: api/Quiz
        [HttpGet]
        public async Task<IEnumerable<QuizItem>> Get()
        {
            return await quizRepository.GetAllAsync();
        }

        // GET: api/Quiz/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<QuizItem> Get(string id)
        {
            return await quizRepository.GetAsync(id);
        }

        // POST: api/Quiz
        [HttpPost]
        public async Task Post([FromBody] QuizItem value)
        {
            await quizRepository.InsertAsync(value);
        }

        // PUT: api/Quiz/5
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] QuizItem value)
        {
            await quizRepository.UpdateAsync(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await quizRepository.RemoveAsync(id);
        }
    }
}
