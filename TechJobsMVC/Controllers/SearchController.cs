using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.jobs = new List<Job>();
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 
        [HttpPost]
        public IActionResult Results(string searchTerm, string searchType)
        {
            List<Job> jobs;
            if (searchTerm == null)
            {
                //ViewBag.jobs = new List<Job>();
                jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
            }
            else
            {
                //ViewBag.jobs = new List<Job>();
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.columns = ListController.ColumnChoices;
                return View("Index");
            }
            ViewBag.jobs = jobs;

            return View();
        }
    }
}