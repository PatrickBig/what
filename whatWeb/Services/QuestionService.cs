using Microsoft.EntityFrameworkCore;
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


        public async Task<IList<QuestionPreview>> GetFrontPageAsync(int limit, int skip)
        {
            var result = await _questions.Find(_ => true)
                .Project(x => new QuestionPreview
                {
                    Id = x.Id,
                    Answers = x.Answers == null ? 0 : x.Answers.Count,
                    Views = x.Views == null ? 0 : x.Views.Count,
                    Votes = x.Votes == null ? 0 : x.Votes.Count(v => v.VoteType == VoteType.Up) - x.Votes.Count(v => v.VoteType == VoteType.Down),
                    Title = x.Title,
                    PostDate = x.PostDate,
                    UserId = x.PostUserId,
                })
                .Skip(skip).Limit(limit).ToListAsync();

            return result;
        }
    }
}
