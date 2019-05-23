using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PrantiksmeApp.BLL;
using PrantiksmeApp.BLL.Contracts;
using PrantiksmeApp.Models.Utilities;

namespace PrantiksmeApp.Controllers.Base
{
    public class BaseController : Controller
    {
        #region Config

        private readonly IEmployeeManager _employeeManager;

        protected BaseController()
        {

        }
        public BaseController(IEmployeeManager employeeManager)
        {

            this._employeeManager = employeeManager;
            
        }

        

        #endregion

        #region Methode

        protected long GetUserId()
        {
            var userId= User.Identity.GetUserId<long>();
            return userId;
        }


        protected long GetEmployeeId(long? userId = null)
        {
            long appUserId = 0;
            if (userId > 0 is false)
            {
                appUserId = GetUserId();
            }
            else if (userId > 0)
            {
                appUserId = (long)userId;
            }

            var employee = _employeeManager.Get(c => c.AppUserId == appUserId).FirstOrDefault();
            if (employee != null)
            {
                var employeeId= employee.Id;
                return employeeId;
            }
            //throw new Exception("Sorry! No Employee Found !");
            return 0;
        }

        #endregion
    }
}