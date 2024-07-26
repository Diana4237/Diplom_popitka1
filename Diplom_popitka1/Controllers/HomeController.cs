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
            foreach (var entity in _context.ChangeTracker.Entries())
            {
                if (entity.Entity != null)
                {
                    entity.Reload();
                }
            }
            var models = _context.TakeMotoToWork.ToList();
            HttpContext.Session.SetString("Motorcycles", Newtonsoft.Json.JsonConvert.SerializeObject(models));
            return View();
        }
        public IActionResult ThisMoto(int id)
        {
            foreach (var entity in _context.ChangeTracker.Entries())
            {
                if (entity.Entity != null)
                {
                    entity.Reload();
                }
            }
            MotorcyclesToClient moto = _context.MotorcyclesToClient.FirstOrDefault(m => m.IdMotoCl == id);
            var models = _context.TakeMotoToWork.ToList();
            HttpContext.Session.SetString("Motorcycles", Newtonsoft.Json.JsonConvert.SerializeObject(models));
            HttpContext.Session.SetString("ThisMotorcycle", Newtonsoft.Json.JsonConvert.SerializeObject(moto));
            return View("~/Views/Home/AddMoto.cshtml");
        }
        [HttpPost]
        public IActionResult EditMoto(string model, string year, int mileage, IFormFile photo)
        {
            var serializedThisMoto = HttpContext.Session.GetString("ThisMotorcycle");
            var mot = serializedThisMoto != null ? JsonConvert.DeserializeObject<MotorcyclesToClient>(serializedThisMoto) : null;
            if (photo != null) { 
            mot.PhotoMoto = Photo(photo);
            }
            int yeare = DateTime.ParseExact(year, "yyyy", CultureInfo.InvariantCulture).Year;
            DateTime dateTime = new DateTime(yeare, 1, 1);
            if (model.Length != 0 && year.Length != 0 && mileage != 0) 
            {
                mot.YearRelease = dateTime;
                mot.Mileage=mileage;
                mot.Model= model;
            }
            _context.SaveChanges();
            var serializedClient = HttpContext.Session.GetString("ClientLogin");
            var loginClient = serializedClient != null ? JsonConvert.DeserializeObject<Clients>(serializedClient) : null;
            List<MotorcyclesToClient> mots = _context.MotorcyclesToClient
          .Where(m => m.IdClient == loginClient.IdClient)
          .ToList();
            ViewBag.name = loginClient.Fullname; ViewBag.tel = loginClient.Telephone;
            return View("~/Views/Home/AccountClient.cshtml", mots);
        }
            [HttpPost]
        public IActionResult AddMoto(string model,string year,int mileage, IFormFile photo)
        {
            var serializedClient = HttpContext.Session.GetString("ClientLogin");
            var loginClient = serializedClient != null ? JsonConvert.DeserializeObject<Clients>(serializedClient) : null;
            if (photo != null && model.Length != 0 && year.Length != 0 && mileage != 0)
            {
                int yeare = DateTime.ParseExact(year, "yyyy", CultureInfo.InvariantCulture).Year;
                DateTime dateTime = new DateTime(yeare, 1, 1);
                MotorcyclesToClient motCl = new MotorcyclesToClient
                {
                    IdClient = loginClient.IdClient,
                    Model = model,
                    YearRelease = dateTime,
                    Mileage = mileage,
                    PhotoMoto = Photo(photo)

                };
                _context.MotorcyclesToClient.Add(motCl);
                _context.SaveChanges();
                List<MotorcyclesToClient> mots = _context.MotorcyclesToClient
          .Where(m => m.IdClient == loginClient.IdClient)
          .ToList();
                ViewBag.name = loginClient.Fullname; ViewBag.tel = loginClient.Telephone;
                // mymodel.MotocycleToClient = mots;
                return View("~/Views/Home/AccountClient.cshtml", mots);
            }
            else 
            {
                return View();
            }
           
        }
        public byte[] Photo(IFormFile phot)
        {
            using (var target = new MemoryStream())
            {
                phot.CopyTo(target);
                return target.ToArray();
            }
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
        public IActionResult RegistrationClient(string name, string tel, string password)
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
            Logining user = _context.Logining.SingleOrDefault(user => user.Password == password) ?? new Logining();
            if (user == null)
            {
                return View("~/Views/Home/Authorization.cshtml");
            }
            else
            {
                if (user.IdRole == 1)
                {
                    Clients loginClient = _context.Clients.SingleOrDefault(client => client.IdClient == user.IdLoginUser ) ?? new Clients();
                    if (loginClient != null)
                    {
                        if (loginClient.Telephone == tel)
                        {
                            HttpContext.Session.SetString("ClientLogin", Newtonsoft.Json.JsonConvert.SerializeObject(loginClient));
                            
                            List<MotorcyclesToClient> mots = _context.MotorcyclesToClient
            .Where(m => m.IdClient == loginClient.IdClient)
            .ToList();
                            ViewBag.name = loginClient.Fullname; ViewBag.tel = tel;
                            // mymodel.MotocycleToClient = mots;
                            return View("~/Views/Home/AccountClient.cshtml", mots);
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