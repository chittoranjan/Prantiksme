
using System;
using System.ComponentModel.DataAnnotations;
using PrantiksmeApp.Models.Contracts;

namespace PrantiksmeApp.Models.EntityModels.SalesModels
{
    public class Sales:IAuditable,IModel,IAutoCode
    {
        public long Id { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage="Sales Date Is Required.")]
        public DateTime SalesDate { get; set; }
        public long SalesStoreId { get; set; }

        [Required(ErrorMessage = "Code Is Required.")]
        public string UniversalCode { get; set; }

        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }

        public virtual SalesStore SalesStore { get; set; }
        
    }
}
