using Google.Apis.Auth.AspNetCore3;
using Google.Apis.PeopleService.v1;
using Google.Apis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search()
        {
            string search = Request.Query["searching"];
            if (search.Trim().Equals(""))
            {
                return RedirectToAction("Index", "Home");
            }
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
            //Get related user
            var relatedUser = (from u in _context.User where u.Username.ToLower().Contains(search.ToLower()) select u).ToList();
            var TotalsetbyUser = (from s in _context.SetStudy group s by s.UserId into setgroup select new { uID = setgroup.Key, Count = setgroup.Count() }).ToList();
            Dictionary<User, int> UserRelated = new Dictionary<User, int>();
            var test = TotalsetbyUser.Any(cus => cus.uID == 1);
            foreach (var item in relatedUser)
            {
                UserRelated.Add(new Models.User { AvatarUrl = item.AvatarUrl, Id = item.Id, Username = item.Username },
                                TotalsetbyUser.Any(cus => cus.uID == item.Id) ? TotalsetbyUser.Where(x => x.uID == item.Id).Select(x => x.Count).FirstOrDefault() : 0);
            }
            ViewBag.UserRelated = UserRelated;
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
            var set = (from myset in mylist where myset.Key.Username == HttpContext.Session.GetString("SessionuName") select myset).ToList();
            ViewBag.MySet = set;
            ViewBag.TotalQuiz = gettotalTerm;
            return View();
        }

        public IActionResult CreateQuiz()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Only me", Value = "1" });
            items.Add(new SelectListItem { Text = "Public", Value = "2" });
            ViewBag.Visibility = items;
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult CreateQuiz(SetStudy set)
        {
            set.IsPrivate = int.Parse(Request.Form["Visibility"].ToString()) == 2 ? false : true;
            set.UserId = (int)TempData.Peek("uid");
            set.CreatedDate = DateTime.Now;
            int maxValue = (from q in _context.Quiz select q.Id).ToList().OrderByDescending(x => x).First();
            string term = Request.Form["Term"];
            List<string> getTerm = term.Split(',').ToList();
            string def = Request.Form["Def"];
            List<string> getDef = def.Split(',').ToList();
            List<Quiz> quizzes = new List<Quiz>();
            for (int i = 1; i < getTerm.Count; i++)
            {
                quizzes.Add(new Quiz { Term = getTerm[i], Definition = getDef[i] });
            }
            foreach (var item in quizzes)
            {
                _context.Add(item);
            }
            int setValue = (from q in _context.SetStudy select q.Id).ToList().OrderByDescending(x => x).First();
            _context.Add(set);
            for (int i = maxValue + 1; i <= maxValue + quizzes.Count; i++)
            {
                SetStudyQuiz setStudyQuiz = new SetStudyQuiz() { QuizId = i, SetStudyId = setValue };
                _context.Add(setStudyQuiz);
            }
            _context.SaveChanges();

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
                    var listUser = (from u in _context.User where u.Email == user.Email && u.Password == user.Password select u).SingleOrDefault();
                    HttpContext.Session.SetString("SessionuName", listUser.Username);
                    HttpContext.Session.SetInt32("SessionuID", listUser.Id);
                    HttpContext.Session.SetString("SessionuAva", listUser.AvatarUrl);
                    HttpContext.Session.SetString("SessionuEmail", listUser.Email);
                    HttpContext.Session.SetString("SessionuDOB", (listUser.Dob).ToString());
                    TempData["uid"] = HttpContext.Session.GetInt32("SessionuID");
                    TempData["username"] = HttpContext.Session.GetString("SessionuName");
                    TempData["userAva"] = HttpContext.Session.GetString("SessionuAva");
                    return RedirectToAction("Index", "Home");


                }
                catch (Exception)
                {
                    ViewBag.Err = true;
                    return View();
                }
            
        }

        //Google Oauth Part -- Login
        [GoogleScopedAuthorize(PeopleServiceService.ScopeConstants.UserinfoProfile)]
        public async Task<IActionResult> GoogleAuth([FromServices] IGoogleAuthProvider auth)
        {
            var cred = await auth.GetCredentialAsync();
            var service = new PeopleServiceService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = cred
            });


            var request = service.People.Get("people/me");
            request.PersonFields = "emailAddresses";
            var person = await request.ExecuteAsync();
            var info = person.EmailAddresses.FirstOrDefault()?.Value;
            try
            {
               
                var listUser = (from u in _context.User where u.Email == info select u).SingleOrDefault();
                HttpContext.Session.SetString("SessionuName", listUser.Username);
                HttpContext.Session.SetInt32("SessionuID", listUser.Id);
                HttpContext.Session.SetString("SessionuAva", listUser.AvatarUrl);
                HttpContext.Session.SetString("SessionuEmail", listUser.Email);
                HttpContext.Session.SetString("SessionuDOB", (listUser.Dob).ToString());
                TempData["uid"] = HttpContext.Session.GetInt32("SessionuID");
                TempData["username"] = HttpContext.Session.GetString("SessionuName");
                TempData["userAva"] = HttpContext.Session.GetString("SessionuAva");
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                foreach (var cookie in HttpContext.Request.Cookies)
                {
                    Response.Cookies.Delete(cookie.Key);
                }
                ViewBag.Err = true;
                return View("Login");
            }
        }

        public IActionResult Register()
        {

            if (TempData.Peek("username") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (user.AvatarUrl == null)
            {
                user.AvatarUrl = "https://avatars.dicebear.com/api/open-peeps/your-custom-seed.svg";
            }

            if (DateTime.Now.Year - user.Dob.Year <= 13)
            {
                ViewBag.ValidYear = " Your age is not enough to Register, please check again! You should be older than 13 at least!";
                return View();
            }
            try
            {
                var a = (from u in _context.User where u.Email == user.Email select u).Single();
                ViewBag.Err = "Email is already exist, please choose another email!";
            }
            catch (Exception)
            {
                try
                {
                    //Ma hoa mat khau trc khi bo vao database
        // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
                    byte[] salt = new byte[128 / 8];
                    using (var rngCsp = new RNGCryptoServiceProvider())
                    {
                        rngCsp.GetNonZeroBytes(salt);
                    }
                    // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
                    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: user.Password,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 100000,
                        numBytesRequested: 256 / 8));
                    user.Password = hashed;
                    //End encryption
                    _context.Add(user);
                    _context.SaveChanges();
                    ViewBag.Success = "Register successfully!! Goes";
                }
                catch (Exception)
                {
                    ViewBag.Err = "Username is already exist, please choose another name!";
                }
            }
            return View();

        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData.Clear();
            foreach (var cookie in HttpContext.Request.Cookies)
            {
                Response.Cookies.Delete(cookie.Key);
            }
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

        string MailBody = "<!DOCTYPE html>" +
                               "<html>" +
"<body marginheight=\"0\" topmargin=\"0\" marginwidth=\"0\" style=\"margin: 0px; background-color: #f2f3f8;\" leftmargin=\"0\">"
+
" <table cellspacing = \"0\" border=\"0\" cellpadding=\"0\" width=\"100%\" bgcolor=\"#f2f3f8\" style=\"@import url(https://fonts.googleapis.com/css?family=Rubik:300,400,500,700|Open+Sans:300,400,600,700); font-family: 'Open Sans', sans-serif;\">"
  + " <tr>" +
    " <td>"
     + "<table style = \"background-color: #f2f3f8; max-width:670px;  margin:0 auto;\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">"
     + "<tr>"
       + "<td style = \"height:80px;\" > &nbsp;</td>"
     + "    </tr>"
      + "    </tr>"
         + "<td style = \"text-align:center;\" >"
         + "<a href=\"https://localhost:44353 \" title=\"logo\" target=\"_blank\">"
        + " <img width = \"60\" src=\"https://i.ibb.co/hL4XZp2/android-chrome-192x192.png\" title=\"logo\" alt=\"logo\">"
       + "</a>"
         + "    </td>"
       + "    </tr>"
      + "<tr>"
      + "<td style = \"height:20px;\" > &nbsp;</td>"
    + "    </tr>"
  + "<tr>"
          + "<td>"
            + "<table width = \"95%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"max-width:670px;background:#fff; border-radius:3px; text-align:center;-webkit-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);-moz-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);box-shadow:0 6px 18px 0 rgba(0,0,0,.06);\">"
           + "<tr>"
              + "<td style = \"height:40px;\" > &nbsp;</td>"
            + "    </tr>"
             + "<tr>"
               + "<td style = \"padding:0 35px;\" >"
               + "<h1 style=\"color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family:'Rubik',sans-serif;\">You have "
                    + "requested to reset your password</h1>"
                  + "<span style = \"display:inline-block; vertical-align:middle; margin:29px 0 26px; border-bottom:1px solid #cecece; width:100px;\" ></ span >"
                   + "<p style=\"color:#455056; font-size:15px;line-height:24px; margin:0;\">"
                    + "We cannot simply send you your old password.A unique link to reset your"
                     + "password has been generated for you.To reset your password, click the"
                   + "following link and follow the instructions."
                  + "</p>"
                  + " <a href = \"https://localhost:44353/Home/Reset_Password \" style= \"background:#20e277;text-decoration:none !important; font-weight:500; margin-top:35px; color:#fff;text-transform:uppercase; font-size:14px;padding:10px 24px;display:inline-block;border-radius:50px;\" > Reset"
                  + "Password</a>"
                + "  </td>"
               + "    </tr>"
               + "<tr>"
                + " <td style = \"height:40px;\" > &nbsp;</td>"
                + "    </tr>"
            + "</table>"
          + "  </td>"
        + " <tr>"
          + " <td style = \"height:20px;\" > &nbsp;</td>"
          + "    </tr>"
       + "<tr>"
         + "  <td style = \"text-align:center;\" >"
           + " <p style=\"font-size:14px; color:rgba(69, 80, 86, 0.7411764705882353); line-height:18px; margin:0 0 0;\">&copy; <strong>www.quizletClone.com</strong></p>"
         + "  </td>"
        + "    </tr>"
        + "    </tr>"
        + "   <td style = \"height:80px;\" > &nbsp;</td>"
     + "    </tr>"
    + "   </table>"
   + "  </td>"
 + "  </tr>"
+ " </table>"
+ "</body>"
+ "</html>";
        string subject = "Reset Password";
        string mailtitle = "Email from Quizlet CLone";
        string fromemail = "tranthe150186@fpt.edu.vn";
        string fromemailpw = "Jay.empty19";

        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            bool flag = true;
            try
            {
                var validEmail = (from e in _context.User where e.Email == email select e).Single();
                TempData["getResetInfo"] = validEmail.Id;
            }
            catch
            {
                flag = false;
            }
            if (flag)
            {
                //Email & Content
                string toemail = Convert.ToString(email);
                MailMessage message = new MailMessage(new MailAddress(fromemail, mailtitle), new MailAddress(toemail));
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
            }
            else
            {
                ViewBag.Err = "Email is not exist! Please try again!!";
            }

            return View();
        }
        public IActionResult Reset_Password()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reset_Password(string resetpass, string confirm)
        {
            try
            {
                if (resetpass.Equals(confirm))
                {
                    int resetID = (int)TempData["getResetInfo"];
                    var resetUser = _context.User.FirstOrDefault(x => x.Id == resetID);
                    resetUser.Password = confirm;
                    _context.SaveChanges();
                    ViewBag.Status = "Your Password has changed successfully!";
                }
                else
                {
                    ViewBag.Err = "New password and confirm password is not match!Please enter again";
                }
            }
            catch (Exception)
            {

                ViewBag.Exception = "Hmm Seems like you haven't authorize your email for reset password yet!! Go ";
            }

            return View();
        }
    }
}
