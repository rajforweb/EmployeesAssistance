using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAssistance.Api.Models
{
    public class CategoryModel
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }

    }
}
