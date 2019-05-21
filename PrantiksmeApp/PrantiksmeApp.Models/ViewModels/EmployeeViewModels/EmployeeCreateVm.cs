﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PrantiksmeApp.Models.Contracts;
using PrantiksmeApp.Models.EntityModels;
using PrantiksmeApp.Models.IdentityModels;

namespace PrantiksmeApp.Models.ViewModels
{
    public class EmployeeCreateVm:IAuditable,IAutoCode,IDeletable
    {
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
        [Remote("IsContactNoExist", "Home", ErrorMessage = "Contact No Already Exist.", AdditionalFields = "InitContactNo")]
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
        [Remote("IsNIDExist", "Home", ErrorMessage = "NID No Already Exist.", AdditionalFields = "InitNidNo")]
        public string NIDNo { get; set; }

        [Required(ErrorMessage = "Address Is Required.")]
        [StringLength(250, ErrorMessage = "Employee Address Must Be 3 To 250 Char Long.", MinimumLength = 3)]
        public string Address { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        [StringLength(35,ErrorMessage = "Email Id Must Be 12 To 35 Char Long.",MinimumLength = 12)]
        [Remote("IsEmailExist", "Home", ErrorMessage = "Email Already Exist.", AdditionalFields = "InitEmail")]
        public string Email { get; set; }

        public byte[] Photo { get; set; }

        public long? ProprietorId { get; set; }

        public long? SalesStoreId { get; set; }

        [ForeignKey("AppUser")]
        public long AppUserId { get; set; }

        [Required(ErrorMessage = "Gender Is Required.")]
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
            return IsDeleted = false;
        }

        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        public virtual ApplicationUser AppUser { get; set; }
        public virtual SalesStore SalesStore { get; set; }
        public virtual Gender Gender { get; set; }
    }
}