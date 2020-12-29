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
    public class QuestionsService : IQuestionsService
    {
        IQuestionsRepository QuestionsRepository;
        public QuestionsService()
        {
            QuestionsRepository = new QuestionsRepository();
        }
        public void InsertQuestion(NewQuestionViewModel newQuestionViewModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuestionViewModel, Question>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Question question = mapper.Map<NewQuestionViewModel, Question>(newQuestionViewModel);
            QuestionsRepository.InsertQuestion(question);

        }
        public void UpdateQuestionDetails(EditQuestionViewModel editQuestionViewModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EditQuestionViewModel, Question>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Question question = mapper.Map<EditQuestionViewModel, Question>(editQuestionViewModel);
            QuestionsRepository.UpdateQuestionDetails(question);
        }
        public void UpdateQuestionVotesCount(int questionID, int value)
        {
            QuestionsRepository.UpdateQuestionVotesCount(questionID, value);
        }
        public void UpdateQuestionAnswersCount(int questionID, int value)
        {
            QuestionsRepository.UpdateQuestionAnswersCount(questionID, value);
        }
        public void UpdateQuestionViewsCount(int questionID, int value)
        {
            QuestionsRepository.UpdateQuestionViewsCount(questionID, value);
        }
        public void DeleteQuestion(int questionID)
        {
            QuestionsRepository.DeleteQuestion(questionID);
        }
        public List<QuestionViewModel> GetQuestions()
        {
            List<Question> questions = QuestionsRepository.GetQuestions();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Question, QuestionViewModel>();
                cfg.IgnoreUnmapped();
                cfg.CreateMap<User, UserViewModel>();
                cfg.IgnoreUnmapped();
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<QuestionViewModel> questionViewModels = mapper.Map<List<Question>, List<QuestionViewModel>>(questions);
            return questionViewModels;
        }
        public QuestionViewModel GetQuestionByQuestionID(int questionID, int userID = 0)
        {
            Question question = QuestionsRepository.GetQuestionsByQuestionID(questionID).FirstOrDefault();
            QuestionViewModel questionViewModel = null;
            if (question != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Question, QuestionViewModel>();
                    cfg.IgnoreUnmapped();
                    cfg.CreateMap<User, UserViewModel>();
                    cfg.IgnoreUnmapped();
                    cfg.CreateMap<Category, CategoryViewModel>();
                    cfg.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                questionViewModel = mapper.Map<Question, QuestionViewModel>(question);
                foreach (var item in questionViewModel.Answers)
                {
                    item.CurrentUserVoteType = 0;
                    VoteViewModel voteViewModel = item.Votes.Where(temp => temp.UserID == userID).FirstOrDefault();
                    if (voteViewModel != null)
                    {
                        item.CurrentUserVoteType = voteViewModel.VoteValue;
                    }
                }
            }
            return questionViewModel;
        }

    }
}
