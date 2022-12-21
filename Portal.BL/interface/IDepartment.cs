using Portal.BL.Models;
using Portal.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Portal.BL.Interface;

namespace Portal.BL.Interface
{
    public interface IDepartment
    {
        Task<IEnumerable<Department>> GetAsync();
        Task<Department> GetByIdAsync(int id);
        Task CreatAsync(Department obj);
        Task UpdateAsync(Department obj);
        Task DeleteAsync(Department obj);
        Task DeleteAsync(int id);
    }
}
