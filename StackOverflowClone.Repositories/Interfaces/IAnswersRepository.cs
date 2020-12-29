using StackOverflowClone.DomainModels;
using System.Collections.Generic;
namespace StackOverflowClone.Repositories.Interfaces
{
    public interface IAnswersRepository
    {
        void InsertAnswer(Answer answer);
        void UpdateAnswer(Answer answer);
        void UpdateAnswerVotesCount(int answerID, int userID, int value);
        void DeleteAnswer(int answerID);
        List<Answer> GetAnswersByQuestionID(int questionID);
        List<Answer> GetAnswerByAnswerID(int answerID);
    }
}
