using System;
using System.ComponentModel.DataAnnotations;
using PrantiksmeApp.Models.Contracts;
using PrantiksmeApp.Models.EntityModels.ProductModels;

namespace PrantiksmeApp.Models.EntityModels.SalesModels
{
    public class SalesDetails:IAuditable,IAutoCode
    {
        public long Id { get; set; }
        public long SalesId { get; set; }
        public long ProductCategoryId { get; set; }
        public long? ProductSubCategoryId { get; set; }
        public long ProductItemId { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }

        [Required(ErrorMessage="Code Is Required.")]
        public string UniversalCode { get; set; }


        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }

        public virtual Sales Sales { get; set; }
        public virtual ProductSubCategory ProductSubCategory { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductItem ProductItem { get; set; }

    }
}
