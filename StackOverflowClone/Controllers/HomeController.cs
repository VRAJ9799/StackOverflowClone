using StackOverflowClone.ServiceLayer.Interfaces;
using StackOverflowClone.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StackOverflowClone.Controllers
{
    public class HomeController : Controller
    {
        IQuestionsService QuestionsService;
        ICategoriesService CategoriesService;
        public HomeController(IQuestionsService questionsService, ICategoriesService categoriesService)
        {
            this.QuestionsService = questionsService;
            this.CategoriesService = categoriesService;
        }
        // GET: Home
        public ActionResult Index()
        {
            List<QuestionViewModel> questionViewModels = this.QuestionsService.GetQuestions().Take(10).ToList();
            return View(questionViewModels);
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Categories()
        {
            List<CategoryViewModel> categories = this.CategoriesService.GetCategories();
            return View(categories);
        }
        [Route("allquestions")]
        public ActionResult Questions()
        {
            List<QuestionViewModel> questions = this.QuestionsService.GetQuestions();
            return View(questions);
        }
        public ActionResult Search(string str)
        {
            List<QuestionViewModel> questions = this.QuestionsService.GetQuestions().Where(temp => temp.QuestionName.ToLower().Contains(str.ToLower()) || temp.Category.CategoryName.ToLower().Contains(str.ToLower())).ToList();
            return View(questions);
        }
    }
}