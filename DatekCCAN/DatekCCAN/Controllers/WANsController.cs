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
    public class WANsController : Controller
    {
        private readonly WitelContext _context;

        public WANsController(WitelContext context)
        {
            _context = context;    
        }

        // GET: WANs
        public async Task<IActionResult> Index()
        {
            return View(await _context.WANs.ToListAsync());
        }

        // GET: WANs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wAN = await _context.WANs
                .SingleOrDefaultAsync(m => m.ID4 == id);
            if (wAN == null)
            {
                return NotFound();
            }

            return View(wAN);
        }

        // GET: WANs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WANs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID4,ServiceOrder4,SID4,TQ4,AO4,Name4,TglOrderItenos4,Alamat4,KomenItenos4,Pic4,AreaCode4,Metro4,Dat4,Gpon4,SN4,Vlan4,TglPerintahSurvei4,TglHasilSurvei4,TaggingPelanggan4,TeknisiSurvei4,TaggingODP4,TglPerintahPT14,TglSelesaiPTmin14,TeknisiPTmin14,TglPerintahJT4,TglJTSelesai4,Komen4,TglClosed4,Status4")] WAN wAN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wAN);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wAN);
        }

        // GET: WANs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wAN = await _context.WANs.SingleOrDefaultAsync(m => m.ID4 == id);
            if (wAN == null)
            {
                return NotFound();
            }
            return View(wAN);
        }

        // POST: WANs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID4,ServiceOrder4,SID4,TQ4,AO4,Name4,TglOrderItenos4,Alamat4,KomenItenos4,Pic4,AreaCode4,Metro4,Dat4,Gpon4,SN4,Vlan4,TglPerintahSurvei4,TglHasilSurvei4,TaggingPelanggan4,TeknisiSurvei4,TaggingODP4,TglPerintahPT14,TglSelesaiPTmin14,TeknisiPTmin14,TglPerintahJT4,TglJTSelesai4,Komen4,TglClosed4,Status4")] WAN wAN)
        {
            if (id != wAN.ID4)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wAN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WANExists(wAN.ID4))
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
            return View(wAN);
        }

        // GET: WANs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wAN = await _context.WANs
                .SingleOrDefaultAsync(m => m.ID4 == id);
            if (wAN == null)
            {
                return NotFound();
            }

            return View(wAN);
        }

        // POST: WANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wAN = await _context.WANs.SingleOrDefaultAsync(m => m.ID4 == id);
            _context.WANs.Remove(wAN);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WANExists(int id)
        {
            return _context.WANs.Any(e => e.ID4 == id);
        }
    }
}
