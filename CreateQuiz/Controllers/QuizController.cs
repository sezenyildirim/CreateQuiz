using CreateQuiz.Context;
using CreateQuiz.DTOS;
using CreateQuiz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;

namespace CreateQuiz.Controllers
{
    public class QuizController : Controller
    {
        private readonly CreateQuizDBContext _context;

        public QuizController(CreateQuizDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var quizzes = await _context.Quizzes.ToListAsync();
            return View(quizzes);
        }

        public IActionResult CreateNewQuiz()
        {

            string link = "http://www.wired.com/most-recent";
            Uri url = new Uri(link);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);

            var nodes = document.DocumentNode.Descendants("h3").Take(5).Select(s=>s.InnerHtml).ToList();
            return View(nodes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewQuiz(Quiz quiz)
        {
            quiz.ID = Guid.NewGuid();
            quiz.CreatedDate = DateTime.Now;
            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string ID)
        {
            var quiz = await _context.Quizzes.FindAsync(Guid.Parse(ID));
            if(quiz != null)
            {
                _context.Remove(quiz);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AnswerQuiz(string ID)
        {
            var quiz = await _context.Quizzes.FindAsync(Guid.Parse(ID));
            return View(quiz);
        }
        [HttpGet]
        public JsonResult CheckAnswer(string quizID, string answer1, string answer2, string answer3, string answer4)
        {
            Quiz quiz = _context.Quizzes.Find(Guid.Parse(quizID)); 
            AnswerDTO answerDTO = new AnswerDTO();
            if(quiz.RightAnswer1 != answer1)
            {
                answerDTO.Answer1 = false;
            }
            else if(quiz.RightAnswer1 == answer1)
            {
                answerDTO.Answer1 = true;
            }
            if (quiz.RightAnswer2 != answer2)
            {
                answerDTO.Answer2 = false;
            }
            else if (quiz.RightAnswer2 == answer2)
            {
                answerDTO.Answer2 = true;
            }
            if (quiz.RightAnswer3 != answer3)
            {
                answerDTO.Answer3 = false;
            }
            else if (quiz.RightAnswer3 == answer3)
            {
                answerDTO.Answer3 = true;
            }
            if (quiz.RightAnswer4 != answer4)
            {
                answerDTO.Answer4 = false;
            }

            else if (quiz.RightAnswer4 == answer4)
            {
                answerDTO.Answer4 = true;
            }
            return Json(answerDTO);
        }




    }
}
