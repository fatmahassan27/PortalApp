using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.DAL.Entity
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(20)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public double Salary { get; set; }
        //12-streetName-City-Country
        [RegularExpression("[1-9]{1,5}-[a-zA-Z]{1,10}- [a-zA-Z]{1,10}-[a-zA-Z]{1,10}", ErrorMessage ="")]
        public string Address { get; set; }

        public DateTime HireDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public bool IsUpdated { get; set; }
        public DateTime DeleteDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreationDate { get; set; }


        public int DepartmentID { get; set; }
        //navegation property
        public Department? Department { get; set; }




    }
}
