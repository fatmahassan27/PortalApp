using Microsoft.EntityFrameworkCore;
using Portal.BL.Interface;
using Portal.BL.Models;
using Portal.DAL.DataBase;
using Portal.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.BL.Repository
{
    public class DepartmentRep : IDepartment
    {
        private readonly ApplicationDBContext db;
        public DepartmentRep(ApplicationDBContext db)
        {
            this.db = db;
        }

         public async Task<IEnumerable<Department>> GetAsync()
        {
            var data =  await db.Department.ToListAsync();
            return data;
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            var data = await db.Department.Where(x=> x.ID==id).FirstOrDefaultAsync();
            return data;
        }
        public async Task CreatAsync(Department obj )
        {

           await db.Department.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Department obj)
        {
            db.Entry(obj).State= EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Department obj)
        {
            var oldData = db.Department.Find(obj.ID);
            db.Department.Remove(oldData);
            await db.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
