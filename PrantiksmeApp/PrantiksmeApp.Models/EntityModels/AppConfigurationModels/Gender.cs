using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrantiksmeApp.Models.Contracts;

namespace PrantiksmeApp.Models.EntityModels
{
    public class Gender : IDeletable
    {
        public int Id { get; set; }

        [Display(Name = "Gender")]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        public bool Delete()
        {
            return IsDeleted=true;
        }
    }
}
