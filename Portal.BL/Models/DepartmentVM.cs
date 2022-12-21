using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.BL.Models
{
    public class DepartmentVM
    {
      
        public int ID { get; set; }
        [Required(ErrorMessage ="this elemnt is required")]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "this elemnt is required")]
        [MaxLength(50)]
        public string? Code { get; set; }
    }
}
