using JobWebApp.Data;
using JobWebApp.Models;
using JobWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace JobWebApp.Controllers
{
    public class JobOfferController : Controller
    {

        private readonly AppDbContext _context;

        public JobOfferController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<JobOffer> listJobOffers = _context.Job;

            foreach(var job in listJobOffers)
            {
                job.Position = _context.Position.FirstOrDefault(u => u.Id == job.IdType);                
            }
            return View(listJobOffers);
        }

        // Http Get Create
        public IActionResult Create()
        {
            JobOfferVM jobOfferVM = new JobOfferVM()
            {
                JobOffer = new JobOffer(),
                PositionDropDown = _context.Position.Select(i => new SelectListItem
                {
                    Text = i.PositionType,
                    Value = i.Id.ToString()
                })
            };

            return View(jobOfferVM);
        }

        // Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JobOfferVM job)
        {
            if (ModelState.IsValid)
            {
                job.JobOffer.ModWage = job.JobOffer.Wage * (1 + job.JobOffer.Contribution / 100);
                _context.Job.Add(job.JobOffer);
                _context.SaveChanges();

                TempData["message"] = "The Job Offer has been correctly registred.";
                return RedirectToAction("Index");
            }

            return View(job);
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

                TempData["message"] = "The Job record has been correctly updated.";
                return RedirectToAction("Index");
            }

            return View(job);
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
        public IActionResult DeleteJob(int? id, string checker)
        {
            // obter o job por id
            var job = _context.Job.Find(id);

            if (job == null)
            {
                return NotFound();
            }

            var check = job.Title.Substring(0, 6);
            if (checker == check)
            {
                _context.Job.Remove(job);
                _context.SaveChanges();
                TempData["message"] = "The record has been correctly removed.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "The validation failed. The text typed doesn't match. Type exactly the SIX first char of the job Title Name.";
                return RedirectToAction("Delete","JobOffer", new { @id = id });

            }
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
            job.Position = _context.Position.FirstOrDefault(u => u.Id == job.IdType);
            return View(job);
        }

        

    }
}
