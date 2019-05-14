

using System;
using System.ComponentModel.DataAnnotations;
using PrantiksmeApp.Models.Contracts;

namespace PrantiksmeApp.Models.EntityModels
{
    public class Customer:IAuditable,IAutoCode,IDeletable
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Contact Number Is Not Valid, Required '11' Digits.")]
        public string ContactNo { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        public string Address { get; set; }

        public long SalesStoreId { get; set; }

        public long EmployeeId { get; set; }

        [Required(ErrorMessage="Code Is Required")]
        public string UniversalCode { get; set; }

        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }
        public bool Delete()
        {
            return IsDeleted = false;
        }

        public virtual SalesStore SalesStore { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
