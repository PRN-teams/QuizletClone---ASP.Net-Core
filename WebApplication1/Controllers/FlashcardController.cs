using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FlashcardController : Controller
    {
        private readonly ILogger<FlashcardController> _logger;
        private readonly DBQuizSharpContext _context;
        // GET: FlashcardController
        public FlashcardController(ILogger<FlashcardController> logger, DBQuizSharpContext context)
        {
            _logger = logger;
            _context = context;
        }
        [Route("Flashcard/Index/{id:int}")]
        // GET: Flashcard
        public ActionResult Index(int id)
        {
            ViewBag.getID = id;
            var myQuiz = (from s in _context.SetStudyQuiz
                          join q in _context.Quiz on s.QuizId equals q.Id
                          select new { QuizID = s.QuizId, QuizTerm = q.Term, QuizDef = q.Definition, sID = s.SetStudyId }).ToList();
            List<Quiz> quizzes = new List<Quiz>();
            foreach (var item in myQuiz.Where(item => item.sID == id))
            {
                quizzes.Add(new Quiz { Id = item.QuizID, Term = item.QuizTerm, Definition = item.QuizDef });
            }
            if (quizzes.Count == 0)
            {
                return RedirectToAction("Error", "Flashcard");
            }
            ViewBag.getFirst = quizzes.First();
            ViewBag.getQuiz = quizzes;
            var user = (from u in _context.User
                        join q in (from s in _context.SetStudy where s.Id == id select new { userID = s.UserId }) on
            u.Id equals q.userID
                        select new { uID = u.Id, uName = u.Username, uAva = u.AvatarUrl }).ToList();
            User quizuser = new User() { Username = user[0].uName, Id = user[0].uID, AvatarUrl = user[0].uAva };
            ViewBag.User = quizuser;
            var getset = (from u in _context.SetStudy where u.Id == id select u.Title).SingleOrDefault();
            ViewBag.getTitle = getset;
            return View();
        }


        // GET: Flashcard/Details/5
        public ActionResult Error()
        {

            return View();
        }
        [Route("Flashcard/Learning/{id:int}")]
        public ActionResult Learning(int id)
        {
            ViewBag.getID = id;
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var a = (from s in _context.SetStudy where s.Id == id select s.Title).FirstOrDefault();
            ViewBag.Title = a;
            var myQuiz = (from s in _context.SetStudyQuiz
                          join q in _context.Quiz on s.QuizId equals q.Id
                          select new { QuizID = s.QuizId, QuizTerm = q.Term, QuizDef = q.Definition, sID = s.SetStudyId }).ToList();
            List<Quiz> quizzes = new List<Quiz>();
            foreach (var item in myQuiz.Where(item => item.sID == id))
            {
                quizzes.Add(new Quiz { Id = item.QuizID, Term = item.QuizTerm, Definition = item.QuizDef });
            }
            if (quizzes.Count == 0)
            {
                return RedirectToAction("Error", "Flashcard");
            }
            ViewBag.getFirst = quizzes.First();
            ViewBag.getQuiz = quizzes;
            Random rnd = new Random();
            int maxValue = (from q in quizzes select q.Id).ToList().OrderByDescending(x => x).First();
            List<List<Quiz>> multipleChoice = new List<List<Quiz>>();
            for (int i = 0; i < quizzes.Count; i++)
            {
                List<Quiz> getRandomQuiz = new List<Quiz>();
                getRandomQuiz.Add(new Quiz() { Id = quizzes[i].Id, Term = quizzes[i].Term });
                for (int j = 0; j < 3; j++)
                {
                    int rand = rnd.Next(maxValue);
                    getRandomQuiz.Add(new Quiz() { Id = rand, Term = (from q in _context.Quiz where q.Id == rand select q.Term).First() });
                }
                getRandomQuiz = getRandomQuiz.OrderBy(item => rnd.Next()).ToList();
                multipleChoice.Add(getRandomQuiz);
            }
            ViewBag.MultipleChoiceSet = multipleChoice;
            return View();
        }

        [Route("Flashcard/Test/{id:int}")]
        public ActionResult Test(int id)
        {
            ViewBag.getID = id;
            var a = (from s in _context.SetStudy where s.Id == id select s.Title).FirstOrDefault();
            ViewBag.Title = a;
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var myQuiz = (from s in _context.SetStudyQuiz
                          join q in _context.Quiz on s.QuizId equals q.Id
                          select new { QuizID = s.QuizId, QuizTerm = q.Term, QuizDef = q.Definition, sID = s.SetStudyId }).ToList();
            List<Quiz> quizzes = new List<Quiz>();
            foreach (var item in myQuiz.Where(item => item.sID == id))
            {
                quizzes.Add(new Quiz { Id = item.QuizID, Term = item.QuizTerm, Definition = item.QuizDef });
            }
            if (quizzes.Count == 0)
            {
                return RedirectToAction("Error", "Flashcard");
            }
            ViewBag.getQuiz = quizzes;
            Random rnd = new Random();
            int maxValue = (from q in quizzes select q.Id).ToList().OrderByDescending(x => x).First();
            List<List<Quiz>> multipleChoice = new List<List<Quiz>>();
            for (int i = 0; i < quizzes.Count; i++)
            {
                List<Quiz> getRandomQuiz = new List<Quiz>();
                getRandomQuiz.Add(new Quiz() { Id = quizzes[i].Id, Term = quizzes[i].Term });
                for (int j = 0; j < 3; j++)
                {
                    int rand = rnd.Next(maxValue);
                    getRandomQuiz.Add(new Quiz() { Id = rand, Term = (from q in _context.Quiz where q.Id == rand select q.Term).First() });
                }
                getRandomQuiz = getRandomQuiz.OrderBy(item => rnd.Next()).ToList();
                multipleChoice.Add(getRandomQuiz);
            }
            ViewBag.MultipleChoiceSet = multipleChoice;
            return View();
        }

        [Route("Flashcard/Writing/{id:int}")]
        public ActionResult Writing(int id)
        {
            ViewBag.getID = id;
            var a = (from s in _context.SetStudy where s.Id == id select s.Title).FirstOrDefault();
            ViewBag.Title = a;
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var myQuiz = (from s in _context.SetStudyQuiz
                          join q in _context.Quiz on s.QuizId equals q.Id
                          select new { QuizID = s.QuizId, QuizTerm = q.Term, QuizDef = q.Definition, sID = s.SetStudyId }).ToList();
            List<Quiz> quizzes = new List<Quiz>();
            foreach (var item in myQuiz.Where(item => item.sID == id))
            {
                quizzes.Add(new Quiz { Id = item.QuizID, Term = item.QuizTerm, Definition = item.QuizDef });
            }
            if (quizzes.Count == 0)
            {
                return RedirectToAction("Error", "Flashcard");
            }
            ViewBag.getFirst = quizzes.First();
            ViewBag.getQuiz = quizzes;

            return View();
        }

        [Route("Flashcard/Room/{id:int}")]
        public ActionResult Room(int id)
        {
            var a = (from s in _context.SetStudy where s.Id == id select s.Title).FirstOrDefault();
            ViewBag.Title = a;
            TempData["getID"] = id;
            var myQuiz = (from s in _context.SetStudyQuiz
                          join q in _context.Quiz on s.QuizId equals q.Id
                          select new { QuizID = s.QuizId, QuizTerm = q.Term, QuizDef = q.Definition, sID = s.SetStudyId }).ToList();
            List<Quiz> quizzes = new List<Quiz>();
            foreach (var item in myQuiz.Where(item => item.sID == id))
            {
                quizzes.Add(new Quiz { Id = item.QuizID, Term = item.QuizTerm, Definition = item.QuizDef });
            }
            if (quizzes.Count == 0)
            {
                return RedirectToAction("Error", "Flashcard");
            }
            ViewBag.getFirst = quizzes.First();
            ViewBag.getQuiz = quizzes;
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        [Route("Flashcard/Users/{id:int}")]
        public ActionResult Users(int id)
        {
            var a = (from u in _context.User
                     where u.Id == id
                     select new { Username = u.Username, Id = u.Id, Dob = u.Dob, Ava = u.AvatarUrl, Email = u.Email }).ToList().SingleOrDefault();
            User users = new User() { AvatarUrl = a.Ava, Id = a.Id, Dob = a.Dob, Username = a.Username, Email = a.Email };
            ViewBag.UserInfo = users;
            //Display quiz
            //Display data
            Dictionary<User, SetStudy> mylist = new Dictionary<User, SetStudy>();
            Dictionary<int, int> gettotalTerm = new Dictionary<int, int>();
            var model = (from user in _context.User
                         join set_study in _context.SetStudy on user.Id equals set_study.UserId
                         select new { uAvar = user.AvatarUrl, uName = user.Username, Title = set_study.Title, setID = set_study.Id, uId = user.Id }).ToList();
            var query = (from quizstudy in _context.SetStudyQuiz group quizstudy by quizstudy.SetStudyId into setGroup select new { Myset = setGroup.Key, Count = setGroup.Count() }).ToList();
            var result = (from m in model
                          join q in query on m.setID equals q.Myset
                          select new
                          {
                              uAvar = m.uAvar,
                              uName = m.uName,
                              uID = m.uId,
                              sTitle = m.Title,
                              sID = m.setID,
                              totalTerm = q.Count
                          }).ToList();
            foreach (var item in result)
            {
                mylist.Add(new Models.User { Id = item.uID, Username = item.uName, AvatarUrl = item.uAvar }, new SetStudy { Id = item.sID, Title = item.sTitle });
                gettotalTerm.Add(item.sID, item.totalTerm);
            }
            var set = (from myset in mylist where myset.Key.Username == users.Username select myset).ToList();
            ViewBag.MySet = set;
            ViewBag.TotalQuiz = gettotalTerm;
            return View();
        }

        public ActionResult Congrats()
        {
            return View();
        }

        [HttpPost]
        // POST: Flashcard/Create
        public ActionResult EditProfile(User user)
        {

            return View();
        }

        // POST: Flashcard/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
