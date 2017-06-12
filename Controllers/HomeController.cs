using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CCAN_Witel_Karawang.Models.DB;

namespace CCAN_Witel_Karawang.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private dbccanEntities db = new dbccanEntities();

        // GET: Home
        public ActionResult Index(string id)
        {
            // pencarian
            if (!String.IsNullOrEmpty(id))
            {
                string searchString = id;
                var data = from m in db.TechInfoes
                           select m;
                data = data.Where(s => s.SID.Contains(searchString) || s.TQ.Contains(searchString) || s.AO.Contains(searchString) || s.Name.Contains(searchString));
                return View(data);
            }
            else
            {
                return View(db.TechInfoes.ToList());
            }
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
