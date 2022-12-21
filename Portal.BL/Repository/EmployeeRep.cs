using Microsoft.EntityFrameworkCore;
using Portal.BL.Interface;
using Portal.DAL.DataBase;
using Portal.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portal.BL.Repository
{
    public class EmployeeRep : IEmployee
    {
        readonly ApplicationDBContext db;
        public EmployeeRep(ApplicationDBContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>> filter = null)
        {
            if(filter !=null)
                return await db.Employee.Where(filter).Include("Department").ToListAsync();
            else
            return await db.Employee.Include("Department").ToListAsync(); 
        }

        public async Task<Employee> GetByIdAsync(Expression<Func<Employee, bool>> filter = null)
        {
            var data = await db.Employee.Where(filter).Include("Department").FirstOrDefaultAsync();
            return data;
        }
        public async Task CreatAsync(Employee obj)
        {
           
            await db.Employee.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee obj)
        {
           
            obj.IsUpdated = true;

            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var oldData = db.Employee.Find(id);
            oldData.IsDeleted = true;
            oldData.DeleteDate = DateTime.Now;
            await db.SaveChangesAsync();
        }

        
    }
}
