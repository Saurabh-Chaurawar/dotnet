using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBindingWithDb.Models;
using System.Collections.Generic;

namespace Products.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext dbObj;
        public EmployeesController(ApplicationDbContext db){
            dbObj=db;
        }
        // GET: EmployeesController
        public ActionResult Index()
        {
            var EmpList=dbObj.Employees.ToList();
            return View(EmpList);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            var Emp = dbObj.Employees.Find(id);
            return View(Emp);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee obj)
        {
            try
            {
                dbObj.Employees.Add(obj);
                dbObj.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int? id)
        {
           if (id == null)
                return NotFound();
            var Emp = dbObj.Employees.Find(id);
            return View(Emp);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee obj)
        {
            try
            {
                dbObj.Employees.Update(obj);
                dbObj.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }
    

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var Emp = dbObj.Employees.Find(id);
            return View(Emp);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee obj)
        {
            try
            {
                var Emp = dbObj.Employees.Find(id);
                dbObj.Employees.Remove(Emp);
                dbObj.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
