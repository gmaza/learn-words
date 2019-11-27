using LearnWords.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnWords.Infrastructure.Quiz
{
    public class QuizRepository : IQuizRepository
    {
        protected IMongoCollection<QuizItem> _collection;

        public QuizRepository(IMongoClient dbClient, string dbName, string collectionName)
        {
            var db = dbClient.GetDatabase(dbName);
            _collection = db.GetCollection<QuizItem>(collectionName);
        }

        public async Task<ICollection<QuizItem>> GetAllAsync() => await _collection.Find(Builders<QuizItem>.Filter.Empty).ToListAsync();

        public async Task<Result> InsertAsync(QuizItem entity)
        {
            return await _collection.InsertOneAsync(entity).ContinueWith(t =>
            new Result(true, 0, entity.ID));
        }

        public async Task<QuizItem> GetAsync(string id) => await _collection.FindAsync(b => b.ID == id).ContinueWith(c => c.Result.First());

        public QuizItem Get(string id) => _collection.Find(b => b.ID == id).Single();

        public Task<Result> RemoveAsync(string id) => _collection.DeleteOneAsync(c => c.ID == id).ContinueWith(r => new Result(true, 0, "ok"));

        public Task<Result> UpdateAsync(string id, QuizItem value)
        {
            value.ID = id;
            return _collection.FindOneAndReplaceAsync(c => c.ID == id,value)
                .ContinueWith(r => new Result(true, 0, "ok"));
        }
    }
}
