using Dal;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext context = new SchoolContext();

        // GET: Student
        // GET: Student/Index
        public ActionResult Index()
        {
            List<Student> model = this.context.Students.ToList();

            return View(model);
        }

        public ActionResult Photo(int studentid)
        {
            //string name2 = "img" + studentid + ".gif";
            //string name1 = string.Format("img{0}.gif", studentid);
            string name = $"img{studentid}.gif"; //interpolation 

            //string js = `img${studentid}.gif`;

            return File("C:\\man-portrait-silhouette.gif", "image/gif", name);
        }

        // GET: Student/Details/2
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = this.context.Students.Find(id);

            if(student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        //[Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if(ModelState.IsValid)
            {
                    this.context.Students.Add(student);
                    this.context.SaveChanges();

                    return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = this.context.Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                this.context.Entry(student).State = System.Data.Entity.EntityState.Modified;
                this.context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = this.context.Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = this.context.Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            this.context.Students.Remove(student);
            this.context.SaveChanges();

            return View(student);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                this.context.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}