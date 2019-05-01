using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrantiksmeApp.Models.EntityModels
{
    public class Gender
    {
        public int Id { get; set; }

        [Display(Name = "Gender")]
        public string Name { get; set; }
    }
}
