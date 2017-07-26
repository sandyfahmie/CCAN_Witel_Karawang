using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatekCCAN.Data;
using DatekCCAN.Models;

namespace DatekCCAN.Controllers
{
    public class DeletesController : Controller
    {
        private readonly WitelContext _context;

        public DeletesController(WitelContext context)
        {
            _context = context;    
        }

        // GET: Deletes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deletes.ToListAsync());
        }

        // GET: Deletes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delete = await _context.Deletes
             .Include(s => s.Enrollments)
             .ThenInclude(e => e.Course)
             .AsNoTracking()
             .SingleOrDefaultAsync(m => m.ID1 == id);
            if (delete == null)
            {
                return NotFound();
            }

            return View(delete);
        }

        // GET: Deletes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deletes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceOrder1,SID1,TQ1,AO1,Name1,TglOrderItenos1,Alamat1,KomenItenos1,Pic1,AreaCode1,Metro1,Dat1,Gpon1,SN1,Vlan1,TglPerintahSurvei1,TglHasilSurvei1,TaggingPelanggan1,TeknisiSurvei1,TaggingODP1,TglPerintahPT11,TglSelesaiPTmin11,TeknisiPTmin11,TglPerintahJT1,TglJTSelesai1,Komen1,TglClosed1,Status1")] Delete delete)
        {
            try
            {
                if (ModelState.IsValid)
                {
                _context.Add(delete);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(delete);
        }

        // GET: Deletes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delete = await _context.Deletes.SingleOrDefaultAsync(m => m.ID1 == id);
            if (delete == null)
            {
                return NotFound();
            }
            return View(delete);
        }

        // POST: Deletes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID1,ServiceOrder1,SID1,TQ1,AO1,Name1,TglOrderItenos1,Alamat1,KomenItenos1,Pic1,AreaCode1,Metro1,Dat1,Gpon1,SN1,Vlan1,TglPerintahSurvei1,TglHasilSurvei1,TaggingPelanggan1,TeknisiSurvei1,TaggingODP1,TglPerintahPT11,TglSelesaiPTmin11,TeknisiPTmin11,TglPerintahJT1,TglJTSelesai1,Komen1,TglClosed1,Status1")] Delete delete)
        {
            if (id != delete.ID1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(delete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeleteExists(delete.ID1))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(delete);
        }

        // GET: Deletes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delete = await _context.Deletes
                .SingleOrDefaultAsync(m => m.ID1 == id);
            if (delete == null)
            {
                return NotFound();
            }

            return View(delete);
        }

        // POST: Deletes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delete = await _context.Deletes.SingleOrDefaultAsync(m => m.ID1 == id);
            _context.Deletes.Remove(delete);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DeleteExists(int id)
        {
            return _context.Deletes.Any(e => e.ID1 == id);
        }
    }
}
