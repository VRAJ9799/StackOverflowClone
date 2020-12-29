using StackOverflowClone.DomainModels;
using System.Collections.Generic;

namespace StackOverflowClone.Repositories.Interfaces
{
    public interface IQuestionsRepository
    {
        void InsertQuestion(Question question);
        void UpdateQuestionDetails(Question question);
        void UpdateQuestionVotesCount(int questionID, int value);
        void UpdateQuestionAnswersCount(int questionID, int value);
        void UpdateQuestionViewsCount(int questionID, int value);
        void DeleteQuestion(int questionID);
        List<Question> GetQuestions();
        List<Question> GetQuestionsByQuestionID(int questionID);

    }
}
