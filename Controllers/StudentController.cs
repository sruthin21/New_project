using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NewProject2.Models;
using System.Collections.Generic;
using System.Linq;

namespace NewProject2.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        [HttpPost]
        public IActionResult Create(List<Student> students)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var student in students)
                    {
                        _context.Students.Add(student);
                    }
                    _context.SaveChanges();
                    return RedirectToAction("Index"); // Redirect to the Index action after saving
                }
                catch (DbUpdateException ex)
                {
                    // Check if the exception is due to a duplicate key violation
                    if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
                    {
                        ModelState.AddModelError(string.Empty, "A record with the same SubjectName already exists.");
                    }
                    else
                    {
                        // Rethrow other types of DbUpdateException
                        throw;
                    }
                }
            }
            // If the model state is not valid or there was a duplicate key violation, return to the same view with validation errors
            return View(students);
        }
    }
}
