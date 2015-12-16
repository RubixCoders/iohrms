using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntities
{
    public class EmployeeBE
    {
        public int EmpId { get; set; }
        public string UserId { get; set; }

        [Required]
        [Display(Name="Employee Code")]
        public string EmpCode { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Designation")]
        public string Designation { get; set; }

        [Display(Name = "Permanent")]
        public bool IsPermanent { get; set; }

        [Display(Name = "Salary")]
        public double? Salary { get; set; }
        
        public string EmpImage { get; set; }
    }

    public class EmployeeListBE
    {
        public List<EmployeeBE> EmployeeList { get; set; }
        public int Count { get; set; }
    }
}
