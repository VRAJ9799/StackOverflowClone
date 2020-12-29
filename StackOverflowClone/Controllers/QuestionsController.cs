using StackOverflowClone.CustomsFilter;
using StackOverflowClone.ServiceLayer.Interfaces;
using StackOverflowClone.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StackOverflowClone.Controllers
{
    public class QuestionsController : Controller
    {
        IQuestionsService QuestionsService;
        IAnswersService AnswersService;
        ICategoriesService CategoriesService;
        public QuestionsController(IQuestionsService questionsService, IAnswersService answersService, ICategoriesService categoriesService)
        {
            this.QuestionsService = questionsService;
            this.AnswersService = answersService;
            this.CategoriesService = categoriesService;

        }
        // GET: Questions
        public ActionResult View(int? id)
        {

            if (id != null)
            {
                this.QuestionsService.UpdateQuestionViewsCount(Convert.ToInt32(id), 1);
                int userID = Convert.ToInt32(Session["CurrentUserID"]);
                QuestionViewModel questionViewModel = this.QuestionsService.GetQuestionByQuestionID(Convert.ToInt32(id), userID);
                return View(questionViewModel);
            }
            else
            {
                return RedirectToAction("Questions", "Home");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilterAttribute]

        public ActionResult AddAnswer(NewAnswerViewModel newAnswerViewModel)
        {
            newAnswerViewModel.UserID = Convert.ToInt32(Session["CurrentUserID"]);
            newAnswerViewModel.AnswerDateAndTime = DateTime.Now;
            newAnswerViewModel.VotesCount = 0;
            if (ModelState.IsValid)
            {
                this.AnswersService.InsertAnswer(newAnswerViewModel);
                return RedirectToAction("View", "Questions", new { questionID = newAnswerViewModel.QuestionID });
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                QuestionViewModel questionViewModel = this.QuestionsService.GetQuestionByQuestionID(newAnswerViewModel.QuestionID, newAnswerViewModel.UserID);
                return View("View", questionViewModel);
            }
        }
        [HttpPost]
        [UserAuthorizationFilter]
        public ActionResult EditAnswer(EditAnswerViewModel editAnswerViewModel)
        {
            if (ModelState.IsValid)
            {
                editAnswerViewModel.UserID = Convert.ToInt32(Session["CurrentUserID"]);
                this.AnswersService.UpdateAnswer(editAnswerViewModel);
                return RedirectToAction("View", new { id = editAnswerViewModel.QuestionID });
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View("View", new { questionID = editAnswerViewModel.QuestionID });
            }
        }
        public ActionResult DeleteAnswer(int answerID, int questionID)
        {
            this.AnswersService.DeleteAnswer(answerID);
            return View("View", new { id = questionID });
        }
        [UserAuthorizationFilter]

        public ActionResult Create()
        {
            List<CategoryViewModel> categories = this.CategoriesService.GetCategories();
            ViewBag.categories = categories;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilter]
        public ActionResult Create(NewQuestionViewModel newQuestionViewModel)
        {
            if (ModelState.IsValid)
            {
                newQuestionViewModel.AnswersCount = 0;
                newQuestionViewModel.ViewsCount = 0;
                newQuestionViewModel.VotesCount = 0;
                newQuestionViewModel.QuestionDateAndTime = DateTime.Now;
                newQuestionViewModel.UserID = Convert.ToInt32(Session["CurrentUserID"]);
                this.QuestionsService.InsertQuestion(newQuestionViewModel);
                return RedirectToAction("Questions", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View();
            }
        }

    }
}