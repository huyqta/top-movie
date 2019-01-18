using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Services.Models;

namespace TopMovie
{
    [Authorize]
    public class LoginController : Controller
    {
        webphimContext context = new webphimContext();

        public IActionResult Index()
        {
            return View();
        }

        //[Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            MD5 md5Hash = MD5.Create();
            //string hash = GetMd5Hash(md5Hash, password);
            //bool verifyPwd = VerifyMd5Hash(md5Hash, password, GetMd5Hash(md5Hash, password));
            if (username != null && password != null)// && context.TbAccount.Any(a=>a.Username == username && VerifyMd5Hash(md5Hash, password, GetMd5Hash(md5Hash, password))))
            {
                var account = context.TbAccount.FirstOrDefault(a => a.Username == username);
                if (account != null && account.AccountType == 0)
                {
                    var verifyAccount = VerifyMd5Hash(md5Hash, password, account.Password);
                    if (verifyAccount)
                    {
                        HttpContext.Session.SetString("username", username);
                        //var admin_token = GetMd5Hash(md5Hash, account.Username + account.Password + account.AccountType);
                        //account.AdminToken = admin_token;
                        //context.Entry<TbAccount>(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        //context.SaveChanges();
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return RedirectToAction("Index", "Login");
            }
            ViewBag.error = "Invalid Account";
            return RedirectToAction("Index", "Login");
        }

        //[Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            
            //context.Entry<TbAccount>(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //context.SaveChanges();
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index", "Login");
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}