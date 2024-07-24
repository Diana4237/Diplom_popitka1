using Diplom_popitka1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using System.Diagnostics;
using System.Net;

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
        public IActionResult Requarments()
        {
            return View();
        }
        public IActionResult AddMoto()
        {
            return View();
        }
        public IActionResult AccountClient()
        {
            return View();
        }
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
        public IActionResult RegButton_Click() 
        {
            return View("~/Views/Home/RegistrationWindow.cshtml");
        }
        public IActionResult AuthButton_Click()
        {
            return View("~/Views/Home/AuthorizationWindow.cshtml");
        }
        public IActionResult RegistrationWindow() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult RegistrationClient(string name,string tel,string password) 
        {
            foreach (var entity in _context.ChangeTracker.Entries())
            {
                if (entity.Entity != null)
                {
                    entity.Reload();
                }
            }
            if (name.Length != 0 && tel.Length != 0 && password.Length != 0)
            {
                //bool isUnique = !_context.Roles.Any(cli => cli.Name == name);
                bool isUnique = !_context.Clients.Any(cli => cli.Telephone == tel);
                if (isUnique)
                {
                    Clients newClient = new Clients
                    {
                        Fullname = name,
                        Telephone = tel
                    };
                    _context.Clients.Add(newClient);
                    _context.SaveChanges();
                    Clients newclient = _context.Clients.SingleOrDefault(cl => cl.Telephone == tel) ?? new Clients();
                    if (newclient != null)
                    {
                        Logining log = new Logining
                        {
                            Password = password,
                            IdRole = 1,
                            IdUser = newclient.IdClient
                        };
                        _context.Logining.Add(log);
                        _context.SaveChanges();
                    }

                }
            }
            return View("~/Views/Home/AuthorizationWindow.cshtml");
        }
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
            Logining user = _context.Logining.SingleOrDefault(user => user.Password == password ) ?? new Logining();
            if (user == null)
            {
                return View("~/Views/Home/Authorization.cshtml");
            }
            else { 
               if(user.IdRole == 1)
               {
                Clients loginClient = _context.Clients.SingleOrDefault(client => client.IdClient == user.IdLoginUser) ?? new Clients();
                    if (loginClient != null)
                    {
                        if (loginClient.Telephone == tel) 
                        {
                            return View("~/Views/Home/AccountClient.cshtml", loginClient);
                        }
                        
                    }
                    return View("~/Views/Home/Authorization.cshtml");
                }
               else
               {
                return View("~/View/Home/AccountMechanic.cshtml");
               }
            }

        }
    }
}