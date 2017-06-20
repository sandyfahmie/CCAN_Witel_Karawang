using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CCAN_Witel_Karawang.Models.DB;
using PagedList;                        // menggunakan pagination dari package PagedList.Mvc
using System.Diagnostics;                // untuk debuging, hapus kalau ga perlu          

namespace CCAN_Witel_Karawang.Controllers
{
    [Authorize]
    public class CorporateController : Controller
    {
        private dbccanEntities db = new dbccanEntities();

        // GET: Home
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string filterColumn, string[] filterBy, int? page)
        {
            // querry seluruh data dari tabel TechInfoes 
            var data = from m in db.TechInfoes
                       select m;
            data = data.OrderBy(s => s.TechInfoID);
            ViewBag.CurrentSort = sortOrder;

            // menentukan opsi filter untuk beberapa kolom
            /*
             * opsi filter untuk:
             * - AreaCode
             * - Metro
             * - GPON
             * - status
             * Jika ada yang mau ditambahkan atau kurangi silahkan tambahkan
             */
            ViewBag.AreaCodeFilterOption = data.Select(s => s.AreaCode).Distinct();
            ViewBag.MetroFilterOption = data.Select(s => s.Metro).Distinct();
            ViewBag.GPONFilterOption = data.Select(s => s.GPON).Distinct();
            ViewBag.statusFilterOption = data.Select(s => s.status).Distinct();

            // logic filtering data
            if ((!String.IsNullOrEmpty(filterColumn)) && (!String.IsNullOrEmpty(filterBy[0])))
            {
                int count = 0;
                var data_temp = data;
                var data_master = data;
                foreach (string r in filterBy)
                {
                    String filterSearch = filterBy[count];
                    switch (filterColumn)
                    {
                        case "AreaCode": data_temp = data_master.Where(s => s.AreaCode.Contains(filterSearch)); break;
                        case "Metro": data_temp = data_master.Where(s => s.Metro.Contains(filterSearch)); break;
                    }
                    if (count > 0)
                    {
                        data = data.AsQueryable().Concat(data_temp.AsQueryable());
                    } else
                    {
                        data = data_temp;
                    }
                    count++;
                }
                data = data.OrderBy(s => s.TechInfoID);
            }

            // jika ada request search maka dikembalikan ke hal pertama
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            // pencarian
            if (!String.IsNullOrEmpty(searchString))
            {
                // pemilihan data, data yang diambil di db dipilih sesuai dengan yang direquest search
                data = data.Where(s => s.SID.Contains(searchString) || s.TQ.Contains(searchString) || s.AO.Contains(searchString) || s.Name.Contains(searchString));
            }
            // sortir ascending atau descending
            if (!String.IsNullOrEmpty(sortOrder))
            {
                // misal sortOrder = "SID_ASC", sortOrder[0] = SID adalah kolomnya, sortOrder[1] = mode sortir
                string[] sortParameter = sortOrder.Split('_');
                if (String.Equals(sortParameter[1], "ASC"))
                {    // blok Ascending
                    switch (sortOrder)
                    {
                        case "SID": data = data.OrderBy(s => s.SID); break;
                        case "TQ": data = data.OrderBy(s => s.TQ); break;
                        case "AO": data = data.OrderBy(s => s.AO); break;
                        case "Name": data = data.OrderBy(s => s.Name); break;
                    }
                }
                else    // blok Descending
                {
                    switch (sortOrder)
                    {
                        case "SID": data = data.OrderByDescending(s => s.SID); break;
                        case "TQ": data = data.OrderByDescending(s => s.TQ); break;
                        case "AO": data = data.OrderByDescending(s => s.AO); break;
                        case "Name": data = data.OrderByDescending(s => s.Name); break;
                    }
                }
            }

            int pageSize = 10;                       // Nilai Default berapa data yang ditampilkan setiap halaman
            int pageNumber = (page ?? 1);
            return View(data.ToPagedList(pageNumber, pageSize));
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechInfo techInfo = db.TechInfoes.Find(id);
            if (techInfo == null)
            {
                return HttpNotFound();
            }
            return View(techInfo);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TechInfoID,SID,TQ,AO,Name,OrderTime,Address,TeNOSScomment,PIC,AreaCode,Metro,GPON,SN,VLAN,SurveyTime,CustTag,SurveyTech,ODPTag,PT1Com,PT1End,PT1Tech,JTTime,JTEnd,comment,ClosedTime,status")] TechInfo techInfo)
        {
            if (ModelState.IsValid)
            {
                // mengisi beberapa input menjadi "- jika tidak diisi oleh user
                techInfo.Address        = (String.IsNullOrEmpty(techInfo.Address)) ? "-" : techInfo.Address;
                techInfo.TeNOSScomment  = (String.IsNullOrEmpty(techInfo.TeNOSScomment)) ? "-" : techInfo.TeNOSScomment;
                techInfo.PIC            = (String.IsNullOrEmpty(techInfo.PIC)) ? "-" : techInfo.PIC;
                techInfo.AreaCode       = (String.IsNullOrEmpty(techInfo.AreaCode)) ? "-" : techInfo.AreaCode;
                techInfo.Metro          = (String.IsNullOrEmpty(techInfo.Metro)) ? "-" : techInfo.Metro;
                techInfo.GPON           = (String.IsNullOrEmpty(techInfo.GPON)) ? "-" : techInfo.GPON;
                techInfo.SN             = (String.IsNullOrEmpty(techInfo.SN)) ? "-" : techInfo.SN;
                techInfo.VLAN           = (String.IsNullOrEmpty(techInfo.VLAN)) ? "-" : techInfo.VLAN;
                techInfo.CustTag        = (String.IsNullOrEmpty(techInfo.CustTag)) ? "-" : techInfo.CustTag;
                techInfo.SurveyTech     = (String.IsNullOrEmpty(techInfo.SurveyTech)) ? "-" : techInfo.SurveyTech;
                techInfo.ODPTag         = (String.IsNullOrEmpty(techInfo.ODPTag)) ? "-" : techInfo.ODPTag;
                techInfo.PT1Tech        = (String.IsNullOrEmpty(techInfo.PT1Tech)) ? "-" : techInfo.PT1Tech;
                techInfo.comment        = (String.IsNullOrEmpty(techInfo.comment)) ? "-" : techInfo.comment;
                techInfo.status         = (String.IsNullOrEmpty(techInfo.status)) ? "-" : techInfo.status;
                db.TechInfoes.Add(techInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(techInfo);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechInfo techInfo = db.TechInfoes.Find(id);
            if (techInfo == null)
            {
                return HttpNotFound();
            }
            return View(techInfo);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TechInfoID,SID,TQ,AO,Name,OrderTime,Address,TeNOSScomment,PIC,AreaCode,Metro,GPON,SN,VLAN,SurveyTime,CustTag,SurveyTech,ODPTag,PT1Com,PT1End,PT1Tech,JTTime,JTEnd,comment,ClosedTime,status")] TechInfo techInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(techInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(techInfo);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechInfo techInfo = db.TechInfoes.Find(id);
            if (techInfo == null)
            {
                return HttpNotFound();
            }
            return View(techInfo);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TechInfo techInfo = db.TechInfoes.Find(id);
            db.TechInfoes.Remove(techInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
