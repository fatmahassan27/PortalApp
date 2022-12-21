using AutoMapper;
using Portal.BL.Models;
using Portal.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            //Recive
            CreateMap<Department,DepartmentVM>();
            //creat ..
           CreateMap<DepartmentVM, Department>();

            CreateMap<Employee, EmployeeVM>();
            //creat ..
            CreateMap<EmployeeVM, Employee>();
        }
    }
}
