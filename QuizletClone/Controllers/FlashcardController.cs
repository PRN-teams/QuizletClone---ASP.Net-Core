using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizletClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizletClone.Controllers
{
    public class FlashcardController : Controller
    {
        private readonly ILogger<FlashcardController> _logger;
        private readonly DBQuizSharpContext _context;

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
            var myQuiz = (from s in _context.SetStudyQuizzes join q in _context.Quizzes on s.QuizId equals q.Id 
                          select new {QuizID = s.QuizId, QuizTerm= q.Term, QuizDef = q.Definition, sID = s.SetStudyId }).ToList();
            List < Quiz > quizzes = new List<Quiz>();
            foreach (var item in myQuiz.Where(item=>item.sID == id))
            {
                quizzes.Add(new Quiz {Id=item.QuizID, Term = item.QuizTerm,Definition=item.QuizDef });
            }
            if (quizzes.Count ==0)
            {
                return RedirectToAction("Error", "Flashcard");
            }
            ViewBag.getFirst = quizzes.First();
            ViewBag.getQuiz = quizzes;
            
            var user = (from u in _context.Users join q in (from s in _context.SetStudies where s.Id == id select new { userID = s.UserId }) on 
                        u.Id equals q.userID select new {uID = u.Id,uName = u.Username,uAva = u.AvatarUrl }).ToList();
            User quizuser = new User() {Username = user[0].uName, Id = user[0].uID, AvatarUrl = user[0].uAva };
            ViewBag.User = quizuser;
            var getset = (from u in _context.SetStudies where u.Id == id select new { sTitle = u.Title, sDate = u.CreatedDate }).ToList();
            ViewBag.getTitle = new SetStudy() { CreatedDate = getset[0].sDate, Title = getset[0].sTitle };
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
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        [Route("Flashcard/Writing/{id:int}")]
        public ActionResult Writing(int id)
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        [Route("Flashcard/Test/{id:int}")]
        public ActionResult Test(int id)
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        [Route("Flashcard/Room/{id:int}")]
        public ActionResult Room(int id)
        {
            TempData["getID"] = id;
            var myQuiz = (from s in _context.SetStudyQuizzes
                          join q in _context.Quizzes on s.QuizId equals q.Id
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

        [Route("Flashcard/User/{id:int}")]
        public ActionResult User(int id)
        {
            var a = (from u in _context.Users where u.Id == id 
                    select new { Username=u.Username, Id= u.Id, Dob= u.Dob, Ava = u.AvatarUrl,Email = u.Email }).ToList().SingleOrDefault();
            User users = new User() {AvatarUrl = a.Ava, Id = a.Id, Dob = a.Dob,Username = a.Username,Email = a.Email };
            ViewBag.UserInfo = users;
            //Display quiz
            //Display data
            Dictionary<User, SetStudy> mylist = new Dictionary<User, SetStudy>();
            Dictionary<int, int> gettotalTerm = new Dictionary<int, int>();
            var model = (from user in _context.Users
                         join set_study in _context.SetStudies on user.Id equals set_study.UserId
                         select new { uAvar = user.AvatarUrl, uName = user.Username, Title = set_study.Title, setID = set_study.Id, uId = user.Id }).ToList();
            var query = (from quizstudy in _context.SetStudyQuizzes group quizstudy by quizstudy.SetStudyId into setGroup select new { Myset = setGroup.Key, Count = setGroup.Count() }).ToList();
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

        // POST: Flashcard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // POST: Flashcard/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
