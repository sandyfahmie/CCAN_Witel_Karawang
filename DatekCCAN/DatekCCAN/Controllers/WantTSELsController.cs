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
    public class WantTSELsController : Controller
    {
        private readonly WitelContext _context;

        public WantTSELsController(WitelContext context)
        {
            _context = context;    
        }

        // GET: WantTSELs
        public async Task<IActionResult> Index()
        {
            return View(await _context.WantTSELs.ToListAsync());
        }

        // GET: WantTSELs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wantTSEL = await _context.WantTSELs
                .SingleOrDefaultAsync(m => m.ID3 == id);
            if (wantTSEL == null)
            {
                return NotFound();
            }

            return View(wantTSEL);
        }

        // GET: WantTSELs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WantTSELs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID3,ServiceOrder3,SID3,TQ3,AO3,Name3,TglOrderItenos3,Alamat3,KomenItenos3,Pic3,AreaCode3,Metro3,Dat3,Gpon3,SN3,Vlan3,TglPerintahSurvei3,TglHasilSurvei3,TaggingPelanggan3,TeknisiSurvei3,TaggingODP3,TglPerintahPT13,TglSelesaiPTmin13,TeknisiPTmin13,TglPerintahJT3,TglJTSelesai3,Komen3,TglClosed3,Status3,SiteID,Long,Lat")] WantTSEL wantTSEL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wantTSEL);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wantTSEL);
        }

        // GET: WantTSELs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wantTSEL = await _context.WantTSELs.SingleOrDefaultAsync(m => m.ID3 == id);
            if (wantTSEL == null)
            {
                return NotFound();
            }
            return View(wantTSEL);
        }

        // POST: WantTSELs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID3,ServiceOrder3,SID3,TQ3,AO3,Name3,TglOrderItenos3,Alamat3,KomenItenos3,Pic3,AreaCode3,Metro3,Dat3,Gpon3,SN3,Vlan3,TglPerintahSurvei3,TglHasilSurvei3,TaggingPelanggan3,TeknisiSurvei3,TaggingODP3,TglPerintahPT13,TglSelesaiPTmin13,TeknisiPTmin13,TglPerintahJT3,TglJTSelesai3,Komen3,TglClosed3,Status3,SiteID,Long,Lat")] WantTSEL wantTSEL)
        {
            if (id != wantTSEL.ID3)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wantTSEL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WantTSELExists(wantTSEL.ID3))
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
            return View(wantTSEL);
        }

        // GET: WantTSELs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wantTSEL = await _context.WantTSELs
                .SingleOrDefaultAsync(m => m.ID3 == id);
            if (wantTSEL == null)
            {
                return NotFound();
            }

            return View(wantTSEL);
        }

        // POST: WantTSELs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wantTSEL = await _context.WantTSELs.SingleOrDefaultAsync(m => m.ID3 == id);
            _context.WantTSELs.Remove(wantTSEL);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WantTSELExists(int id)
        {
            return _context.WantTSELs.Any(e => e.ID3 == id);
        }
    }
}
