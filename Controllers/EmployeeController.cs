using SerializeXmlManipulation.Application_Class;
using SerializeXmlManipulation.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SerializeXmlManipulation.Controllers
{
    public class EmployeeController : Controller
    {
        private string path = ConfigurationManager.AppSettings["xmlPath"];

        public ActionResult Index()
        {
            var filePath = Server.MapPath(ConfigurationManager.AppSettings["xmlPath"]);
            using (var objDataRepo = new XMLRepository<Employee>(filePath))
            {              
              return View(objDataRepo.All().ToList());
            }           
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                using (var objDataRepo = new XMLRepository<Employee>(path))
                {
                    objDataRepo.Insert(employee);
                    objDataRepo.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            try
            {
                using (var objDataRepo = new XMLRepository<Employee>(path))
                {
                    //XElement xEmp = XElement.Load(path);
                    //var emp = from emps in xEmp.Elements("Employee")
                    //              where emps.Element("Name").Value.Equals(employee.Name)
                    //              select emps;

                    objDataRepo.Remove(employee);
                    objDataRepo.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
