using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PrantiksmeApp.Models.Contracts;

namespace PrantiksmeApp.Models.ViewModels.SalesStoreViewModels
{
    public class SalesStoreCreateVm: IAuditable, IDeletable, IAutoCode, IModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Sales Store Name Is Required.")]
        [StringLength(150, ErrorMessage = "Sales Store Name Must Be 3 to 150 Char Long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address Is Required.")]
        [StringLength(250, ErrorMessage = "Sales Store Address Must Be 3 to 250 Char Long.", MinimumLength = 3)]
        public string Address { get; set; }

        
        public string TradeLicenseNo { get; set; }

        [Required(ErrorMessage = "Contact Number Required With '11' Digit.")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Contact Number Is Not Valid, Required '11' Digits.")]
        [Remote("IsContactNoExist", "Home", ErrorMessage = "Contact No Already Exist.", AdditionalFields = "InitContactNo")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Code Is Required.")]
        [StringLength(10, ErrorMessage = "Code Must Be 6 to 20 Char Long.",MinimumLength = 6)]
        public string UniversalCode { get; set; }

        public long ProprietorId { get; set; }

        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool Delete()
        {
            return IsDeleted = true;
        }
    }
}
