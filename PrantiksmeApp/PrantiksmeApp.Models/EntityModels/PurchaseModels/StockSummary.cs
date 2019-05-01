using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrantiksmeApp.Models.Contracts;
using PrantiksmeApp.Models.EntityModels.ProductModels;

namespace PrantiksmeApp.Models.EntityModels.PurchaseModels
{
    public class StockSummary:IAuditable,IModel,IAutoCode
    {
        public long Id { get; set; }
        public long ProductCategoryId { get; set; }
        public long? ProductSubCategoryId { get; set; }
        public long ProductItemId { get; set; }
        public long SalesStoreId { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }

        [Required(ErrorMessage = "Code Is Required.")]
        public string UniversalCode { get; set; }

        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductSubCategory ProductSubCategory { get; set; }
        public virtual ProductItem ProductItem { get; set; }
        public virtual SalesStore SalesStore { get; set; }

        
    }
}
