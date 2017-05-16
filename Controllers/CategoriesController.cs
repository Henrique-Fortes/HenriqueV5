using HenriqueV5.Contexts;
using HenriqueV5.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HenriqueV5.Controllers
{
    public class CategoriesController : Controller
    {

        private EFContext context = new EFContext();


        // GET: Categories
        public ActionResult Index()
        {
            return View(context.Categories.OrderBy(
                c => c.Name));
        }


        //GET: Create
        public ActionResult Create()
        {
            return View();
        }


        //GET: Edit
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Category category = context.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        //GET: Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Category category = context.Categories
                .Where(c => c.CategoryId == id)
                .Include("Products.Supplier")
                .First();
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        //GET: Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Category category = context.Categories
                .Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }



        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST: Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Entry(category).State =
                    EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }


        //POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Category category = context.Categories
                .Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            TempData["Message"] = "Supplier " +
                category.Name.ToUpper() + "was removed";
            return RedirectToAction("Index");
        }



    }
}