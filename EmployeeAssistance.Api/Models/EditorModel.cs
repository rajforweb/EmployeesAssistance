using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAssistance.Api.Models
{
    public class EditorModel : CategoryModel
    {
        public List<Information> Information { get; set; }
    }
}
