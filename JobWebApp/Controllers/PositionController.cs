using JobWebApp.Data;
using JobWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JobWebApp.Controllers
{
    public class PositionController : Controller
    {
        private readonly AppDbContext _context;

        public PositionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Positions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Position.ToListAsync());
        }

        // GET: Positions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Position
                .FirstOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // GET: Position/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Position/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Position position)
        {
            if (ModelState.IsValid)
            {
                _context.Add(position);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        // GET: Positions/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var position = _context.Position.Find(id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }

        // POST: Positions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Position position)
        {
            if (ModelState.IsValid)
            {
                _context.Update(position);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        // GET: Positions/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var position = _context.Position
                .FirstOrDefault(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var position = _context.Position.Find(id);
            if(position == null)
            {
                return NotFound();
            }
            _context.Position.Remove(position);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //private bool PositionExists(int id)
        //{
        //    return _context.Position.Any(e => e.Id == id);
        //}
    }
}
