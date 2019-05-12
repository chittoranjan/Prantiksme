using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PrantiksmeApp.BLL.Contracts;
using PrantiksmeApp.Models.Context;
using PrantiksmeApp.Models.EntityModels;
using PrantiksmeApp.Models.IdentityModels;
using PrantiksmeApp.Models.Utilities;
using PrantiksmeApp.Models.ViewModels.StoreRegistrationViewModels;

namespace PrantiksmeApp.Controllers.StoreRegistration
{
    public class StoreRegistrationController : Controller
    {
        private ISalesStoreManager _salesStoreManager;
        private IEmployeeManager _employeeManager;
        //private ApplicationUserManager _applicationUserManager;
        private IGenderManager _genderManager;
        private IAppUserTypeManager _appUserTypeManager;
        private ApplicationUtility _applicationUtility;

        //public StoreRegistrationController()
        //{
            
        //}

        public StoreRegistrationController(ISalesStoreManager salesStoreManager,IEmployeeManager employeeManager,ApplicationUserManager applicationUserManager,
            IGenderManager genderManager,IAppUserTypeManager appUserTypeManager,ApplicationUtility applicationUtility)
        {
           // this._applicationUserManager = applicationUserManager;
            this._salesStoreManager = salesStoreManager;
            this._employeeManager = employeeManager;
            this._genderManager = genderManager;
            this._appUserTypeManager = appUserTypeManager;
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
            var model = new StoreRegistrationCreateVm()
            {
                GenderLookUp = _applicationUtility.GetGenderSelectListItems(),
                AppUserTypeLookUp = _applicationUtility.GetAppUserTypeSelectListItems(),
            };

            return View(model);
        }

        // POST: StoreRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( StoreRegistrationCreateVm storeRegistrationCreateVm)
        {
            if (!ModelState.IsValid)
            {
                return View(storeRegistrationCreateVm);
            }

            return View(storeRegistrationCreateVm);
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

        public JsonResult IsNiDExist(string nidNo, string initNidNo)
        {
            if (string.IsNullOrEmpty(nidNo))
            {
                throw new Exception("NID No Not Found !");
            }

            if (!string.IsNullOrEmpty(nidNo) && !string.IsNullOrEmpty(initNidNo) && nidNo.ToUpper().Equals(initNidNo.ToUpper()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            
            var result = _employeeManager.Get(c => c.NIDNo.Equals(nidNo)).FirstOrDefault();
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
           
            var result = _employeeManager.Get(c => c.ContactNo.Equals(contactNo)).FirstOrDefault();
            return Json(result == null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsEmailExist(string email, string initEmail)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("Email Not Found !");
            }

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(initEmail) && email.ToUpper().Equals(initEmail.ToUpper()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            var result = _employeeManager.Get(c => c.Email.Equals(email)).FirstOrDefault();
            return Json(result == null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsUserNameExist(string userName, string initUserName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new Exception("User Name Not Found !");
            }

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(initUserName) && userName.ToUpper().Equals(initUserName.ToUpper()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            //var result = _applicationUserManager.FindByName(userName);
            var result = "";
            return Json(result == null, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
