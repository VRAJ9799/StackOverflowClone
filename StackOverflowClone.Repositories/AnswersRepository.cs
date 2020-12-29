using StackOverflowClone.DomainModels;
using StackOverflowClone.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflowClone.Repositories
{
    public class AnswersRepository : IAnswersRepository
    {
        StackOverflowDatabaseDbContext db;
        IQuestionsRepository questionsRepository;
        IVotesRepository votesRepository;
        public AnswersRepository()
        {
            db = new StackOverflowDatabaseDbContext();
            questionsRepository = new QuestionsRepository();
            votesRepository = new VotesRepository();
        }
        public void InsertAnswer(Answer answer)
        {
            db.Answers.Add(answer);
            db.SaveChanges();
            questionsRepository.UpdateQuestionAnswersCount(answer.QuestionID, 1);
        }
        public void UpdateAnswer(Answer answer)
        {
            Answer answer1 = db.Answers.Where(temp => temp.AnswerID == answer.AnswerID).FirstOrDefault();
            if (answer1 != null)
            {
                answer1.AnswerText = answer.AnswerText;
                db.SaveChanges();
            }
        }
        public void UpdateAnswerVotesCount(int answerID, int userID, int value)
        {
            Answer answer1 = db.Answers.Where(temp => temp.AnswerID == answerID).FirstOrDefault();
            if (answer1 != null)
            {
                answer1.VotesCount += value;
                db.SaveChanges();
                questionsRepository.UpdateQuestionVotesCount(answer1.QuestionID, value);
                votesRepository.UpdateVote(answerID, userID, value);
            }
        }
        public void DeleteAnswer(int answerID)
        {
            Answer answer = db.Answers.Where(temp => temp.AnswerID == answerID).FirstOrDefault();
            if (answer != null)
            {
                db.Answers.Remove(answer);
                db.SaveChanges();
                questionsRepository.UpdateQuestionAnswersCount(answer.AnswerID, -1);
            }
        }
        public List<Answer> GetAnswersByQuestionID(int questionID)
        {
            List<Answer> answers = db.Answers.Where(temp => temp.QuestionID == questionID).OrderByDescending(temp => temp.AnswerDateAndTime).ToList();
            return answers;
        }
        public List<Answer> GetAnswerByAnswerID(int answerID)
        {
            List<Answer> answers = db.Answers.Where(temp => temp.AnswerID == answerID).ToList();
            return answers;
        }
    }
}
