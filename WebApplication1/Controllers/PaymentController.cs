using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PaymentController : Controller
    {

        private readonly ILogger<PaymentController> _logger;
        private readonly DBQuizSharpContext _context;
        private readonly IConfiguration _config;

        public PaymentController(ILogger<PaymentController> logger, DBQuizSharpContext context, IConfiguration config)
        {
            _logger = logger;
            _context = context;
            _config = config;
        }

        public ActionResult QuizletPlus()
        {
            var _key = _config["Authentication:RazorPay:KeyId"];
            Bill bill = new Bill()
            {
                Amount = (float)35.99,
                Currency = "USD",
                Description = $"Transaction of customer {@TempData.Peek("username")} in {DateTime.Now}",
                UId = Convert.ToInt32(@TempData.Peek("uid")),
                Date = DateTime.Now,
                U = (from u in _context.User where u.Id == Convert.ToInt32(TempData.Peek("uid")) select u).Single()
            };
            bill.OrderId = CreateOrder(bill);
            ViewBag.Key = _key;
            TempData["Bill"] = JsonConvert.SerializeObject(bill);
            return View(bill);
        }

        private string CreateOrder(Bill bill)
        {
            var _key = _config["Authentication:RazorPay:KeyId"];
            var _keysecret = _config["Authentication:RazorPay:KeySecret"];
            try
            {
                RazorpayClient client = new RazorpayClient(_key, _keysecret);
                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("amount", 3599); // amount in the smallest currency unit
                options.Add("receipt", $"order_rcptid_{@TempData.Peek("uid")}");
                options.Add("currency", bill.Currency);
                Order order = client.Order.Create(options);
                var orderID = order.Attributes["id"].ToString();
                return orderID;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult AfterPayment()
        {
            var paymentStatus = Request.Form["paymentStatus"].ToString();
            if (paymentStatus.Equals("Fail"))
            {
                Bill bill = (Bill)TempData["Bill"];
                bill.Status = paymentStatus;
                _context.Add(bill);
                return View();
            }
            var paymentID = Request.Form["paymentId"].ToString();
            var orderID = Request.Form["orderID"].ToString();
            var signature = Request.Form["signature"].ToString();
            var validSignature = CompareSignatures(orderID, paymentID, signature);
            if (validSignature)
            {
                Bill bill = JsonConvert.DeserializeObject<Bill>(TempData["Bill"].ToString());
                bill.Status = paymentStatus;
                _context.Add(bill);
                _context.SaveChanges();
                var user = (from u in _context.Account where u.UId == Convert.ToInt32(TempData.Peek("uid")) select u).Single();
                user.Role = "premium";
                Contract contract = new Contract() { StartDate = DateTime.Now, ExpiredDate = DateTime.Today.AddYears(1), U = (from u in _context.User where u.Id == Convert.ToInt32(TempData.Peek("uid")) select u).Single(), Uid = Convert.ToInt32(TempData.Peek("uid")) };
                _context.Add(contract);
                _context.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            
        }

        private bool CompareSignatures(string orderid, string paymentid,string signature)
        {
            var text = orderid + "|" + paymentid;
            var _keysecret = _config["Authentication:RazorPay:KeySecret"];
            var generatedSignature = CalculateSHA256(text,_keysecret);
            if (generatedSignature.Equals(signature))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string CalculateSHA256(string text, string secret)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(secret);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
           
        }
    }
}
       