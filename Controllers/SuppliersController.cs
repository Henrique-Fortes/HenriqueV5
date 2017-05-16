using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc.Html;
using System.Web.Mvc;
using HenriqueV5.Contexts;
using HenriqueV5.Models;

namespace HenriqueV5.Controllers
{
    public class SuppliersController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Suppliers
        public ActionResult Index()
        {
            return View(context.Suppliers.OrderBy(
                c => c.Name));
        }

        //GET: Create
        public ActionResult Create()
        {
            return View();
        }

        //GET: Edit
        // Suppliers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Supplier supplier = context.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        //GET: Details
        // Tests/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Supplier supplier = context.Suppliers
                .Where(s => s.SupplierId ==
                id).Include("Products.Category")
                .First();
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        //GET: Delete
        // Suppliers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Supplier supplier = context.Suppliers
                .Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }




        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            context.Suppliers.Add(supplier);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST: Edit
        // Suppliers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                context.Entry(supplier).State =
                    EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }


        //POST: Delete
        // Suppliers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Supplier supplier = context.Suppliers
                .Find(id);
            context.Suppliers.Remove(supplier);
            context.SaveChanges();
            TempData["Message"] = "Supplier " +
                supplier.Name.ToUpper() + "was removed";
            return RedirectToAction("Index");
        }

    }
}