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
    public class DateksController : Controller
    {
        private readonly WitelContext _context;

        public DateksController(WitelContext context)
        {
            _context = context;    
        }

        // GET: Dateks
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
            {
                page = 1;  // Start on Page
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var dateks = from s in _context.Dateks
                           select s;
            // Searching
            if (!String.IsNullOrEmpty(searchString))
            {
                dateks = dateks.Where(s => s.Name.Contains(searchString)
                                        || s.Alamat.Contains(searchString)
                                        || s.AO.Contains(searchString)
                                        || s.AreaCode.Contains(searchString)
                                        || s.Dat.Contains(searchString)
                                        || s.Gpon.Contains(searchString)
                                        || s.Komen.Contains(searchString)
                                        || s.KomenItenos.Contains(searchString)  // Search for each Var
                                        || s.Metro.Contains(searchString)
                                        || s.Pic.Contains(searchString)
                                        || s.SID.Contains(searchString)
                                        || s.SN.Contains(searchString)
                                        || s.Status.Contains(searchString)
                                        || s.ServiceOrder.Contains(searchString)
                                        || s.TaggingODP.Contains(searchString)
                                        || s.TaggingPelanggan.Contains(searchString)
                                        || s.TeknisiPTmin1.Contains(searchString)
                                        || s.TeknisiSurvei.Contains(searchString)
                                        || s.TQ.Contains(searchString)
                                        || s.Vlan.Contains(searchString));
            }
            // Sorting
            switch (sortOrder)
            {
                case "ServiceOrder":
                    dateks = dateks.OrderBy(s => s.ServiceOrder);    // Sort Ascending
                    break;
                case "ServiceOrder_desc":
                    dateks = dateks.OrderByDescending(s => s.ServiceOrder);  // Sort Decending
                    break;                                                   // Ect
                case "SID":
                    dateks = dateks.OrderBy(s => s.SID);
                    break;
                case "SID_desc":
                    dateks = dateks.OrderByDescending(s => s.SID);
                    break;
                case "TQ":
                    dateks = dateks.OrderBy(s => s.TQ);
                    break;
                case "TQ_desc":
                    dateks = dateks.OrderByDescending(s => s.TQ);
                    break;
                case "AO":
                    dateks = dateks.OrderBy(s => s.AO);
                    break;
                case "AO_desc":
                    dateks = dateks.OrderByDescending(s => s.AO);
                    break;
                case "name_desc":
                    dateks = dateks.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    dateks = dateks.OrderBy(s => s.TglOrderItenos);
                    break;
                case "date_desc":
                    dateks = dateks.OrderByDescending(s => s.TglOrderItenos);
                    break;
                case "Alamat":
                    dateks = dateks.OrderBy(s => s.Alamat);
                    break;
                case "Alamat_desc":
                    dateks = dateks.OrderByDescending(s => s.Alamat);
                    break;
                case "KomenItenos":
                    dateks = dateks.OrderBy(s => s.KomenItenos);
                    break;
                case "KomenItenos_desc":
                    dateks = dateks.OrderByDescending(s => s.KomenItenos);
                    break;
                case "Pic":
                    dateks = dateks.OrderBy(s => s.Pic);
                    break;
                case "Pic_desc":
                    dateks = dateks.OrderByDescending(s => s.Pic);
                    break;
                case "AreaCode":
                    dateks = dateks.OrderBy(s => s.AreaCode);
                    break;
                case "AreaCode_desc":
                    dateks = dateks.OrderByDescending(s => s.AreaCode);
                    break;
                case "Metro":
                    dateks = dateks.OrderBy(s => s.Metro);
                    break;
                case "Metro_desc":
                    dateks = dateks.OrderByDescending(s => s.Metro);
                    break;
                case "Datek":
                    dateks = dateks.OrderBy(s => s.Dat);
                    break;
                case "Datek_desc":
                    dateks = dateks.OrderByDescending(s => s.Dat);
                    break;
                case "Gpon":
                    dateks = dateks.OrderBy(s => s.Gpon);
                    break;
                case "Gpon_desc":
                    dateks = dateks.OrderByDescending(s => s.Gpon);
                    break;
                case "SN":
                    dateks = dateks.OrderBy(s => s.SN);
                    break;
                case "SN_desc":
                    dateks = dateks.OrderByDescending(s => s.SN);
                    break;
                case "Vlan":
                    dateks = dateks.OrderBy(s => s.Vlan);
                    break;
                case "Vlan_desc":
                    dateks = dateks.OrderByDescending(s => s.Vlan);
                    break;
                case "TglPerintahSurvei":
                    dateks = dateks.OrderBy(s => s.TglPerintahSurvei);
                    break;
                case "TglPerintahSurvei_desc":
                    dateks = dateks.OrderByDescending(s => s.TglPerintahSurvei);
                    break;
                case "TglHasilSurvei":
                    dateks = dateks.OrderBy(s => s.TglHasilSurvei);
                    break;
                case "TglHasilSurvei_desc":
                    dateks = dateks.OrderByDescending(s => s.TglHasilSurvei);
                    break;
                case "TaggingPelanggan":
                    dateks = dateks.OrderBy(s => s.TaggingPelanggan);
                    break;
                case "TaggingPelanggan_desc":
                    dateks = dateks.OrderByDescending(s => s.TaggingPelanggan);
                    break;
                case "TeknisiSurvei":
                    dateks = dateks.OrderBy(s => s.TeknisiSurvei);
                    break;
                case "TeknisiSurvei_desc":
                    dateks = dateks.OrderByDescending(s => s.TeknisiSurvei);
                    break;
                case "TaggingODP":
                    dateks = dateks.OrderBy(s => s.TaggingPelanggan);
                    break;
                case "TaggingODP_desc":
                    dateks = dateks.OrderByDescending(s => s.TaggingODP);
                    break;
                case "TglPerintahPT1":
                    dateks = dateks.OrderBy(s => s.TglPerintahPT1);
                    break;
                case "TglPerintahPT1_desc":
                    dateks = dateks.OrderByDescending(s => s.TglPerintahPT1);
                    break;
                case "TglSelesaiPT-1":
                    dateks = dateks.OrderBy(s => s.TglSelesaiPTmin1);
                    break;
                case "TglSelesaiPT-1_desc":
                    dateks = dateks.OrderByDescending(s => s.TglSelesaiPTmin1);
                    break;
                case "TeknisiPT-1":
                    dateks = dateks.OrderBy(s => s.TeknisiPTmin1);
                    break;
                case "TeknisiPT-1_desc":
                    dateks = dateks.OrderByDescending(s => s.TeknisiPTmin1);
                    break;
                case "TglPerintahJT":
                    dateks = dateks.OrderBy(s => s.TglPerintahJT);
                    break;
                case "TglPerintahJT_desc":
                    dateks = dateks.OrderByDescending(s => s.TglPerintahJT);
                    break;
                case "TglJTSelesai":
                    dateks = dateks.OrderBy(s => s.TglJTSelesai);
                    break;
                case "TglJTSelesai_desc":
                    dateks = dateks.OrderByDescending(s => s.TglJTSelesai);
                    break;
                case "Komen":
                    dateks = dateks.OrderBy(s => s.Komen);
                    break;
                case "Komen_desc":
                    dateks = dateks.OrderByDescending(s => s.Komen);
                    break;
                case "TglClosed":
                    dateks = dateks.OrderBy(s => s.TglClosed);
                    break;
                case "TglClosed_desc":
                    dateks = dateks.OrderByDescending(s => s.TglClosed);
                    break;
                case "Status":
                    dateks = dateks.OrderBy(s => s.Status);
                    break;
                case "Status_desc":
                    dateks = dateks.OrderByDescending(s => s.Status);
                    break;
                default:
                    dateks = dateks.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 5;  // Data on Each Page
            return View(await PaginatedList<Datek>.CreateAsync(dateks.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Dateks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datek = await _context.Dateks
             .Include(s => s.Enrollments)
             .ThenInclude(e => e.Course)
             .AsNoTracking()
             .SingleOrDefaultAsync(m => m.ID == id);
            if (datek == null)
            {
                return NotFound();
            }

            return View(datek);
        }

        // GET: Dateks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dateks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceOrder,SID,TQ,AO,Name,TglOrderItenos,Alamat,KomenItenos,Pic,AreaCode,Metro,Dat,Gpon,SN,Vlan,TglPerintahSurvei,TglHasilSurvei,TaggingPelanggan,TeknisiSurvei,TaggingODP,TglPerintahPT1,TglSelesaiPTmin1,TeknisiPTmin1,TglPerintahJT,TglJTSelesai,Komen,TglClosed,Status")] Datek datek)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(datek);
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
            return View(datek);
        }

        // GET: Dateks/Edit
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var datekToUpdate = await _context.Dateks.SingleOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Datek>(
                datekToUpdate,
                "",
                s => s.ServiceOrder, s => s.SID, s => s.TQ, s => s.AO, s => s.Name, s => s.TglOrderItenos, s => s.Alamat, s => s.KomenItenos, s => s.Pic, s => s.AreaCode, s => s.Metro, s => s.Dat, s => s.Gpon, s => s.SN, s => s.Vlan, s => s.TglPerintahSurvei, s => s.TglHasilSurvei, s => s.TaggingPelanggan, s => s.TeknisiSurvei, s => s.TaggingODP, s => s.TglPerintahPT1, s => s.TglSelesaiPTmin1, s => s.TeknisiPTmin1, s => s.TglPerintahJT, s => s.TglJTSelesai, s => s.Komen, s => s.TglClosed, s => s.Status))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(datekToUpdate);
        }

        // POST: Dateks/Edit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ServiceOrder,SID,TQ,AO,Name,TglOrderItenos,Alamat,KomenItenos,Pic,AreaCode,Metro,Dat,Gpon,SN,Vlan,TglPerintahSurvei,TglHasilSurvei,TaggingPelanggan,TeknisiSurvei,TaggingODP,TglPerintahPT1,TglSelesaiPTmin1,TeknisiPTmin1,TglPerintahJT,TglJTSelesai,Komen,TglClosed,Status")] Datek datek)
        {
            if (id != datek.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatekExists(datek.ID))
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
            return View(datek);
        }

        // GET: Dateks/Delete
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datek = await _context.Dateks
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (datek == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(datek);
        }

        // POST: Dateks/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datek = await _context.Dateks.AsNoTracking().SingleOrDefaultAsync(m => m.ID == id);
            if (datek == null)
            {
                return RedirectToAction("Index");
            }

            try
            {

                _context.Dateks.Remove(datek);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
        }

        private bool DatekExists(int id)
        {
            return _context.Dateks.Any(e => e.ID == id);
        }
    }
}
