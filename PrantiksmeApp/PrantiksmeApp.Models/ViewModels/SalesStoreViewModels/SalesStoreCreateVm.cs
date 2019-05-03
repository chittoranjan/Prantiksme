using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrantiksmeApp.Models.ViewModels.SalesStoreViewModels
{
    public class SalesStoreCreateVm
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Sales Store Name Is Required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address Is Required.")]
        public string Address { get; set; }

        public string TradeLicenseNo { get; set; }

        [Required(ErrorMessage = "Contact Number Required With '11' Digit.")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Contact Number Is Not Valid, Required '11' Digits.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Code Is Required.")]
        public string UniversalCode { get; set; }
        public long ProprietorId { get; set; }

        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
