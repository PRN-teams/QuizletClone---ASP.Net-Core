using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizletClone.Models;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuizletClone.Controllers
{

    //Có 2 Action trong Controller Home là: Index và Privacy
    //==> Trong thư mục Home cũng sẽ có 2 View tương ứng với tên là Index và Privacy


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBQuizSharpContext _context;
        public HomeController(ILogger<HomeController> logger, DBQuizSharpContext context)
        {
            _logger = logger;
            _context = context;
        }

        //Nếu tạo ra các Action mới thì cũng sẽ có các View mới trong View

        //Cac Controller va Action
        // controller: IActionResult, Action: Index
        public IActionResult Index()
        {
            //Display data
            Dictionary<User, SetStudy> mylist = new Dictionary<User, SetStudy>();
            Dictionary<int,int> gettotalTerm = new Dictionary<int, int>();
            var model = (from user in _context.Users
                         join set_study in _context.SetStudies on user.Id equals set_study.UserId
                         select new { uAvar = user.AvatarUrl, uName = user.Username, Title = set_study.Title, setID = set_study.Id, uId =user.Id }).ToList();
            var query = (from quizstudy in _context.SetStudyQuizzes group quizstudy by quizstudy.SetStudyId into setGroup select new { Myset = setGroup.Key, Count = setGroup.Count() }).ToList();
            var result = (from m in model join q in query on m.setID equals q.Myset select new {uAvar = m.uAvar,uName = m.uName,uID = m.uId,
                         sTitle = m.Title, sID = m.setID, totalTerm = q.Count}).ToList();
            foreach (var item in result)
            {
                mylist.Add(new Models.User { Id = item.uID, Username = item.uName, AvatarUrl = item.uAvar }, new SetStudy {Id = item.sID,Title = item.sTitle });
                gettotalTerm.Add(item.sID,item.totalTerm);
            }
            try
            {
                var set = (from myset in mylist where myset.Key.Username == HttpContext.Session.GetString("SessionuName").ToString() select myset).ToList();
                ViewBag.MySet = set;
            }
            catch (System.Exception)
            {

                TempData.Clear();
            }
            ViewBag.QuizSet = mylist;
            ViewBag.TotalQuiz = gettotalTerm;
            return View();
        }

      [HttpGet]
        public IActionResult Search()
        {
            string search = Request.Query["searching"];
            if(search.Trim().Equals(""))
            {
                return RedirectToAction("Index", "Home");
            }
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
            var relatedset = (from myset in mylist where (myset.Value.Title.ToLower()).Contains(search.ToLower()) select myset).ToList();
            ViewBag.SetResult = relatedset;
            ViewBag.TotalQuiz = gettotalTerm;
            try
            {
                var set = (from myset in mylist where myset.Key.Username == HttpContext.Session.GetString("SessionuName").ToString() && (myset.Value.Title.ToLower()).Contains(search.ToLower()) select myset).ToList();
                ViewBag.MySet = set;
            }
            catch (System.Exception)
            {

                TempData.Clear();
            }
            var TotalsetbyUser = (from s in _context.SetStudies group s by s.UserId into setgroup select new { uID = setgroup.Key, Count = setgroup.Count() }).ToList();
            var getu = (from r in result join t in TotalsetbyUser on r.uID equals t.uID select new { uId = r.uID, uName = r.uName,
                        uAva = r.uAvar, totalSet = t.Count}).ToList();
            Dictionary<User, int> UserRelated = new Dictionary<User, int>();
            foreach (var item in getu.Distinct())
            {
                UserRelated.Add(new Models.User { AvatarUrl = item.uAva, Id = item.uId, Username = item.uName }, item.totalSet);
            }
            ViewBag.UserRelated = (from u in UserRelated where u.Key.Username.ToLower().Contains(search.ToLower()) select u).ToList();
            return View();
        }

        // controller: IActionResult, Action: Privacy
        public IActionResult MyLibrary()
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("Login", "Home");
            }
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
            var set = (from myset in mylist where myset.Key.Username == HttpContext.Session.GetString("SessionuName") select myset).ToList();
            ViewBag.MySet = set;
            ViewBag.TotalQuiz = gettotalTerm;
            return View();
        }

       
        public IActionResult Login()
        {
            if (TempData.Peek("username") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                var listUser = (from u in _context.Users select u).ToList();
                foreach (var item in listUser)
                {
                    if ((user.Username).Equals(item.Username) && (user.Password).Equals(item.Password))
                    {
                        HttpContext.Session.SetString("SessionuName", user.Username);
                        HttpContext.Session.SetInt32("SessionuID", item.Id);
                        HttpContext.Session.SetString("SessionuAva", item.AvatarUrl);
                        HttpContext.Session.SetString("SessionuEmail", item.Email);
                        HttpContext.Session.SetString("SessionuDOB", (item.Dob).ToString());
                        TempData["uid"] = HttpContext.Session.GetInt32("SessionuID");
                        TempData["username"] = HttpContext.Session.GetString("SessionuName");
                        TempData["userAva"] = HttpContext.Session.GetString("SessionuAva");
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Err = true;
                        return View();
                    }
                }
            }catch(System.Exception)
            {
                ViewBag.Err = false;
                return View();
            }
           
            return View();
            
        }

        public IActionResult Register()
        {

            if (TempData.Peek("username") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
