using Task1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Develpertask1.Controllers
{
    public class SubjectsController : Controller
    {

        private readonly CipherFormContext _context;

        public SubjectsController(CipherFormContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IActionResult SubCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubCreate(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Subjects.Add(subject);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Subject Details Submit Successfully";
            }
            return View(subject);
        }

        public IActionResult SubjectTable()
        {
            return View(_context.Subjects.ToList());
        }

    }
}
