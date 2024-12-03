
using Task1.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Task1.Controllers
{
    public class StudentController : Controller
    {
        private readonly CipherFormContext _context;
        private readonly IWebHostEnvironment enve;

        public StudentController(CipherFormContext context, IWebHostEnvironment enve)
        {
            _context = context;
            this.enve = enve;
        }


        [HttpGet]
        public IActionResult StudentCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StudentCreate(StudentViewModal student)
        {
            string fileName = "";
            if (student.Photo != null)
            {
                var ext = Path.GetExtension(student.Photo.FileName);
                var size = student.Photo.Length;
                if (ext.Equals(".png") || ext.Equals(".jpg") || ext.Equals(".jpeg") && size <= 500000)
                {


                    string folder = Path.Combine(enve.WebRootPath, "StudentImage");
                    fileName = Guid.NewGuid().ToString() + "_" + student.Photo.FileName;
                    string filepath = Path.Combine(folder, fileName);

                    student.Photo.CopyTo(new FileStream(filepath, FileMode.Create));

                    Student obj = new Student();
                    {
                        obj.StudentName = student.StudentName;
                        obj.Age = student.Age;
                        obj.Class = student.Class;
                        obj.RollNumber = student.RollNumber;
                        obj.Image = fileName;

                    };
                    _context.Students.Add(obj);
                    _context.SaveChanges();
                    TempData["Success"] = "Student Details Successfully";
                    return RedirectToAction("ListofStudent");
                }




                else
                {
                    TempData["Ext_Error"] = "Only jpg npj.ejpg allow";
                }
               

            }

            return View(student);
        }

        public IActionResult ListofStudent()
        {
            return View(_context.Students.ToList());
        }
    }
}