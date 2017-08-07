using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore.JsonpResult;
using MVCMusicStore.Models;

namespace MVCMusicStore.Controllers
{
    public class StudentController : Controller
    {
        private WSEntities _context;

        public StudentController()
        {
            _context = new WSEntities();
        }
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Read()
        {
            var studentList = _context.Students.ToList();
            return this.Jsonp(studentList);
        }

        public JsonResult Create()
        {
            //parse student ra từ key model
            var students = this.DeserializeObject<IEnumerable<Student>>("models");
            if (students != null)
            {
                foreach (var student in students)
                {
                    _context.Students.Add(student);
                }
                _context.SaveChanges();

            }
            return this.Jsonp(students);
        }

        public JsonResult Update()
        {
            var models = this.DeserializeObject<IEnumerable<Student>>("models");
            if (models != null)
            {
                foreach (var model in models)
                {
                    var student = _context.Students.Find(model.Id);
                    if (student != null)
                    {
                        student.Name = model.Name;
                        student.Attendance = model.Attendance;
                        student.Course = model.Course;
                        student.Semester = model.Semester;
                        _context.Entry(student).State =EntityState.Modified;
                        _context.SaveChanges();
                    }
                }
            }
            return this.Jsonp(models);
        }

        public JsonResult Destroy()
        {
            var students = this.DeserializeObject<IEnumerable<Student>>("models");
            if (students != null)
            {
                foreach (var model in students)
                {
                    var student = _context.Students.Find(model.Id);
                    if (student != null)
                    {
                        _context.Students.Remove(student);
                        _context.SaveChanges();
                    }
                }
            }
            return this.Jsonp(students);
        }
    }
}