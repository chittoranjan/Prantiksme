using System;
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
        public async Task<ActionResult> Create(EmployeeCreateVm model)
        {
            model.GenderLookUp = _applicationUtility.GetGenderSelectListItems();
            model.SalesStoreLookUp = _applicationUtility.GetSalesStoreSelectListItems();
            model.AppUserTypeLookUp = _applicationUtility.GetAppUserTypeSelectListItems();

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                    RegisterViewModel registerViewModel = model.GetUserCreateModel();

                    var user = new ApplicationUser
                    { UserName = registerViewModel.UserName, Email = registerViewModel.Email };
                    var result = await UserManager.CreateAsync(user, registerViewModel.Password);
                    if (result.Succeeded)
                    {
                        var userId = user.Id;
                        model.AppUserId = userId;
                        model.CreatedOn = DateTime.Now;
                        model.CreatedBy = userId;
                        model.ProprietorId = GetUserId();

                        if (!string.IsNullOrEmpty(model.SDateOfBirth))
                        {
                            model.DateOfBirth = Models.Utilities.Utility.GetDate(model.SDateOfBirth);
                        }

                        if (!string.IsNullOrEmpty(model.SJoiningDate))
                        {
                            model.JoiningDate = Models.Utilities.Utility.GetDate(model.SJoiningDate);
                        }

                        if (model.EmployeePhoto != null)
                        {
                            bool isNotValidFormat = Models.Utilities.Utility.CheckImageFormat(model.EmployeePhoto);

                            //Its return True when File Format is Not Valid
                            if (isNotValidFormat)
                            {
                                //ExceptionMsg("Please Upload Valid Format of Image");
                                return View(model);
                            }


                            model.Photo = Models.Utilities.Utility.ConvertImageToBinary(model.EmployeePhoto);

                        }

                        Employee employee = Mapper.Map<Employee>(model);

                        var result1 = _employeeManager.Add(employee);
                        if (result1)
                        {
                            return RedirectToAction("Index", "Home");
                        }

                    }

               return RedirectToAction("Create", "Employees");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return View(model);
            }

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
        public ActionResult Edit(EmployeeCreateVm employeeCreateVm)
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
