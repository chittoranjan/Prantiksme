

using System;
using System.ComponentModel.DataAnnotations;
using PrantiksmeApp.Models.Contracts;
using PrantiksmeApp.Models.EntityModels.ProductModels;

namespace PrantiksmeApp.Models.EntityModels.PurchaseModels
{
    public class PurchaseDetails:IAuditable,IModel,IAutoCode
    {
        public long Id { get; set; }
        public long PurchaseId { get; set; }
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

        public virtual Purchase Purchase { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductSubCategory ProductSubCategory { get; set; }
        public virtual ProductItem ProductItem { get; set; }

       
    }
}
