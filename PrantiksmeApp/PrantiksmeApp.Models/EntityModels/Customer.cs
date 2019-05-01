

using System;
using System.ComponentModel.DataAnnotations;
using PrantiksmeApp.Models.Contracts;

namespace PrantiksmeApp.Models.EntityModels
{
    public class Customer:IAuditable,IModel,IAutoCode,IDeletable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
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
            return IsDeleted = true;
        }

        public virtual SalesStore SalesStore { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
