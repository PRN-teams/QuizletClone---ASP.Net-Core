using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizletClone.Models;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Net.Mail;

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

        public IActionResult CreateQuiz()
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            
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
        [Route("google-login")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [Route("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal.Identities
                .FirstOrDefault().Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });

            return Json(claims);
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

        
        public IActionResult ForgotPassword()
        {
            return View();

        }

        string MailBody = "<!DOCTYPE html>"+
                                "<html>"+
"<body marginheight=\"0\" topmargin=\"0\" marginwidth=\"0\" style=\"margin: 0px; background-color: #f2f3f8;\" leftmargin=\"0\">"
 +
 " <table cellspacing = \"0\" border=\"0\" cellpadding=\"0\" width=\"100%\" bgcolor=\"#f2f3f8\" style=\"@import url(https://fonts.googleapis.com/css?family=Rubik:300,400,500,700|Open+Sans:300,400,600,700); font-family: 'Open Sans', sans-serif;\">"
   +" <tr>" +
     " <td>" 
      +  "<table style = \"background-color: #f2f3f8; max-width:670px;  margin:0 auto;\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">"
      +    "<tr>"
        +    "<td style = \"height:80px;\" > &nbsp;</td>"
      +"    </tr>"
       +"    </tr>"
          +   "<td style = \"text-align:center;\" >"
          + "<a href=\"http://localhost:9873/ \" title=\"logo\" target=\"_blank\">"
         +       " <img width = \"60\" src=\"https://i.ibb.co/hL4XZp2/android-chrome-192x192.png\" title=\"logo\" alt=\"logo\">"
        + "</a>"
          + "    </td>"
        + "    </tr>"
       +    "<tr>"
       +     "<td style = \"height:20px;\" > &nbsp;</td>"
     +"    </tr>"
   +    "<tr>"
           + "<td>"
             + "<table width = \"95%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"max-width:670px;background:#fff; border-radius:3px; text-align:center;-webkit-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);-moz-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);box-shadow:0 6px 18px 0 rgba(0,0,0,.06);\">"
            +    "<tr>"
               +   "<td style = \"height:40px;\" > &nbsp;</td>"
             +"    </tr>"
              +    "<tr>"
                +  "<td style = \"padding:0 35px;\" >"
                +    "<h1 style=\"color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family:'Rubik',sans-serif;\">You have "
                     + "requested to reset your password</h1>"
                   + "<span style = \"display:inline-block; vertical-align:middle; margin:29px 0 26px; border-bottom:1px solid #cecece; width:100px;\" ></ span >"
                    +"<p style=\"color:#455056; font-size:15px;line-height:24px; margin:0;\">"
                     + "We cannot simply send you your old password.A unique link to reset your"
                      +"password has been generated for you.To reset your password, click the"
                    +  "following link and follow the instructions."
                   + "</p>"
                   + " <a href = \"http://localhost:9873/Home/Reset_Password \" style= \"background:#20e277;text-decoration:none !important; font-weight:500; margin-top:35px; color:#fff;text-transform:uppercase; font-size:14px;padding:10px 24px;display:inline-block;border-radius:50px;\" > Reset"
                   + "Password</a>"
                 +"  </td>"
                +"    </tr>"
                +"<tr>"
                 +" <td style = \"height:40px;\" > &nbsp;</td>"
                 +"    </tr>"
             + "</table>"
           +"  </td>"
         +" <tr>"
           +" <td style = \"height:20px;\" > &nbsp;</td>"
           +"    </tr>"
        +  "<tr>"
          +"  <td style = \"text-align:center;\" >"
            +" <p style=\"font-size:14px; color:rgba(69, 80, 86, 0.7411764705882353); line-height:18px; margin:0 0 0;\">&copy; <strong>www.quizletClone.com</strong></p>"
          +"  </td>"
         +"    </tr>"
         +"    </tr>"
         +"   <td style = \"height:80px;\" > &nbsp;</td>"
      +"    </tr>"
     +"   </table>"
    +"  </td>"
  +"  </tr>"
 +" </table>"
+"</body>"
+ "</html>";
        string subject = "Reset Password";
        string mailtitle = "Email from Quizlet CLone";
        string fromemail = "tranthe150186@fpt.edu.vn";
        string fromemailpw = "Jay.empty19";

        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {

            //Email & Content
            string toemail = Convert.ToString(email);
            MailMessage message = new MailMessage(new MailAddress(fromemail,mailtitle),new MailAddress(toemail));
            message.Subject = subject;
            message.Body = MailBody;
            message.IsBodyHtml = true;
           
            //Server Detail
            SmtpClient smtp = new SmtpClient();
            //gmail ports = 465(SSL) ir 587(TSL)
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            //Credentials
            System.Net.NetworkCredential credential = new System.Net.NetworkCredential();
            credential.UserName = fromemail;
            credential.Password = fromemailpw;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;

            smtp.Send(message);

            ViewBag.EmailSendMessage = "Email sent successfully!! Please check your email";
            return View();
        }
        public IActionResult Reset_Password()
        {
            return View();
        }
    }
}
