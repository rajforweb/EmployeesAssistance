using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAssistance.Models
{
    public class CategoryModel
    {
        [Required]
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        [Required]
        public string Category { get; set; }
        public string SubCategory { get; set; }
    }
}
