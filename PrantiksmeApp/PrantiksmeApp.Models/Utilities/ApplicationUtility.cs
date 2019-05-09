
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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

        public List<SelectListItem> GetDefaultSelectListItem()
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem {Value = "", Text = "---Select---"},
            };
            return items;
        }

        public IEnumerable<SelectListItem> GetGenderSelectListItems()
        {
            var dataList = _db.Genders.ToList();
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


    }


}

