using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using PrantiksmeApp.BLL.Contracts;
using PrantiksmeApp.Models.Context;
using PrantiksmeApp.Models.EntityModels;
using PrantiksmeApp.Models.IdentityModels;
using PrantiksmeApp.Models.Utilities;
using PrantiksmeApp.Models.ViewModels.SalesStoreViewModels;


namespace PrantiksmeApp.Controllers.SaleStore
{
    public class SalesStoresController : Controller
    {
        private ISalesStoreManager _salesStoreManager;
        private IEmployeeManager _employeeManager;
        private ApplicationUtility _applicationUtility;

 
        public SalesStoresController(ISalesStoreManager salesStoreManager,IEmployeeManager employeeManager,ApplicationUtility applicationUtility)
        {
          
            this._salesStoreManager = salesStoreManager;
            this._employeeManager = employeeManager;
           this._applicationUtility = applicationUtility;
        }
        // GET: StoreRegistration
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: StoreRegistration/Details/5
        public ActionResult Details(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesStore salesStore = _salesStoreManager.GetById(id);
            if (salesStore == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // GET: StoreRegistration/Create
        public ActionResult Create()
        {
           var model=new SalesStoreCreateVm();
            return View(model);
        }

        // POST: StoreRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( SalesStoreCreateVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var userId=User.Identity.GetUserId();

                SalesStore salesStore = Mapper.Map<SalesStore>(model);
                salesStore.CreatedBy = Convert.ToInt64(userId);
                salesStore.CreatedOn=DateTime.Now;
                salesStore.ProprietorId = 2;
                var result = _salesStoreManager.Add(salesStore);
                if (result)
                {
                    return RedirectToAction("Create","SalesStores");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
               
            }

            return View(model);

        }

        // GET: StoreRegistration/Edit/5
        public ActionResult Edit(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesStore salesStore = _salesStoreManager.GetById(id);
            if (salesStore == null)
            {
                return HttpNotFound();
            }
            return View(salesStore);
        }

        // POST: StoreRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SalesStore salesStore)
        {
            if (ModelState.IsValid)
            {
                var result = _salesStoreManager.Update(salesStore);
                return RedirectToAction("Index");
            }
            return View(salesStore);
        }

        // GET: StoreRegistration/Delete/5
        public ActionResult Delete(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SalesStore salesStore = _salesStoreManager.GetById(id);
            if (salesStore == null)
            {
                return HttpNotFound();
            }
            return View(salesStore);
        }

        // POST: StoreRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            SalesStore salesStore = _salesStoreManager.GetById(id);
            var result = _salesStoreManager.Remove(salesStore);
            return RedirectToAction("Index");
        }

        #region EXISTING CHECK

        public JsonResult IsTradeLicenseNoExist(string tradeLicenseNo, string initTradeLicenseNo)
        {
            if (string.IsNullOrEmpty(tradeLicenseNo))
            {
                throw new Exception("Trade License No Not Found !");
            }

            if (!string.IsNullOrEmpty(tradeLicenseNo) && !string.IsNullOrEmpty(initTradeLicenseNo) && tradeLicenseNo.ToUpper().Equals(initTradeLicenseNo.ToUpper()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            
            var result = _salesStoreManager.Get(c => c.TradeLicenseNo.Equals(tradeLicenseNo)).FirstOrDefault();
            return Json(result == null, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsContactNoExist(string contactNo, string initContactNo)
        {
            if (string.IsNullOrEmpty(contactNo))
            {
                throw new Exception("Contact Not Found !");
            }

            if (!string.IsNullOrEmpty(contactNo) && !string.IsNullOrEmpty(initContactNo) && contactNo.ToUpper().Equals(initContactNo.ToUpper()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
           
            var result = _salesStoreManager.Get(c => c.ContactNo.Equals(contactNo)).FirstOrDefault();
            return Json(result == null, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
