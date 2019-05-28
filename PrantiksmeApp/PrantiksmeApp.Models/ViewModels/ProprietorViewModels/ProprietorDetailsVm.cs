using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PrantiksmeApp.Models.Context;
using PrantiksmeApp.Models.EntityModels;
using PrantiksmeApp.Models.IdentityModels;

namespace PrantiksmeApp.Models.ViewModels.ProprietorViewModels
{
    public class ProprietorDetailsVm
    {
        public long Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Joining Date")]
        public DateTime? JoiningDate { get; set; }

        [Display(Name = "NID No")]
        public string NIDNo { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Photo")]
        public byte[] Photo { get; set; }

        public long AppUserId { get; set; }

        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        [Display(Name = "App User Type")]
        public int AppUserTypeId { get; set; }

        [Display(Name = "Code")]
        public string UniversalCode { get; set; }


        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }

        [Display(Name = "Is Delete")]
        public bool IsDeleted { get; set; }
        public bool Delete()
        {
            return IsDeleted = false;
        }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        public virtual ApplicationUser AppUser { get; set; }
        public virtual SalesStore SalesStore { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual AppUserType AppUserType { get; set; }

        //User Create Section
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
