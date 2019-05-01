using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PrantiksmeApp.Models.Contracts;
using PrantiksmeApp.Models.IdentityModels;

namespace PrantiksmeApp.Models.EntityModels
{
    public class Employee:IAuditable,IModel,IAutoCode,IDeletable
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "First Name Is Required.")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name Is Required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Contact Number Required With '11' Digit.")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Contact Number Is Not Valid, Required '11' Digits.")]
        public string ContactNo { get; set; }

        [RegularExpression(@"^((\d{17})|(\d{10}))$", ErrorMessage = "NID No Is Not Valid, Required '10 Or 17' Digit.")]
        public string NIDNo { get; set; }

        [Required(ErrorMessage = "Address Is Required.")]
        public string Address { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        public byte[] Photo { get; set; }

        public long? ProprietorId { get; set; }

        public long? SalesStoreId { get; set; }

        [ForeignKey("AppUser")]
        public long AppUserId { get; set; }

        [Required(ErrorMessage = "Gender Id Is Required.")]
        public int GenderId { get; set; }

        [Required(ErrorMessage = "Code Is Required.")]
        public string UniversalCode { get; set; }


        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool Delete()
        {
            return IsDeleted = true;
        }

        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        public virtual ApplicationUser AppUser { get; set; }
        public virtual SalesStore SalesStore { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
