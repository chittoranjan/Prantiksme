using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using PrantiksmeApp.BLL.Contracts;
using PrantiksmeApp.Controllers.Base;
using PrantiksmeApp.Models.Context;
using PrantiksmeApp.Models.Utilities;
using PrantiksmeApp.Models.ViewModels;

namespace PrantiksmeApp.Controllers.Employees
{
    public class EmployeesController : BaseController
    {
        #region Configuration


        private readonly IEmployeeManager _employeeManager;
        private readonly IGenderManager _genderManager;
        private readonly IAppUserTypeManager _appUserTypeManager;
        private readonly ApplicationUtility _applicationUtility;
        private readonly ISalesStoreManager _salesStoreManager;

        public EmployeesController(IEmployeeManager employeeManager, IGenderManager genderManager, IAppUserTypeManager appUserTypeManager, ApplicationUtility applicationUtility, ISalesStoreManager salesStoreManager)
        {

            this._employeeManager = employeeManager;
            this._genderManager = genderManager;
            this._appUserTypeManager = appUserTypeManager;
            this._applicationUtility = applicationUtility;
            this._salesStoreManager = salesStoreManager;
        }
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        #endregion

        // GET: EmployeeCreateVms
        public ActionResult Index()
        {
            var employee = _employeeManager.GetAll();
            return View();
        }

        // GET: EmployeeCreateVms/Details/5
        public ActionResult Details(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = _employeeManager.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // GET: EmployeeCreateVms/Create
        public ActionResult Create()
        {
            var model = new EmployeeCreateVm()
            {
                GenderLookUp = _applicationUtility.GetGenderSelectListItems(),
                SalesStoreLookUp = _applicationUtility.GetSalesStoreSelectListItems(),
                AppUserTypeLookUp = _applicationUtility.GetAppUserTypeSelectListItems()
            };
            return View(model);
        }

        // POST: EmployeeCreateVms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreateVm employeeCreateVm)
        {
            if (ModelState.IsValid)
            {
                
            }

            return View(employeeCreateVm);
        }

        // GET: EmployeeCreateVms/Edit/5
        public ActionResult Edit(long id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = _employeeManager.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View();
        }

        // POST: EmployeeCreateVms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( EmployeeCreateVm employeeCreateVm)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }
            return View(employeeCreateVm);
        }

        // GET: EmployeeCreateVms/Delete/5
        public ActionResult Delete(long id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeCreateVm = _employeeManager.GetById(id);
            if (employeeCreateVm == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: EmployeeCreateVms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var employee = _employeeManager.GetById(id);
            var result = _employeeManager.Remove(employee);
            return RedirectToAction("Index");
        }


    }
}
