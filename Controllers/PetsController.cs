using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vet_Surgery_System.Models;

namespace Vet_Surgery_System.Controllers
{
    public class PetsController : Controller
    {
        private Vets_Surgery_DBEntities db = new Vets_Surgery_DBEntities();

        // GET: Pets
        public ActionResult Index()
        {
            var pets = db.Pets.Include(p => p.Breed).Include(p => p.Owner).Include(p => p.Treatment);
            return View(pets.ToList());
        }

        // GET: Pets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            ViewBag.Breed_Id = new SelectList(db.Breeds, "B_Id", "Specie_Name");
            ViewBag.Owner_Id = new SelectList(db.Owners, "O_Id", "F_name");
            ViewBag.Treatment_Id = new SelectList(db.Treatments, "T_Id", "Detail");
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "P_Id,Name,D_O_B,Gender,Cost,Parent_name,Colour,Notes,Pedigree,Breed_Id,Owner_Id,Treatment_Id,Date_Time,Gender")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Pets.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Breed_Id = new SelectList(db.Breeds, "B_Id", "Specie_Name", pet.Breed_Id);
            ViewBag.Owner_Id = new SelectList(db.Owners, "O_Id", "F_name", pet.Owner_Id);
            ViewBag.Treatment_Id = new SelectList(db.Treatments, "T_Id", "Detail", pet.Treatment_Id);
            return View(pet);
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Breed_Id = new SelectList(db.Breeds, "B_Id", "Specie_Name", pet.Breed_Id);
            ViewBag.Owner_Id = new SelectList(db.Owners, "O_Id", "F_name", pet.Owner_Id);
            ViewBag.Treatment_Id = new SelectList(db.Treatments, "T_Id", "Detail", pet.Treatment_Id);
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "P_Id,Name,D_O_B,Gender,Cost,Parent_name,Colour,Notes,Pedigree,Breed_Id,Owner_Id,Treatment_Id,Date_Time")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Breed_Id = new SelectList(db.Breeds, "B_Id", "Specie_Name", pet.Breed_Id);
            ViewBag.Owner_Id = new SelectList(db.Owners, "O_Id", "F_name", pet.Owner_Id);
            ViewBag.Treatment_Id = new SelectList(db.Treatments, "T_Id", "Detail", pet.Treatment_Id);
            return View(pet);
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = db.Pets.Find(id);
            db.Pets.Remove(pet);
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
