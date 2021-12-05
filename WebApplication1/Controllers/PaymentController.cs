using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
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
            };
            bill.OrderId = CreateOrder(bill);
            ViewBag.Key = _key;
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
    }
}
       