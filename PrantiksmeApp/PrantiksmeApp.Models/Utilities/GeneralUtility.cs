using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PrantiksmeApp.Models.Context;

namespace PrantiksmeApp.Models.Utilities
{
    public class GeneralUtility
    {
        #region Config

        private readonly PrantiksmeDbContext _db;

        public GeneralUtility()
        {
            _db = new PrantiksmeDbContext();
        }

        public GeneralUtility(PrantiksmeDbContext db)
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

    }
}