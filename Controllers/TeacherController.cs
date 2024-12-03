using Task1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Develpertask1.Controllers
{
    public class TeacherController : Controller
    {
        private readonly CipherFormContext _context;
        
        private readonly IWebHostEnvironment enve;
        public TeacherController(CipherFormContext context, IWebHostEnvironment enve)
        {

            _context = context;
            this.enve = enve;
        }

        
        [HttpGet]
        public IActionResult TeacherCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TeacherCreate(TeacherViewModal teacher)
        {
            string fileName = "";
            if (teacher.Photo != null)
            {
                var ext = Path.GetExtension(teacher.Photo.FileName);
                var size = teacher.Photo.Length;
                if (ext.Equals(".png") || ext.Equals(".jpg") || ext.Equals(".jpeg") && size <= 500000)
                {


                    string folder = Path.Combine(enve.WebRootPath, "TeacherImage");
                    fileName = Guid.NewGuid().ToString() + "_" + teacher.Photo.FileName;
                    string filepath = Path.Combine(folder, fileName);

                    teacher.Photo.CopyTo(new FileStream(filepath, FileMode.Create));

                    Teacher obj = new Teacher();
                    {
                        obj.TeacherName = teacher.TeacherName;
                        obj.Age = teacher.Age;
                       
                        obj.Gender = teacher.Gender;
                        obj.Image = fileName;

                    };
                    _context.Teachers.Add(obj);
                    _context.SaveChanges();
                    TempData["Success"] = "Student Details Successfully";
                    //return RedirectToAction("ListofStudent");
                }




                else
                {
                    TempData["Ext_Error"] = "Only jpg npj.ejpg allow";
                }


            }

            return View();


        }

        public IActionResult TeacherTable()
        {
            return View(_context.Teachers.ToList());
        }
    }
}