using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Frontier.CodingChallenge.Models;
using Frontier.CodingChallenge.Interfaces;
using Frontier.CodingChallenge.Services;

namespace Frontier.CodingChallenge.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IAccountService accountService)
        {
            this.AccountService = accountService;
        }

        protected IAccountService AccountService { get; }

        public  IActionResult Index()
        {
            var retVal = this.AccountService.GetAccounts().Result;
            FormatAccountString(ref retVal);
            return View(retVal);
        }

        /// <summary>
        /// Add special formatting for any fields. Currently formatting phone number
        /// </summary>
        /// <param name="accounts"></param>
        private void FormatAccountString(ref List<Account> accounts)
        {
            ///Phone number. Assume US. Only format if it has exactly 10 digits.
            foreach (var account in accounts)
            {
                if (!string.IsNullOrEmpty(account.PhoneNumber) && account.PhoneNumber.Length == 10)
                {
                    account.PhoneNumber = $"({account.PhoneNumber.Substring(0, 3)}) {account.PhoneNumber.Substring(3, 3)}-{account.PhoneNumber.Substring(5, 4)}";
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
