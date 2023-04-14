using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TutorialsTeacher_MVC.Models;

namespace TutorialsTeacher_MVC.Controllers
{
    public class StudentsController : Controller
    {
        public FileResult Śmindex()
        {
            var path = "./js/site.js";
            //return Content("<p>My string</p>");
            return File(path, "text/plain");
        }

        static IList<Student> studentList = new List<Student>{
                new Student() { StudentId = 1, StudentName = "John", Age = 18 , Gender = "Male", IsActive = true} ,
                new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
                new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
            };

        public IActionResult Edit(int id)
        {
            var student = studentList.FirstOrDefault(student => student.StudentId == id);

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var checkName = studentList.Any(stud => stud.StudentName == student.StudentName);

                if (checkName)
                {
                    ModelState.AddModelError("StudentName", "Name already exists");
                    return View(student);
                }

                var studentToChange = studentList.FirstOrDefault(stud => stud.StudentId == student.StudentId);
                studentList.Remove(studentToChange);
                studentList.Add(student);

                return RedirectToAction("Index");

            }
            return View(student);
        }


        public IActionResult Index()
        {
            return View(studentList);
        }

        [HttpPost]
        public void Index(string sth)
        {
            RedirectToAction("Index");
        }

    }
}
