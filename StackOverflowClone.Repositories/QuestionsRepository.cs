using StackOverflowClone.DomainModels;
using StackOverflowClone.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflowClone.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        StackOverflowDatabaseDbContext db;
        public QuestionsRepository()
        {
            db = new StackOverflowDatabaseDbContext();
        }
        public void InsertQuestion(Question question)
        {
            db.Questions.Add(question);
            db.SaveChanges();
        }
        public void UpdateQuestionDetails(Question question)
        {
            Question question1 = db.Questions.Where(temp => temp.QuestionID == question.QuestionID).FirstOrDefault();
            if (question1 != null)
            {
                question1.QuestionName = question.QuestionName;
                question1.QuestionDateAndTime = question.QuestionDateAndTime;
                question1.CategoryID = question.CategoryID;
                db.SaveChanges();
            }
        }
        public void UpdateQuestionVotesCount(int questionID, int value)
        {
            Question question1 = db.Questions.Where(temp => temp.QuestionID == questionID).FirstOrDefault();
            if (question1 != null)
            {
                question1.VotesCount += value;
                db.SaveChanges();
            }
        }
        public void UpdateQuestionAnswersCount(int questionID, int value)
        {
            Question question1 = db.Questions.Where(temp => temp.QuestionID == questionID).FirstOrDefault();
            if (question1 != null)
            {
                question1.AnswersCount += value;
                db.SaveChanges();
            }
        }
        public void UpdateQuestionViewsCount(int questionID, int value)
        {
            Question question1 = db.Questions.Where(temp => temp.QuestionID == questionID).FirstOrDefault();
            if (question1 != null)
            {
                question1.ViewsCount += value;
                db.SaveChanges();
            }
        }
        public void DeleteQuestion(int questionID)
        {
            Question question1 = db.Questions.Where(temp => temp.QuestionID == questionID).FirstOrDefault();
            if (question1 != null)
            {
                db.Questions.Remove(question1);
                db.SaveChanges();
            }
        }

        public List<Question> GetQuestions()
        {
            List<Question> questions = db.Questions.OrderByDescending(temp => temp.QuestionDateAndTime).ToList();
            return questions;
        }
        public List<Question> GetQuestionsByQuestionID(int questionID)
        {
            List<Question> questions = db.Questions.Where(temp => temp.QuestionID == questionID).ToList();
            return questions;
        }
    }
}
