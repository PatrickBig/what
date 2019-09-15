using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using whatModel.Models;

namespace whatWeb.Services
{
    public class QuestionService
    {
        private readonly IMongoCollection<Question> _questions;


        private Question BuildQuestion(string title, string content, string userId, List<whatModel.Models.Tag> tags)
        {
            var newQuestion = new Question()
            {
                Title = title,
                Content = content,
                PostUserId = userId,
                PostDate = DateTime.Now,
                Tags = tags
            };

            return newQuestion;
        }

        public Question Ask(string title, string content, string userId, List<whatModel.Models.Tag> tags)
        {
            var q = BuildQuestion(title, content, userId, tags);

            _questions.InsertOne(q);

            return q;
        }

        public async Task<Question> AskAsync(string title, string content, string userId, List<whatModel.Models.Tag> tags)
        {
            var q = BuildQuestion(title, content, userId, tags);

            await _questions.InsertOneAsync(q);

            return q;
        }
    }
}
