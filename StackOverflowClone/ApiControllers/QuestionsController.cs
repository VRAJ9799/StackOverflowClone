using StackOverflowClone.ServiceLayer.Interfaces;
using System.Web.Http;

namespace StackOverflowClone.ApiControllers
{
    public class QuestionsController : ApiController
    {
        IAnswersService AnswersService;
        public QuestionsController(IAnswersService answersService)
        {
            this.AnswersService = answersService;
        }
        public void Post(int answerID, int userID, int value)
        {
            this.AnswersService.UpdateAnswerVotesCount(answerID, userID, value);
        }
    }
}
