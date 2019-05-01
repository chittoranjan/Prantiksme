
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PrantiksmeApp.Models.Contracts;

namespace PrantiksmeApp.Models.EntityModels.ProductModels
{
    public class ProductSubCategory:IAuditable,IAutoCode,IModel,IDeletable
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Product Sub Category Name Is Required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code Is Required.")]
        public string UniversalCode { get; set; }

        [ForeignKey("ProductCategory")]
        public long ProductCategoryId { get; set; }


        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        
        public bool IsDeleted { get; set; }
        public bool Delete()
        {
            return IsDeleted = true;
        }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual List<ProductItem> ProductItems { get; set; }
    }
}
