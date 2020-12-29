using StackOverflowClone.ViewModels;
using System.Collections.Generic;

namespace StackOverflowClone.ServiceLayer.Interfaces
{
    public interface IQuestionsService
    {
        void InsertQuestion(NewQuestionViewModel newQuestionViewModel);
        void UpdateQuestionDetails(EditQuestionViewModel editQuestionViewModel);
        void UpdateQuestionVotesCount(int questionID, int value);
        void UpdateQuestionAnswersCount(int questionID, int value);
        void UpdateQuestionViewsCount(int questionID, int value);
        void DeleteQuestion(int questionID);
        List<QuestionViewModel> GetQuestions();
        QuestionViewModel GetQuestionByQuestionID(int questionID, int userID);

    }
}
