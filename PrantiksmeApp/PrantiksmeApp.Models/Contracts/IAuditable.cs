using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrantiksmeApp.Models.Contracts
{
    public interface IAuditable
    {
        DateTime CreatedOn { get; set; }
        long CreatedBy { get; set; }
        DateTime? ModifiedOn { get; set; }
        long? ModifiedBy { get; set; }
    }
}
