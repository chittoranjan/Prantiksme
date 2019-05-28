﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PrantiksmeApp.BLL.Contracts;
using PrantiksmeApp.Controllers.Base;
using PrantiksmeApp.Models.Context;
using PrantiksmeApp.Models.EntityModels;
using PrantiksmeApp.Models.IdentityModels;
using PrantiksmeApp.Models.Utilities;
using PrantiksmeApp.Models.ViewModels.ProprietorViewModels;

namespace PrantiksmeApp.Controllers.Proprietor
{
    public class ProprietorsController : BaseController
    {
        #region Configuration


        private readonly IEmployeeManager _employeeManager;
        private readonly IGenderManager _genderManager;
        private readonly IAppUserTypeManager _appUserTypeManager;
        private readonly ApplicationUtility _applicationUtility;

        public ProprietorsController(IEmployeeManager employeeManager, IGenderManager genderManager, IAppUserTypeManager appUserTypeManager, ApplicationUtility applicationUtility)
        {

            this._employeeManager = employeeManager;
            this._genderManager = genderManager;
            this._appUserTypeManager = appUserTypeManager;
            this._applicationUtility = applicationUtility;
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

        #region All Action

        // GET: Proprietors
        public ActionResult Search()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        // GET: Proprietor/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var proprietor = _employeeManager.GetById(id);
            if (proprietor == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<ProprietorDetailsVm>(proprietor);
            return View(model);
        }

        // GET: Proprietor/Create
        public ActionResult Create()
        {
            var model = new ProprietorCreateVm()
            {
                GenderLookUp = _applicationUtility.GetGenderSelectListItems(),
                AppUserTypeLookUp = _applicationUtility.GetAppUserTypeSelectListItems(),

            };
            return View(model);
        }

        // POST: Proprietor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProprietorCreateVm model)
        {

            try
            {
                model.GenderLookUp = _applicationUtility.GetGenderSelectListItems();
                model.AppUserTypeLookUp = _applicationUtility.GetAppUserTypeSelectListItems();

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                RegisterViewModel registerViewModel = model.GetUserCreateModel();
                Employee employee = Mapper.Map<Employee>(model);

                var user = new ApplicationUser { UserName = registerViewModel.UserName, Email = registerViewModel.Email };
                var result = await UserManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    var userId = user.Id;
                    employee.AppUserId = userId;
                    employee.CreatedOn = DateTime.Now;
                    employee.CreatedBy = userId;

                    if (!string.IsNullOrEmpty(model.SDateOfBirth))
                    {
                        employee.DateOfBirth = Models.Utilities.Utility.GetDate(model.SDateOfBirth);
                    }
                    if (!string.IsNullOrEmpty(model.SJoiningDate))
                    {
                        employee.DateOfBirth = Models.Utilities.Utility.GetDate(model.SJoiningDate);
                    }

                    var result1 = _employeeManager.Add(employee);
                    if (result1)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                        return RedirectToAction("Index", "Home");
                    }

                }
                return View(model);
            }
            catch (Exception e)
            {
                var ex = Models.Utilities.ApplicationUtility.GetExceptionMessage(e);
                return View("Error", new HandleErrorInfo(ex, "Proprietors", "Create"));
            }


        }

        // GET: Proprietor/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUserType appUserType = _appUserTypeManager.GetById(id);
            if (appUserType == null)
            {
                return HttpNotFound();
            }
            return View(appUserType);
        }

        // POST: Proprietor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppUserType appUserType)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }
            return View(appUserType);
        }

        // GET: Proprietor/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AppUserType appUserType = _appUserTypeManager.GetById(id);
            if (appUserType == null)
            {
                return HttpNotFound();
            }
            return View(appUserType);
        }

        // POST: Proprietor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppUserType appUserType = _appUserTypeManager.GetById(id);

            return RedirectToAction("Index");
        }


        #endregion

        #region EXISTING CHECK

        public JsonResult IsNIDNoExist(string nidNo, string initNidNo)
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
            var result1 = UserManager.FindByEmail(email);
            return Json(result == null && result1 == null, JsonRequestBehavior.AllowGet);
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

            var result = UserManager.FindByName(userName);

            return Json(result == null, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
