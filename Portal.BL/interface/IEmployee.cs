using Portal.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portal.BL.Interface
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>> filter = null);
        Task<Employee> GetByIdAsync(Expression<Func<Employee, bool>> filter = null);
        Task CreatAsync(Employee obj);
        Task UpdateAsync(Employee obj);
        Task DeleteAsync(int id);
    }
}
