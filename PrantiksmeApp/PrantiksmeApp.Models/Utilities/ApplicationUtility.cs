
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic.ApplicationServices;
using PrantiksmeApp.Models.Context;
using PrantiksmeApp.Models.Enums;

namespace PrantiksmeApp.Models.Utilities
{
    public class ApplicationUtility
    {
        #region CONFIG

        private readonly PrantiksmeDbContext _db;

        public ApplicationUtility()
        {
            _db = new PrantiksmeDbContext();
        }

        public ApplicationUtility(PrantiksmeDbContext db)
        {
            _db = db;
        }

        #endregion

        #region Application Startup Method
       
        public List<SelectListItem> GetDefaultSelectListItem()
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem {Value = "", Text = "---Select---"},
            };
            return items;
        }
        
        #endregion

        #region Application Method

        public IEnumerable<SelectListItem> GetGenderSelectListItems()
        {
            var dataList = _db.Genders.ToList();
            var createList = GetDefaultSelectListItem();
            createList.AddRange(dataList.Select(item => new SelectListItem() { Value = item.Id.ToString(), Text = item.Name }));
            return createList;
        }

        public IEnumerable<SelectListItem> GetAppUserTypeSelectListItems()
        {
            var dataList = _db.AppUserTypes.ToList();
            var createList = GetDefaultSelectListItem();
            createList.AddRange(dataList.Select(item => new SelectListItem() { Value = item.Id.ToString(), Text = item.Name }));
            return createList;
        }
        public IEnumerable<SelectListItem> GetSalesStoreSelectListItems()
        {
            var dataList = _db.SalesStores.ToList();
            var createList = GetDefaultSelectListItem();
            createList.AddRange(dataList.Select(item => new SelectListItem() { Value = item.Id.ToString(), Text = item.Name }));
            return createList;
        }
        public IEnumerable<SelectListItem> GetProductCategorySelectListItems()
        {
            var dataList = _db.ProductCategories.ToList();
            var createList = GetDefaultSelectListItem();
            createList.AddRange(dataList.Select(item => new SelectListItem() { Value = item.Id.ToString(), Text = item.Name }));
            return createList;
        }

        public IEnumerable<SelectListItem> GetProductSubCategorySelectListItems(long productCategoryId)
        {
            var dataList = _db.ProductSubCategories.Where(c => c.ProductCategoryId == productCategoryId).ToList();
            var createList = GetDefaultSelectListItem();
            createList.AddRange(dataList.Select(item => new SelectListItem() { Value = item.Id.ToString(), Text = item.Name }));
            return createList;
        }

        //public List<SelectListItem> GetDivisionSelectListItems()
        //{
        //    var divisions = _iDivisionManager.GetAll().ToList();
        //    var items = GetDefaultSelectListItem();
        //    items.AddRange(divisions.Select(division => new SelectListItem() { Value = division.Id.ToString(), Text = division.Name }));
        //    return items;
        //}


        //public IEnumerable<SelectListItem> GetDistrictSelectListItems()
        //{
        //    var items = _iDistrictManager.GetAll();
        //    var createList = GetDefaultSelectListItem();
        //    createList.AddRange(items.Select(item => new SelectListItem() { Value = item.Id.ToString(), Text = item.Name }));
        //    return createList;
        //}

        //public IEnumerable<SelectListItem> GetSubDistrictSelectListItems()
        //{
        //    var items = _iSubDistrictManager.GetAll();
        //    var createList = GetDefaultSelectListItem();
        //    createList.AddRange(items.Select(item => new SelectListItem() { Value = item.Id.ToString(), Text = item.Name }));
        //    return createList;

        //}


        //public IEnumerable<SelectListItem> GetCollectionStatusSelectListItems()
        //{
        //    var dataList = new List<SelectListItem>()
        //    {
        //        new SelectListItem {Value = "", Text = "All"},
        //        new SelectListItem {Value = ((int)CollectionStatusEnum.Paid).ToString(), Text = "Paid"},
        //        new SelectListItem {Value = ((int)CollectionStatusEnum.Open).ToString(), Text = "Open"},
        //        new SelectListItem {Value = ((int)CollectionStatusEnum.Due).ToString(), Text = "Due"},
        //    };
        //    var createList = new List<SelectListItem>();
        //    createList.AddRange(dataList.Select(item => new SelectListItem() { Value = item.Value, Text = item.Text }));
        //    return createList;
        //}

        //public List<SelectListItem> GetBloodGroupSelectListItem()
        //{
        //    var dataList = _db.BloodGroups.ToList();
        //    var items = GetDefaultSelectListItem();
        //    items.AddRange(dataList.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }));
        //    return items;
        //}

        //public List<SelectListItem> GetMaritalStatusSelectListItem()
        //{
        //    var dataList = "";//_db.MaritalStatuses.ToList();
        //    var items = GetDefaultSelectListItem();
        //    items.AddRange(dataList.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }));
        //    return items;
        //}

        //public List<SelectListItem> GetEduGradeSelectListItem()
        //{
        //    var dataList = _db.EduGrades.ToList();
        //    var items = GetDefaultSelectListItem();
        //    items.AddRange(dataList.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }));
        //    return items;
        //}

        //public IEnumerable<SelectListItem> GetEduLevelSelectListItems()
        //{
        //    var dataList = _db.EducationLevels.ToList();
        //    var items = GetDefaultSelectListItem();
        //    items.AddRange(dataList.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }));
        //    return items;
        //}

        //public IEnumerable<SelectListItem> GetEduGradePointTypeLookUp()
        //{
        //    var dataList = _db.EduGradePointTypes.ToList();
        //    var items = GetDefaultSelectListItem();
        //    items.AddRange(dataList.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }));
        //    return items;
        //}

        //public List<SelectListItem> GetEduGradePointTypeSelectListItem()
        //{
        //    var dataList = _db.EduGradePointTypes.ToList();
        //    var items = GetDefaultSelectListItem();
        //    items.AddRange(dataList.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }));
        //    return items;
        //}

        //public List<SelectListItem> GetReligionSelectListItem()
        //{
        //    var dataList = _db.Religions.ToList();
        //    var items = GetDefaultSelectListItem();
        //    items.AddRange(dataList.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }));
        //    return items;
        //}

        //public List<SelectListItem> GetEmploymentTypeSelectListItem()
        //{
        //    var dataList = _db.EmploymentTypes.ToList();
        //    var items = GetDefaultSelectListItem();
        //    items.AddRange(dataList.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }));
        //    return items;
        //}

        //public IEnumerable<SelectListItem> GetAddressTypeLookUp()
        //{
        //    var dataList = _db.AddressTypes.ToList();
        //    var items = GetDefaultSelectListItem();
        //    items.AddRange(dataList.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }));
        //    return items;
        //}

        #endregion

        #region Exception Handdleing

        public static dynamic GetExceptionMessage(Exception e)
        {
            string errorMsg = e.Message;

            if (e.InnerException != null)
            {
                errorMsg = e.InnerException.Message;
            }
            if (e.InnerException?.InnerException != null)
            {
                errorMsg = e.InnerException.InnerException.Message;
            }
            if (e.InnerException?.InnerException?.InnerException != null)
            {
                errorMsg = e.InnerException.InnerException.InnerException.Message;
            }

            return errorMsg;
        }

        #endregion
        #region Universal Code 
        public static string GetEmployeeUniversalCode()
        {
            PrantiksmeDbContext db = new PrantiksmeDbContext();
            string codeSl = "";
            var countId = db.Users.Count();
           
            countId++;
            if (countId <= 9)
            {

                string slNo = Convert.ToString("000" + countId);
                codeSl = slNo;
            }
            if (countId >9 && countId<= 99)
            {
                string slNo = Convert.ToString("00" + countId);
                codeSl = slNo;
            }
            if (countId >99 && countId<= 999)
            {
                string slNo = Convert.ToString("0" + countId);
                codeSl = slNo;
            }
            if(countId>999)
            {
                string slNo = Convert.ToString(countId);
                codeSl = slNo;
            }
            
            var code = codeSl + " " + DateTime.Today.ToString("ddMMyy");
            return code;
        }

        public static string GetSalesStoreUniversalCode()
        {
            PrantiksmeDbContext db = new PrantiksmeDbContext();
            string codeSl = "";
            var countId = db.SalesStores.Count();
            countId++;
            if (countId <= 9)
            {

                string slNo = Convert.ToString("000" + countId);
                codeSl = slNo;
            }
            if (countId > 9 && countId <= 99)
            {
                string slNo = Convert.ToString("00" + countId);
                codeSl = slNo;
            }
            if (countId > 99 && countId <= 999)
            {
                string slNo = Convert.ToString("0" + countId);
                codeSl = slNo;
            }
            if (countId > 999)
            {
                string slNo = Convert.ToString(countId);
                codeSl = slNo;
            }
            
            var code = codeSl + " " + DateTime.Today.ToString("ddMMyy");

            return code;
        }
        

        #endregion

    }


}

