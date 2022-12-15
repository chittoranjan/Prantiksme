using PrantiksmeApp.BLL.Contracts;
using PrantiksmeApp.Controllers.Base;
using PrantiksmeApp.Models.EntityModels;
using System.Linq;
using System.Web.Mvc;

namespace PrantiksmeApp.Controllers.TestController
{
    public class GendersController : BaseController
    {
        private readonly IGenderManager _manager;

        public GendersController(IGenderManager manager)
        {
            this._manager = manager;
        }

        // GET: Genders
        public ActionResult Index()
        {
            return View(_manager.GetAll(withDeleted: false).ToList());
        }

        // GET: Genders/Details/5
        public ActionResult Details(int id)
        {
            Gender gender = _manager.GetById(id);
            if (gender == null)
            {
                return HttpNotFound();
            }
            return View(gender);
        }

        // GET: Genders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IsDeleted")] Gender gender)
        {
            if (ModelState.IsValid)
            {
                _manager.Add(gender);

                return RedirectToAction("Index");
            }

            return View(gender);
        }

        // GET: Genders/Edit/5
        public ActionResult Edit(int id)
        {
            Gender gender = _manager.GetById(id);
            if (gender == null)
            {
                return HttpNotFound();
            }
            return View(gender);
        }

        // POST: Genders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IsDeleted")] Gender gender)
        {
            if (ModelState.IsValid)
            {
                _manager.Update(gender);

                return RedirectToAction("Index");
            }
            return View(gender);
        }

        // GET: Genders/Delete/5
        public ActionResult Delete(int id)
        {
            Gender gender = _manager.GetById(id);
            if (gender == null)
            {
                return HttpNotFound();
            }
            return View(gender);
        }

        // POST: Genders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gender gender = _manager.GetById(id);
            _manager.Remove(gender);
            return RedirectToAction("Index");
        }


    }
}
