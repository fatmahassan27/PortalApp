using Portal.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.BL.Models
{
    public class EmployeeVM
    {
        public EmployeeVM() 
        {
            IsActive = true;
             IsDeleted=false;
            CreationDate= DateTime.Now; 
        } 
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="this Element is Required")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage ="Email Invalid")]
        public string? Email { get; set; }
        public string? Notes { get; set; }
        [Range(200,10000)]
        public double Salary { get; set; }
        //12-streetName-City-Country

        [RegularExpression("[1-9]{1,5}-[a-zA-Z]{1,10}- [a-zA-Z]{1,10}-[a-zA-Z]{1,10}", ErrorMessage = "Enter Like:12-streetName-City-Country")]
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
