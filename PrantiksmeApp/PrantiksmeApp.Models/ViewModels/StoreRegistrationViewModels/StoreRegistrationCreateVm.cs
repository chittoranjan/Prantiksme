using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Security;
using PrantiksmeApp.Models.Context;
using PrantiksmeApp.Models.Contracts;
using PrantiksmeApp.Models.EntityModels;
using PrantiksmeApp.Models.IdentityModels;

namespace PrantiksmeApp.Models.ViewModels.StoreRegistrationViewModels
{
    public class StoreRegistrationCreateVm :IAutoCode, IAuditable
    {

        //Proprietor Section
        public long Id { get; set; }

        [Required(ErrorMessage = "First Name Is Required.")]
        [StringLength(50, ErrorMessage = "Name Must Be 3 to 50 Char Long", MinimumLength = 3)]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Name Must Be 3 to 50 Char Long", MinimumLength = 3)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name Is Required.")]
        [StringLength(50, ErrorMessage = "Name Must Be 2 to 50 Char Long", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Contact Number Required With '11' Digit.")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Contact Number Is Not Valid, Required '11' Digits.")]
        [Remote("IsContactNoExist", "StoreRegistration", ErrorMessage = "Contact No Already Exist.", AdditionalFields = "InitContactNo")]
        public string ContactNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateOfBirth { get; set; }

        [RegularExpression("(^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))\x2F(((0[1-9])|(1[0-2]))|([1-9]))\x2F(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))))$)", ErrorMessage = ("Date Is Not Correct Format"))]
        public string SDateOfBirth { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? JoiningDate { get; set; }

        [RegularExpression("(^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))\x2F(((0[1-9])|(1[0-2]))|([1-9]))\x2F(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))))$)", ErrorMessage = ("Date Is Not Correct Format"))]
        public string SJoiningDate { get; set; }

        [RegularExpression(@"^((\d{10})|(\d{17}))$", ErrorMessage = "NID No Is Not Valid, Required '10 Or 17' Digit.")]
        [Remote("IsNIDExist", "StoreRegistration", ErrorMessage = "NID No Already Exist.", AdditionalFields = "InitNidNo")]
        public string NIDNo { get; set; }

        [Required(ErrorMessage = "Address Is Required.")]
        [StringLength(250, ErrorMessage = "Employee Address Must Be 3 To 250 Char Long.", MinimumLength = 3)]
        public string Address { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        [StringLength(35, ErrorMessage = "Email Id Must Be 12 To 35 Char Long.", MinimumLength = 12)]
        [Remote("IsEmailExist", "StoreRegistration", ErrorMessage = "Email Already Exist.", AdditionalFields = "InitEmail")]
        public string Email { get; set; }

        public byte[] Photo { get; set; }

        public long? ProprietorId { get; set; }

        public long? SalesStoreId { get; set; }

        [ForeignKey("AppUser")]
        public long AppUserId { get; set; }

        [Required(ErrorMessage = "Gender Is Required.")]
        public int GenderId { get; set; }

        public int AppUserTypeId { get; set; }

        [Required(ErrorMessage = "Code Is Required.")]
        public string UniversalCode { get; set; }


        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }

        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        public virtual ApplicationUser AppUser { get; set; }
        public virtual SalesStore SalesStore { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual AppUserType AppUserType { get; set; }

        public IEnumerable<SelectListItem> GenderLookUp { get; set; }

        public IEnumerable<SelectListItem> AppUserTypeLookUp { get; set; }
        //Sales Store Section
        [Required(ErrorMessage = "Sales Store Name Is Required.")]
        public string SalesStoreName { get; set; }

        [Required(ErrorMessage = "Address Is Required.")]
        [DataType(DataType.MultilineText)]
        public string SalesStoreAddress { get; set; }

        public string TradeLicenseNo { get; set; }

        [Required(ErrorMessage = "Sales Store Contact Number Required With '11' Digit.")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Contact Number Is Not Valid, Required '11' Digits.")]
        public string SalesStoreContactNo { get; set; }

        [Required(ErrorMessage = "Code Is Required.")]
        public string SalesStoreUniversalCode { get; set; }

        //User Create Section
        [RegularExpression(@"^\S+$", ErrorMessage = "Space Not Allow In User Name")]
        [Remote("IsUserNameExist", "StoreRegistration", ErrorMessage = "User Name Already Exist.", AdditionalFields = "InitUserName")]
        public string UserName { get; set; }


        [StringLength(50, ErrorMessage = "The password must be at least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public RegisterViewModel GetUserCreateModel()
        {
            var model = new RegisterViewModel
            {
               
                Password = Password,
                ConfirmPassword = ConfirmPassword,
                Email = Email,
            };
            return model;
        }

        //Method Section 
        private string GetEmployeeUniversalCode()
        {
            PrantiksmeDbContext db = new PrantiksmeDbContext();
            string codeSl = "";
            var countId = db.Users.Count();
            countId++;
            if (countId <= 9)
            {

                string invNo = Convert.ToString("000" + countId);
                codeSl = invNo;
            }
            if (countId <= 99)
            {
                string invNo = Convert.ToString("00" + countId);
                codeSl = invNo;
            }
            if (countId <= 999)
            {
                string invNo = Convert.ToString("0" + countId);
                codeSl = invNo;
            }
            else
            {
                string invNo = Convert.ToString(countId);
                codeSl = invNo;
            }
            var code = codeSl + " " + DateTime.Today.ToString("ddMMyy");
            return UniversalCode = code;
        }

        private string GetSalesStoreUniversalCode()
        {
            PrantiksmeDbContext db = new PrantiksmeDbContext();
            string codeSl = "";
            var countId = db.SalesStores.Count();
            countId++;
            if (countId <= 9)
            {

                string invNo = Convert.ToString("000" + countId);
                codeSl = invNo;
            }
            if (countId <= 99)
            {
                string invNo = Convert.ToString("00" + countId);
                codeSl = invNo;
            }
            if (countId <= 999)
            {
                string invNo = Convert.ToString("0" + countId);
                codeSl = invNo;
            }
            else
            {
                string invNo = Convert.ToString(countId);
                codeSl = invNo;
            }
            var code = codeSl + " " + DateTime.Today.ToString("ddMMyy");
            return SalesStoreUniversalCode = code;
        }
    }
}
