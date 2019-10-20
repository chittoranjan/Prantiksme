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
    public class ProprietorEditVm
    {
        public long Id { get; set; }

        [Display(Name = "First Name *")]

        [Required(ErrorMessage = "First Name Is Required.")]
        [StringLength(50, ErrorMessage = "Name Must Be 3 to 50 Char Long", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]

        [StringLength(50, ErrorMessage = "Name Must Be 3 to 50 Char Long", MinimumLength = 3)]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name *")]
        [Required(ErrorMessage = "Last Name Is Required.")]
        [StringLength(50, ErrorMessage = "Name Must Be 2 to 50 Char Long", MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Contact No *")]
        [Required(ErrorMessage = "Contact Number Required With '11' Digit.")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Contact Number Is Not Valid, Required '11' Digits.")]
        [Remote("IsContactNoExist", "Proprietors", ErrorMessage = "Contact No Already Exist.", AdditionalFields = "Id")]
        public string ContactNo { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Date Of Birth")]
        [RegularExpression("(^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))\x2F(((0[1-9])|(1[0-2]))|([1-9]))\x2F(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))))$)", ErrorMessage = ("Date Is Not Correct Format"))]
        public string SDateOfBirth { get; set; }

        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? JoiningDate { get; set; }

        [Display(Name = "Joining Date")]
        [RegularExpression("(^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))\x2F(((0[1-9])|(1[0-2]))|([1-9]))\x2F(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))))$)", ErrorMessage = ("Date Is Not Correct Format"))]
        public string SJoiningDate { get; set; }


        [Display(Name = "NID No")]
        [RegularExpression(@"^((\d{10})|(\d{17}))$", ErrorMessage = "NID No Is Not Valid, Required '10 Or 17' Digit.")]
        [Remote("IsNIDNoExist", "Proprietors", ErrorMessage = "NID No Already Exist.", AdditionalFields = "Id")]
        public string NIDNo { get; set; }

        [Display(Name = "Address *")]
        [Required(ErrorMessage = "Address Is Required.")]
        [StringLength(250, ErrorMessage = "Employee Address Must Be 3 To 250 Char Long.", MinimumLength = 3)]
        public string Address { get; set; }

        [Display(Name = "Email *")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [StringLength(35, ErrorMessage = "Email Id Must Be 12 To 35 Char Long.", MinimumLength = 12)]
        [Remote("IsEmailExist", "Proprietors", ErrorMessage = "Email Already Exist.", AdditionalFields = "Id")]
        public string Email { get; set; }

        [Display(Name = "Photo")]
        public byte[] Photo { get; set; }

        [ForeignKey("AppUser")]
        public long AppUserId { get; set; }

        [Display(Name = "Gender *")]
        [Required(ErrorMessage = "Gender Is Required.")]
        public int GenderId { get; set; }

        [Display(Name = "App User Type")]
        public int AppUserTypeId { get; set; }

        [Display(Name = "Code *")]
        [Required(ErrorMessage = "Code Is Required.")]
        public string UniversalCode { get; set; } = Models.Utilities.ApplicationUtility.GetEmployeeUniversalCode();


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


        public IEnumerable<SelectListItem> GenderLookUp { get; set; }

        public IEnumerable<SelectListItem> AppUserTypeLookUp { get; set; }

        //User Create Section
        [Required(ErrorMessage = "User Name Is Required.")]
        [Display(Name = "User Name *")]
        [RegularExpression(@"^\S+$", ErrorMessage = "Space Not Allow In User Name")]
        [Remote("IsUserNameExist", "Proprietors", ErrorMessage = "User Name Already Exist.", AdditionalFields = "InitUserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Is Required.")]
        [Display(Name = "Password *")]
        [StringLength(50, ErrorMessage = "The password must be at least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Is Required.")]
        [Display(Name = "Confirm Password *")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public RegisterViewModel GetUserCreateModel()
        {
            var model = new RegisterViewModel
            {
                UserName = UserName,
                Password = Password,
                ConfirmPassword = ConfirmPassword,
                Email = Email,
            };
            return model;
        }

    }
}
