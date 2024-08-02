using Diplom_popitka1.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace Diplom_popitka1.Controllers
{
    public class ClientController : Controller
    {
        private readonly diplom_popitca1Context _context;
        public ClientController(diplom_popitca1Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RegButton_Click()
        {
            return View("~/Views/Client/RegistrationWindow.cshtml");
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
                    return View("~/Views/Home/AuthorizationWindow.cshtml");
                }

            }
            return View("~/Views/Client/RegistrationWindow.cshtml");
        }
        public IActionResult AccountClient(string mots)
        {
            var motsList = JsonConvert.DeserializeObject<List<MotorcyclesToClient>>(mots);
            return View(motsList);
        }
        public IActionResult AccountClient()
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
        public IActionResult DelMoto(int id)
        {
            var motorcycle = _context.MotorcyclesToClient.Find(id);
            if (motorcycle != null)
            {
                _context.MotorcyclesToClient.Remove(motorcycle);
                _context.SaveChanges();
            }
            var serializedClient = HttpContext.Session.GetString("ClientLogin");
            var loginClient = serializedClient != null ? JsonConvert.DeserializeObject<Clients>(serializedClient) : null;
            List<MotorcyclesToClient> mots = _context.MotorcyclesToClient
          .Where(m => m.IdClient == loginClient.IdClient)
          .ToList();
            ViewBag.name = loginClient.Fullname; ViewBag.tel = loginClient.Telephone;
            return View("~/Views/Home/AccountClient.cshtml", mots);
        }
        public IActionResult ThisMoto(int id)
        {
            //int id
            foreach (var entity in _context.ChangeTracker.Entries())
            {
                if (entity.Entity != null)
                {
                    entity.Reload();
                }
            }
            // int selectedId = int.Parse(Request.Form["data-id"]);
            MotorcyclesToClient moto = _context.MotorcyclesToClient.FirstOrDefault(m => m.IdMotoCl == id);
            var models = _context.TakeMotoToWork.ToList();
            HttpContext.Session.SetString("Motorcycles", Newtonsoft.Json.JsonConvert.SerializeObject(models));
            HttpContext.Session.SetString("ThisMotorcycle", Newtonsoft.Json.JsonConvert.SerializeObject(moto));
            return View("~/Views/Client/AddMoto.cshtml");
        }
        [HttpPost]
        public IActionResult EditMoto(string model, string year, int mileage, IFormFile photo)
        {
            var serializedThisMoto = HttpContext.Session.GetString("ThisMotorcycle");
            var mot = serializedThisMoto != null ? JsonConvert.DeserializeObject<MotorcyclesToClient>(serializedThisMoto) : null;
            var motClient = _context.MotorcyclesToClient.Find(mot.IdMotoCl);
            if (motClient != null)
            {
                if (photo != null)
                {
                    motClient.PhotoMoto = Photo(photo);
                }
                int yeare = DateTime.ParseExact(year, "yyyy", CultureInfo.InvariantCulture).Year;
                DateTime dateTime = new DateTime(yeare, 1, 1);
                if (model.Length != 0 && year.Length != 0 && mileage != 0)
                {
                    motClient.YearRelease = dateTime;
                    motClient.Mileage = mileage;
                    motClient.Model = model;
                }
                else
                {

                }
                _context.SaveChanges();
                var serializedClient = HttpContext.Session.GetString("ClientLogin");
                var loginClient = serializedClient != null ? JsonConvert.DeserializeObject<Clients>(serializedClient) : null;
                List<MotorcyclesToClient> mots = _context.MotorcyclesToClient
              .Where(m => m.IdClient == loginClient.IdClient)
              .ToList();
                ViewBag.name = loginClient.Fullname; ViewBag.tel = loginClient.Telephone;
                return View("~/Views/Client/AccountClient.cshtml", mots);
            }
            return View("~/Views/Client/AddMoto.cshtml");
        }
        [HttpPost]
        public IActionResult AddMoto(string model, string year, int mileage, IFormFile photo)
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
                return View("~/Views/Client/AccountClient.cshtml", mots);
            }
            else
            {
                return View();
            }

        }
        public IActionResult AddRequest()
        {

            foreach (var entity in _context.ChangeTracker.Entries())
            {
                if (entity.Entity != null)
                {
                    entity.Reload();
                }
            }
            var serializedClient = HttpContext.Session.GetString("ClientLogin");
            var loginClient = serializedClient != null ? JsonConvert.DeserializeObject<Clients>(serializedClient) : null;

            List<MotorcyclesToClient> mots = _context.MotorcyclesToClient
        .Where(m => m.IdClient == loginClient.IdClient)
        .ToList();
            HttpContext.Session.SetString("MyMotorcycles", Newtonsoft.Json.JsonConvert.SerializeObject(mots));
            List<Places> places = _context.Places.ToList();
            HttpContext.Session.SetString("PlacesOfFailure", Newtonsoft.Json.JsonConvert.SerializeObject(places));
            return View();
        }
        [HttpPost]
        public IActionResult AddRequest(MotorcyclesToClient mot, string problem, IFormFile photo, string selectedValues)
        {
            if (mot != null && problem.Length != 0)
            {
                RepairRequests repairRequests = new RepairRequests
                {
                    IdMotoCl = mot.IdMotoCl,
                    Status = "Принято в обработку",
                    Problem = problem,
                    Report = null,
                    Places = selectedValues,
                    Photo = Photo(photo),
                    IdMechanic = null
                };
                _context.RepairRequests.Add(repairRequests);
                _context.SaveChanges();
            }
            //string[] selectedValuesArray = selectedValues.Split(',');
            return View();
        }

    }
}
