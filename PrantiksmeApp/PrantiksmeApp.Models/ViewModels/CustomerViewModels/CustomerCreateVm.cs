

using System;
using System.ComponentModel.DataAnnotations;
using PrantiksmeApp.Models.Contracts;
using PrantiksmeApp.Models.EntityModels;

namespace PrantiksmeApp.Models.ViewModels.CustomerViewModels
{
    public class CustomerCreateVm
    {
        public long Id { get; set; }

        [StringLength(150, ErrorMessage = "Customer Name Must Be 3 to 150 Char Long.", MinimumLength = 3)]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Contact Number Required With '11' Digit.")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Contact Number Is Not Valid, Required '11' Digits.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Address Is Required.")]
        [StringLength(250, ErrorMessage = "Customer Address Must Be 3 to 250 Char Long.", MinimumLength = 3)]
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
