using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using whatModel.Models;
using whatWeb.Models;

namespace whatWeb.Services
{
    public class QuestionService
    {
        private readonly IMongoCollection<Question> _questions;
        private const string collectionName = "Questions";

        public QuestionService(IwhatDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _questions = database.GetCollection<Question>(collectionName);
        }

        private Question BuildQuestion(string title, string content, string userId, List<whatModel.Models.Tag> tags)
        {
            var newQuestion = new Question()
            {
                Title = title,
                Content = content,
                PostUserId = userId,
                PostDate = DateTime.Now,
                Tags = tags,
                // Add a view
                Views = new List<QuestionView>
                {
                    new QuestionView
                    {
                        UserId = userId,
                        ViewDate = DateTime.Now
                    }
                },
                // Add a vote
                Votes = new List<Vote>
                {
                    new Vote
                    {
                        UserId = userId,
                        VoteDate = DateTime.Now,
                        VoteType = VoteType.Up
                    }
                }

            };

            return newQuestion;
        }

        public Question Get(string questionId)
        {
            return _questions.Find(q => q.Id == questionId).FirstOrDefault();
        }

        public async Task<Question> GetAsync(string questionId)
        {
            return await _questions.Find(q => q.Id == questionId).FirstOrDefaultAsync();
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


        //public async Task<ICollection<QuestionPreview>> GetFrontPageAsync(int limit)
        //{
        //    var filter = new FilterDefinitionBuilder<Question>();
        //    filter.Where(q => q.Views.Count > 1);
        //    //var questions = await _questions.Find()
        //}
    }
}
