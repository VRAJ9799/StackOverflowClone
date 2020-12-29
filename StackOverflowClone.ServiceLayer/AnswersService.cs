using AutoMapper;
using StackOverflowClone.DomainModels;
using StackOverflowClone.Repositories;
using StackOverflowClone.Repositories.Interfaces;
using StackOverflowClone.ServiceLayer.Interfaces;
using StackOverflowClone.ViewModels;
using System.Collections.Generic;
using System.Linq;
namespace StackOverflowClone.ServiceLayer
{
    public class AnswersService : IAnswersService
    {
        IAnswersRepository AnswersRepository;
        public AnswersService()
        {
            AnswersRepository = new AnswersRepository();
        }
        public void InsertAnswer(NewAnswerViewModel newAnswerViewModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewAnswerViewModel, Answer>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Answer answer = mapper.Map<NewAnswerViewModel, Answer>(newAnswerViewModel);
            AnswersRepository.InsertAnswer(answer);
        }
        public void UpdateAnswer(EditAnswerViewModel editAnswerViewModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EditAnswerViewModel, Answer>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Answer answer = mapper.Map<EditAnswerViewModel, Answer>(editAnswerViewModel);
            AnswersRepository.UpdateAnswer(answer);
        }
        public void UpdateAnswerVotesCount(int answerID, int userID, int value)
        {
            AnswersRepository.UpdateAnswerVotesCount(answerID, userID, value);
        }
        public void DeleteAnswer(int answerID)
        {
            AnswersRepository.DeleteAnswer(answerID);
        }
        public List<AnswerViewModel> GetAnswersByQuestionID(int questionID)
        {
            List<Answer> answers = AnswersRepository.GetAnswersByQuestionID(questionID);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Answer, AnswerViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<AnswerViewModel> answerViewModels = mapper.Map<List<Answer>, List<AnswerViewModel>>(answers);
            return answerViewModels;
        }
        public AnswerViewModel GetAnswerByAnswerID(int answerID)
        {
            Answer answer = AnswersRepository.GetAnswerByAnswerID(answerID).FirstOrDefault();
            AnswerViewModel answerViewModel = null;
            if (answer != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Answer, AnswerViewModel>();
                    cfg.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                answerViewModel = mapper.Map<Answer, AnswerViewModel>(answer);
            }
            return answerViewModel;
        }
    }
}
