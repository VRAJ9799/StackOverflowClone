using StackOverflowClone.ViewModels;
using System.Collections.Generic;
namespace StackOverflowClone.ServiceLayer.Interfaces
{
    public interface IAnswersService
    {
        void InsertAnswer(NewAnswerViewModel newAnswerViewModel);
        void UpdateAnswer(EditAnswerViewModel editAnswerViewModel);
        void UpdateAnswerVotesCount(int answerID, int userID, int value);
        void DeleteAnswer(int answerID);
        List<AnswerViewModel> GetAnswersByQuestionID(int questionID);
        AnswerViewModel GetAnswerByAnswerID(int answerID);
    }
}
