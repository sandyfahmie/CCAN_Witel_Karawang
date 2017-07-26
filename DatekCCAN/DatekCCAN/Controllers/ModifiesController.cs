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
    public class ModifiesController : Controller
    {
        private readonly WitelContext _context;

        public ModifiesController(WitelContext context)
        {
            _context = context;    
        }

        // GET: Modifies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Modifys.ToListAsync());
        }

        // GET: Modifies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modify = await _context.Modifys
                .SingleOrDefaultAsync(m => m.ID2 == id);
            if (modify == null)
            {
                return NotFound();
            }

            return View(modify);
        }

        // GET: Modifies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modifies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID2,ServiceOrder2,SID2,TQ2,AO2,Name2,TglOrderItenos2,Alamat2,KomenItenos2,Pic2,AreaCode2,Metro2,Dat2,Gpon2,SN2,Vlan2,TglPerintahSurvei2,TglHasilSurvei2,TaggingPelanggan2,TeknisiSurvei2,TaggingODP2,TglPerintahPT12,TglSelesaiPTmin12,TeknisiPTmin12,TglPerintahJT2,TglJTSelesai2,Komen2,TglClosed2,Status2")] Modify modify)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modify);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(modify);
        }

        // GET: Modifies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modify = await _context.Modifys.SingleOrDefaultAsync(m => m.ID2 == id);
            if (modify == null)
            {
                return NotFound();
            }
            return View(modify);
        }

        // POST: Modifies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID2,ServiceOrder2,SID2,TQ2,AO2,Name2,TglOrderItenos2,Alamat2,KomenItenos2,Pic2,AreaCode2,Metro2,Dat2,Gpon2,SN2,Vlan2,TglPerintahSurvei2,TglHasilSurvei2,TaggingPelanggan2,TeknisiSurvei2,TaggingODP2,TglPerintahPT12,TglSelesaiPTmin12,TeknisiPTmin12,TglPerintahJT2,TglJTSelesai2,Komen2,TglClosed2,Status2")] Modify modify)
        {
            if (id != modify.ID2)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modify);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModifyExists(modify.ID2))
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
            return View(modify);
        }

        // GET: Modifies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modify = await _context.Modifys
                .SingleOrDefaultAsync(m => m.ID2 == id);
            if (modify == null)
            {
                return NotFound();
            }

            return View(modify);
        }

        // POST: Modifies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modify = await _context.Modifys.SingleOrDefaultAsync(m => m.ID2 == id);
            _context.Modifys.Remove(modify);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ModifyExists(int id)
        {
            return _context.Modifys.Any(e => e.ID2 == id);
        }
    }
}
