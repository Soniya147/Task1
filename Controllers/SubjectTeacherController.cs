using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Controllers
{
    public class SubjectTeacherController : Controller
    {
        private readonly CipherFormContext _context;

        public SubjectTeacherController(CipherFormContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> SubjectTeacher()
        {
            var subjectTeachers = await _context.SubjectTeachers
             .Include(st => st.Subject)
             .Include(st => st.Teacher)
             .ToListAsync();

            return View(subjectTeachers);
        }
        }
    }

