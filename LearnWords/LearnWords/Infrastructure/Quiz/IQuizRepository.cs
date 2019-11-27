using LearnWords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnWords.Infrastructure.Quiz
{
    public interface IQuizRepository
    {
        Task<ICollection<QuizItem>> GetAllAsync();

        Task<Result> InsertAsync(QuizItem entity);

        Task<QuizItem> GetAsync(string id);

        QuizItem Get(string id);

        Task<Result> RemoveAsync(string id);

        Task<Result> UpdateAsync(string id, QuizItem value);
    }
}
