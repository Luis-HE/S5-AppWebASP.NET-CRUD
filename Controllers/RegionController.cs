using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_S5_CRUD.Models;

namespace WebApplication_S5_CRUD.Controllers
{
    public class RegionController : Controller
    {
        // GET: Region
        public ActionResult Index()
        {
            using (masterEntities contexto = new masterEntities())
            {
                return View(contexto.Region.ToList());
            }
        }

        // GET: Region/Details/5
        public ActionResult Details(int id)
        {
            using (masterEntities contexto = new masterEntities())
            {
                return View(contexto.Region.Where(x => x.RegionID == id).FirstOrDefault());
            }
        }

        // GET: Region/Create
        public ActionResult Create()
        {
            using (masterEntities contexto = new masterEntities())
            {
                int maxRegionID = contexto.Region.Max(r => r.RegionID);
                var model = new Region
                {
                RegionID = maxRegionID +1 
                };
                return View(model);
            }
        }

        // POST: Region/Create
        [HttpPost]
        public ActionResult Create(Region region)
        {
            try
            {
                using (masterEntities contexto = new masterEntities())
                {
                    // TODO: Add insert logic here
                    var newRegion = new Region
                    {
                        RegionID = region.RegionID,
                        RegionDescription = region.RegionDescription
                    };
                    contexto.Region.Add(newRegion);
                    contexto.SaveChanges();
                    return RedirectToAction("/Index");

                }                
            }
            catch
            {
                return View();
            }
        }

        // GET: Region/Edit/5
        public ActionResult Edit(int id)
        {
            using (masterEntities contexto = new masterEntities())
            {
                return View(contexto.Region.Where(x => x.RegionID == id).FirstOrDefault());
            }
        }

        // POST: Region/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Region regionArray)
        {
            try
            {
                // TODO: Add update logic here
                using (masterEntities contexto = new masterEntities())
                {
                    contexto.Entry(regionArray).State = (System.Data.Entity.EntityState)EntityState.Modified;
                    contexto.SaveChanges();
                    return RedirectToAction("/Index");
                }
            }
            catch
            {
                return View("/Index");
            }
        }

        // GET: Region/Delete/5
        public ActionResult Delete(int id)
        {
            using (masterEntities contexto = new masterEntities())
            {
                return View(contexto.Region.Where(x => x.RegionID == id).FirstOrDefault());
            }
        }

        // POST: Region/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (masterEntities contexto = new masterEntities())
                {
                    Region objRegion = contexto.Region.Where(x => x.RegionID == id).FirstOrDefault();
                    contexto.Region.Remove(objRegion);
                    contexto.SaveChanges();
                }
                return RedirectToAction("/Index");
            }
            catch
            {
                return View("/");
            }
        }
    }
}
