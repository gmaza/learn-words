using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnWords.Infrastructure.Quiz
{
    public class QuizItem
    {
        public QuizItem()
        {
            ID = ObjectId.GenerateNewId().ToString();
            CreateDate = DateTime.Now;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        public string Word { get; set; }

        public string Meaning { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; }
    }
}
