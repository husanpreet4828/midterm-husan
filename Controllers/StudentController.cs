using Microsoft.AspNetCore.Mvc;
using _200596751_Exam.Models;  // Update namespace
using System.Collections.Generic;
using System.Linq;

namespace _23300_Midterm.Controllers  // Update namespace
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, FirstName = "Husanpreet", LastName = "Kaur", EmailAddress = "husan28@gmail.com" },
            new Student { StudentId = 2, FirstName = "Jashandeep", LastName = "Singh", EmailAddress = null }
        };

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.StudentId = students.Count + 1;
                students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student updatedStudent)
        {
            if (ModelState.IsValid)
            {
                var student = students.FirstOrDefault(s => s.StudentId == id);
                if (student != null)
                {
                    student.FirstName = updatedStudent.FirstName;
                    student.LastName = updatedStudent.LastName;
                    student.EmailAddress = updatedStudent.EmailAddress;
                }
                return RedirectToAction("Index");
            }
            return View(updatedStudent);
        }

        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                students.Remove(student);
            }
            return RedirectToAction("Index");
        }
    }
}
