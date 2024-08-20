using Diplom_popitka1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;

namespace Diplom_popitka1.Controllers
{
    public class MechanicController : Controller
    {
        private readonly diplom_popitca1Context _context;
        public MechanicController(diplom_popitca1Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MyRequests()
        {
            List<MotorcyclesToClient> mots = _context.MotorcyclesToClient
     .ToList();
            var motoClIds = mots.Select(m => m.IdMotoCl).ToList();
            var serializedMechanic = HttpContext.Session.GetString("MechanicLogin");
            var loginMechanic = serializedMechanic != null ? JsonConvert.DeserializeObject<Mechanics>(serializedMechanic) : null;
            List<RepairRequests> requests = _context.RepairRequests
       .Where(m => m.IdMechanic == loginMechanic.IdMechanic && motoClIds.Contains((int)m.IdMotoCl))
       .ToList();
            var repairRequestsView = requests.Select(r => new RepairRequestsView
            {
                IdRequest = r.IdRequest,
                nameMotoCl = r.IdMotoClNavigation?.Model, // Убедитесь, что у вас есть свойство Name в MotorcyclesToClient
                nameCl = r.IdMotoClNavigation != null ? _context.Clients.Where(c => c.IdClient ==
                r.IdMotoClNavigation.IdClient).Select(c => c.Fullname).FirstOrDefault() : null,
                Status = r.Status,
                Problem = r.Problem,
                Report = r.Report,
                Places = r.Places,
                Photo = r.Photo,
                nameMechanic = r.IdMechanic,
                DateRequest = r.DateRequest,
                DateRequestEnd = r.DateRequestEnd
            }).ToList();
            return View(repairRequestsView);
        }
        public IActionResult UpdateMyRequest() 
        {
            return View("~/Views/Mechanic/MyRequests.cshtml");
        }

        public IActionResult NewRequests()
        {
            List<MotorcyclesToClient> mots = _context.MotorcyclesToClient
      .ToList();
            var motoClIds = mots.Select(m => m.IdMotoCl).ToList();
            List<RepairRequests> requests = _context.RepairRequests
       .Where(r => r.Status=="Принято в обработку"&& motoClIds.Contains((int)r.IdMotoCl))
       .Include(r => r.IdMotoClNavigation)
       .ToList();

            var repairRequestsView = requests.Select(r => new RepairRequestsView
            {
                IdRequest = r.IdRequest,
                nameMotoCl = r.IdMotoClNavigation?.Model, // Убедитесь, что у вас есть свойство Name в MotorcyclesToClient
                nameCl = r.IdMotoClNavigation != null ? _context.Clients.Where(c => c.IdClient ==
                r.IdMotoClNavigation.IdClient).Select(c => c.Fullname).FirstOrDefault() : null,
            Status = r.Status,
                Problem = r.Problem,
                Report = r.Report,
                Places = r.Places,
                Photo = r.Photo,
                nameMechanic = r.IdMechanic,
                DateRequest = r.DateRequest,
                DateRequestEnd = r.DateRequestEnd
            }).ToList();
            return View(repairRequestsView);
        }
        public IActionResult AddInMyRequest(int requestId) 
        {
           RepairRequests request= _context.RepairRequests.Find(requestId);
            if (request != null) { 
            var serializedMechanic = HttpContext.Session.GetString("MechanicLogin");
            var loginMechanic = serializedMechanic != null ? JsonConvert.DeserializeObject<Mechanics>(serializedMechanic) : null;
            request.IdMechanic = loginMechanic.IdMechanic;
            request.Status = "Диагностика";
            request.DateRequest = DateTime.Now;
            _context.SaveChanges();
            }
            return View("~/Views/Mechanic/MyRequests.cshtml");
        }
        //public IActionResult SaveNote() { }
        public IActionResult AccountMechanic()
        {
            foreach (var entity in _context.ChangeTracker.Entries())
            {
                if (entity.Entity != null)
                {
                    entity.Reload();
                }
            }
            var serializedMechanic = HttpContext.Session.GetString("MechanicLogin");
            var loginMechanic = serializedMechanic != null ? JsonConvert.DeserializeObject<Mechanics>(serializedMechanic) : null;
            var requests = _context.RepairRequests
         .Where(m => m.IdMechanic == loginMechanic.IdMechanic)
          .Select(r => new ViewMechanicAccount
          {
              ModelMotoCl = _context.MotorcyclesToClient.Where(m => m.IdMotoCl == r.IdMotoCl).Select(m => m.Model).FirstOrDefault()
          })
         .ToList();
            ViewBag.name = loginMechanic.Fullname; ViewBag.tel = loginMechanic.Telephone;
            return View(requests);
        }




        [HttpPost]
        public IActionResult RequestsInThisDay(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                // Логирование или отладочный вывод
                return BadRequest("Дата не была передана или она пуста.");
            }
            DateTime selectedDateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime dateSelect;

            // Определяем формат строки даты
            string dateFormat = "dd-MM-yyyy";

            // Преобразуем строку в DateTime
           
                var serializedMechanic = HttpContext.Session.GetString("MechanicLogin");
            var loginMechanic = serializedMechanic != null ? JsonConvert.DeserializeObject<Mechanics>(serializedMechanic) : null;

            ViewBag.name = loginMechanic?.Fullname;
            ViewBag.tel = loginMechanic?.Telephone;
            if (DateTime.TryParseExact(date, dateFormat, null, System.Globalization.DateTimeStyles.None, out dateSelect))
            {
                List<RepairRequests> repairRequestsToday = _context.RepairRequests
                .Where(r => r.IdMechanic == loginMechanic.IdMechanic && r.DateRequest.HasValue && r.DateRequest.Value.Date == dateSelect.Date)
                .ToList();
            
            return View("~/Views/Mechanic/AccountMechanic.cshtml", repairRequestsToday);  // Use a partial view to render the result
            }
            else { 
            return View("~/Views/Mechanic/AccountMechanic.cshtml");
            }
        }
        // [HttpPost]
        // public IActionResult RequestsInThisDay([FromBody] DateTime date)
        // {
        //     ViewBag.dateSelected = "fgh" + date;
        //     var serializedMechanic = HttpContext.Session.GetString("MechanicLogin");
        //     var loginMechanic = serializedMechanic != null ? JsonConvert.DeserializeObject<Mechanics>(serializedMechanic) : null;
        //     ViewBag.name = loginMechanic.Fullname; ViewBag.tel = loginMechanic.Telephone;
        //     List<RepairRequests> repairRequestsToday = _context.RepairRequests
        //.Where(r => r.IdMechanic == loginMechanic.IdMechanic && r.DateRequest.HasValue && r.DateRequest.Value.Date == date.Date)
        //.ToList();
        //     return View("~/Views/Mechanic/AccountMechanic.cshtml", repairRequestsToday);
        // }
    }
}
