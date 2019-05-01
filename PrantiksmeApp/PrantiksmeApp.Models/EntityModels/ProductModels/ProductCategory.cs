using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PrantiksmeApp.Models.Contracts;

namespace PrantiksmeApp.Models.EntityModels.ProductModels
{
    public class ProductCategory:IAuditable,IAutoCode,IDeletable
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Product Category Name Is Required.")]
        public string Name { get; set; }

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

        public virtual List<ProductSubCategory> ProductSubCategories { get; set; }
        public List<ProductItem> ProductItems { get; set; }
    }
}
