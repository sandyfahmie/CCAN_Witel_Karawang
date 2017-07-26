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
    public class CCANsController : Controller
    {
        private readonly WitelContext _context;

        public CCANsController(WitelContext context)
        {
            _context = context;    
        }

        // GET: CCANs
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var ccans = from s in _context.CCANs
                         select s;
            // Searching
            if (!String.IsNullOrEmpty(searchString))
            {
                ccans = ccans.Where(s => s.Name5.Contains(searchString)
                                        || s.Alamat5.Contains(searchString)
                                        || s.AO5.Contains(searchString)
                                        || s.AreaCode5.Contains(searchString)
                                        || s.Dat5.Contains(searchString)
                                        || s.Gpon5.Contains(searchString)
                                        || s.Komen5.Contains(searchString)
                                        || s.KomenItenos5.Contains(searchString)
                                        || s.Metro5.Contains(searchString)
                                        || s.Pic5.Contains(searchString)
                                        || s.SID5.Contains(searchString)
                                        || s.SN5.Contains(searchString)
                                        || s.Status5.Contains(searchString)
                                        || s.ServiceOrder5.Contains(searchString)
                                        || s.TaggingODP5.Contains(searchString)
                                        || s.TaggingPelanggan5.Contains(searchString)
                                        || s.TeknisiPTmin15.Contains(searchString)
                                        || s.TeknisiSurvei5.Contains(searchString)
                                        || s.TQ5.Contains(searchString)
                                        || s.Vlan5.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "ServiceOrder":
                    ccans = ccans.OrderBy(s => s.ServiceOrder5);
                    break;
                case "ServiceOrder_desc":
                    ccans = ccans.OrderByDescending(s => s.ServiceOrder5);
                    break;
                case "SID":
                    ccans = ccans.OrderBy(s => s.SID5);
                    break;
                case "SID_desc":
                    ccans = ccans.OrderByDescending(s => s.SID5);
                    break;
                case "TQ":
                    ccans = ccans.OrderBy(s => s.TQ5);
                    break;
                case "TQ_desc":
                    ccans = ccans.OrderByDescending(s => s.TQ5);
                    break;
                case "AO":
                    ccans = ccans.OrderBy(s => s.AO5);
                    break;
                case "AO_desc":
                    ccans = ccans.OrderByDescending(s => s.AO5);
                    break;
                case "name_desc":
                    ccans = ccans.OrderByDescending(s => s.Name5);
                    break;
                case "Date":
                    ccans = ccans.OrderBy(s => s.TglOrderItenos5);
                    break;
                case "date_desc":
                    ccans = ccans.OrderByDescending(s => s.TglOrderItenos5);
                    break;
                case "Alamat":
                    ccans = ccans.OrderBy(s => s.Alamat5);
                    break;
                case "Alamat_desc":
                    ccans = ccans.OrderByDescending(s => s.Alamat5);
                    break;
                case "KomenItenos":
                    ccans = ccans.OrderBy(s => s.KomenItenos5);
                    break;
                case "KomenItenos_desc":
                    ccans = ccans.OrderByDescending(s => s.KomenItenos5);
                    break;
                case "Pic":
                    ccans = ccans.OrderBy(s => s.Pic5);
                    break;
                case "Pic_desc":
                    ccans = ccans.OrderByDescending(s => s.Pic5);
                    break;
                case "AreaCode":
                    ccans = ccans.OrderBy(s => s.AreaCode5);
                    break;
                case "AreaCode_desc":
                    ccans = ccans.OrderByDescending(s => s.AreaCode5);
                    break;
                case "Metro":
                    ccans = ccans.OrderBy(s => s.Metro5);
                    break;
                case "Metro_desc":
                    ccans = ccans.OrderByDescending(s => s.Metro5);
                    break;
                case "Datek":
                    ccans = ccans.OrderBy(s => s.Dat5);
                    break;
                case "Datek_desc":
                    ccans = ccans.OrderByDescending(s => s.Dat5);
                    break;
                case "Gpon":
                    ccans = ccans.OrderBy(s => s.Gpon5);
                    break;
                case "Gpon_desc":
                    ccans = ccans.OrderByDescending(s => s.Gpon5);
                    break;
                case "SN":
                    ccans = ccans.OrderBy(s => s.SN5);
                    break;
                case "SN_desc":
                    ccans = ccans.OrderByDescending(s => s.SN5);
                    break;
                case "Vlan":
                    ccans = ccans.OrderBy(s => s.Vlan5);
                    break;
                case "Vlan_desc":
                    ccans = ccans.OrderByDescending(s => s.Vlan5);
                    break;
                case "TglPerintahSurvei":
                    ccans = ccans.OrderBy(s => s.TglPerintahSurvei5);
                    break;
                case "TglPerintahSurvei_desc":
                    ccans = ccans.OrderByDescending(s => s.TglPerintahSurvei5);
                    break;
                case "TglHasilSurvei":
                    ccans = ccans.OrderBy(s => s.TglHasilSurvei5);
                    break;
                case "TglHasilSurvei_desc":
                    ccans = ccans.OrderByDescending(s => s.TglHasilSurvei5);
                    break;
                case "TaggingPelanggan":
                    ccans = ccans.OrderBy(s => s.TaggingPelanggan5);
                    break;
                case "TaggingPelanggan_desc":
                    ccans = ccans.OrderByDescending(s => s.TaggingPelanggan5);
                    break;
                case "TeknisiSurvei":
                    ccans = ccans.OrderBy(s => s.TeknisiSurvei5);
                    break;
                case "TeknisiSurvei_desc":
                    ccans = ccans.OrderByDescending(s => s.TeknisiSurvei5);
                    break;
                case "TaggingODP":
                    ccans = ccans.OrderBy(s => s.TaggingPelanggan5);
                    break;
                case "TaggingODP_desc":
                    ccans = ccans.OrderByDescending(s => s.TaggingODP5);
                    break;
                case "TglPerintahPT1":
                    ccans = ccans.OrderBy(s => s.TglPerintahPT15);
                    break;
                case "TglPerintahPT1_desc":
                    ccans = ccans.OrderByDescending(s => s.TglPerintahPT15);
                    break;
                case "TglSelesaiPT-1":
                    ccans = ccans.OrderBy(s => s.TglSelesaiPTmin15);
                    break;
                case "TglSelesaiPT-1_desc":
                    ccans = ccans.OrderByDescending(s => s.TglSelesaiPTmin15);
                    break;
                case "TeknisiPT-1":
                    ccans = ccans.OrderBy(s => s.TeknisiPTmin15);
                    break;
                case "TeknisiPT-1_desc":
                    ccans = ccans.OrderByDescending(s => s.TeknisiPTmin15);
                    break;
                case "TglPerintahJT":
                    ccans = ccans.OrderBy(s => s.TglPerintahJT5);
                    break;
                case "TglPerintahJT_desc":
                    ccans = ccans.OrderByDescending(s => s.TglPerintahJT5);
                    break;
                case "TglJTSelesai":
                    ccans = ccans.OrderBy(s => s.TglJTSelesai5);
                    break;
                case "TglJTSelesai_desc":
                    ccans = ccans.OrderByDescending(s => s.TglJTSelesai5);
                    break;
                case "Komen":
                    ccans = ccans.OrderBy(s => s.Komen5);
                    break;
                case "Komen_desc":
                    ccans = ccans.OrderByDescending(s => s.Komen5);
                    break;
                case "TglClosed":
                    ccans = ccans.OrderBy(s => s.TglClosed5);
                    break;
                case "TglClosed_desc":
                    ccans = ccans.OrderByDescending(s => s.TglClosed5);
                    break;
                case "Status":
                    ccans = ccans.OrderBy(s => s.Status5);
                    break;
                case "Status_desc":
                    ccans = ccans.OrderByDescending(s => s.Status5);
                    break;
                default:
                    ccans = ccans.OrderBy(s => s.Name5);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<CCAN>.CreateAsync(ccans.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: CCANs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ccan = await _context.CCANs
              .Include(s => s.Enrollments)
              .ThenInclude(e => e.Course)
              .AsNoTracking()
              .SingleOrDefaultAsync(m => m.ID5 == id);
            if (ccan == null)
            {
                return NotFound();
            }

            return View(ccan);
        }

        // GET: CCANs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CCANs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID5,ServiceOrder5,SID5,TQ5,AO5,Name5,TglOrderItenos5,Alamat5,KomenItenos5,Pic5,AreaCode5,Metro5,Dat5,Gpon5,SN5,Vlan5,TglPerintahSurvei5,TglHasilSurvei5,TaggingPelanggan5,TeknisiSurvei5,TaggingODP5,TglPerintahPT15,TglSelesaiPTmin15,TeknisiPTmin15,TglPerintahJT5,TglJTSelesai5,Komen5,TglClosed5,Status5")] CCAN cCAN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cCAN);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cCAN);
        }

        // GET: CCANs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCAN = await _context.CCANs.SingleOrDefaultAsync(m => m.ID5 == id);
            if (cCAN == null)
            {
                return NotFound();
            }
            return View(cCAN);
        }

        // POST: CCANs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID5,ServiceOrder5,SID5,TQ5,AO5,Name5,TglOrderItenos5,Alamat5,KomenItenos5,Pic5,AreaCode5,Metro5,Dat5,Gpon5,SN5,Vlan5,TglPerintahSurvei5,TglHasilSurvei5,TaggingPelanggan5,TeknisiSurvei5,TaggingODP5,TglPerintahPT15,TglSelesaiPTmin15,TeknisiPTmin15,TglPerintahJT5,TglJTSelesai5,Komen5,TglClosed5,Status5")] CCAN cCAN)
        {
            try
            {
                if (id != cCAN.ID5)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cCAN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CCANExists(cCAN.ID5))
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
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(cCAN);
        }

        // GET: CCANs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCAN = await _context.CCANs
                .SingleOrDefaultAsync(m => m.ID5 == id);
            if (cCAN == null)
            {
                return NotFound();
            }

            return View(cCAN);
        }

        // POST: CCANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cCAN = await _context.CCANs.SingleOrDefaultAsync(m => m.ID5 == id);
            _context.CCANs.Remove(cCAN);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CCANExists(int id)
        {
            return _context.CCANs.Any(e => e.ID5 == id);
        }
    }
}
