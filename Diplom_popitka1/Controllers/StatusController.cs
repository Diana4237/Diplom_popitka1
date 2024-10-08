using Diplom_popitka1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diplom_popitka1.Controllers
{
    public class StatusController : Controller
    {
        public List<string> AllStatuses = new List<string>(new[] {
        "Диагностика",
        "Оценка стоимости",
        "Отправлено на утверждение клиентом",
        "Поиск запчастей",
        "Ремонт",
        "Тестирование",
        "Оплата",
        "Гарантия"
    });
        private readonly diplom_popitca1Context _context;
        public StatusController(diplom_popitca1Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChangeStatus(int id, string direction)
        {
            var request = _context.RepairRequests.Find(id);

            if (request == null)
            {
                return NotFound();
            }

            // Получить текущий индекс статуса в массиве
            int currentIndex = AllStatuses.IndexOf(request.Status);

            // Определить направление изменения статуса
            var newIndex = direction switch
            {
                "forward" => currentIndex + 1,
                "backward" => currentIndex - 1,
                _ => currentIndex
            };

            // Убедиться, что новый индекс находится в пределах допустимого диапазона
            if (newIndex < 0 || newIndex >= AllStatuses.Count)
            {
                return BadRequest();
            }

            // Обновить текущий статус заявки
            request.Status = AllStatuses[newIndex];
            _context.SaveChanges();

            return RedirectToAction("MyRequests", "Mechanic"); // Возвращаем пользователя обратно на страницу со списком заявок
        }
    }
}
