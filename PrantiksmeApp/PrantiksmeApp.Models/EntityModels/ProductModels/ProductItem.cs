using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PrantiksmeApp.Models.Contracts;

namespace PrantiksmeApp.Models.EntityModels.ProductModels
{
    public class ProductItem:IAuditable,IModel,IAutoCode,IDeletable
    {
        public long Id { get; set; }

        [Required(ErrorMessage="Product Item Name Is Required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code Is Required.")]
        public string UniversalCode { get; set; }

        [ForeignKey("ProductCategory")]
        public long ProductCategoryId { get; set; }

        [ForeignKey("ProductSubCategory")]
        public long? ProductSubCategoryId { get; set; }

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
        public virtual ProductSubCategory ProductSubCategory { get; set; }
    }
}
