using Diplom_popitka1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Dynamic;
using System.Net;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Diplom_popitka1.Controllers
{
    public class HomeController : Controller
    {

        private readonly diplom_popitca1Context _context;

        public HomeController(diplom_popitca1Context context)
        {
            _context = context;
        }

        public IActionResult About_company()
        {
            return View();
        }



        public byte[] Photo(IFormFile phot)
        {
            using (var target = new MemoryStream())
            {
                phot.CopyTo(target);
                return target.ToArray();
            }
        }

        //
        public IActionResult AccountMechanic()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
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

        public IActionResult AuthButton_Click()
        {
            return View("~/Views/Home/AuthorizationWindow.cshtml");
        }
        //
        public IActionResult AuthorizationWindow()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AuthorizationWindow(string tel, string password)
        {
            foreach (var entity in _context.ChangeTracker.Entries())
            {
                if (entity.Entity != null)
                {
                    entity.Reload();
                }
            }
            Logining user = _context.Logining.SingleOrDefault(user => user.Password == password) ?? new Logining();
            if (user == null)
            {
                return View("~/Views/Home/AuthorizationWindow.cshtml");
            }
            else
            {
                ViewBag.love = user.IdRole;
                if (user.IdRole == 1)
                {
                    var loginClient = _context.Clients.SingleOrDefault(client => client.IdClient == user.IdLoginUser);
                    if (loginClient != null && loginClient.Telephone == tel)
                    {
                        HttpContext.Session.SetString("ClientLogin", Newtonsoft.Json.JsonConvert.SerializeObject(loginClient));
                        var mots = _context.MotorcyclesToClient.Where(m => m.IdClient == loginClient.IdClient).ToList();
                        ViewData["Mots"] = mots;
                        ViewBag.name = loginClient.Fullname;
                        ViewBag.tel = tel;
                        return View("~/Views/Client/AccountClient.cshtml", mots);
                    }
                }
                else if (user.IdRole == 2)
                {
                    ViewBag.love = "Пользователь не найден";

                    if (user != null && user.IdUser.HasValue)
                    {
                        var idUser = user.IdUser.Value;
                        var loginMechanic = _context.Mechanics.FirstOrDefault(mechanic => mechanic.IdMechanic == idUser);

                        if (loginMechanic != null && loginMechanic?.Telephone == tel)
                        {

                            HttpContext.Session.SetString("MechanicLogin", Newtonsoft.Json.JsonConvert.SerializeObject(loginMechanic));
                            ViewData["name"] = loginMechanic.Fullname;
                            ViewData["tel"] = tel;
                            return RedirectToAction("AccountMechanic", "Mechanic");
                        }
                    }
                }

                return View("~/Views/Home/AuthorizationWindow.cshtml");
            }

        }
    }
}