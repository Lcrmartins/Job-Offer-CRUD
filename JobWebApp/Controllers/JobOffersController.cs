using JobWebApp.Data;
using JobWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobWebApp.Controllers
{
    public class JobOffersController : Controller
    {

        private readonly AppDbContext _context;

        public JobOffersController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<JobOffer> listJobOffers = _context.Job;
            return View(listJobOffers);
        }

        // Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        // Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JobOffer job)
        {
            if (ModelState.IsValid)
            {
                _context.Job.Add(job);
                _context.SaveChanges();

                TempData["message"] = "The Job Offer has been correctly registred.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Http Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtain the Job
            var job = _context.Job.Find(id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(JobOffer job)
        {
            if (ModelState.IsValid)
            {
                _context.Job.Update(job);
                _context.SaveChanges();

                TempData["message"] = "The book has been correctly updated.";
                return RedirectToAction("Index");
            }

            return View();
        }
        // Http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtain the Job
            var job = _context.Job.Find(id);

            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteJob(int? id)
        {
            // obter o job por id
            var job = _context.Job.Find(id);

            if (job == null)
            {
                return NotFound();
            }
            _context.Job.Remove(job);
            _context.SaveChanges();

            TempData["message"] = "The record has been correctly removed.";
            return RedirectToAction("Index");
        }
        
        // Http Get Detail
        public IActionResult Detail(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtain the job
            var job = _context.Job.Find(id);

            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // Http Get Detail-Temp
        public IActionResult DetailTemp(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtain the job
            var job = _context.Job.Find(id);

            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }



    }
}
