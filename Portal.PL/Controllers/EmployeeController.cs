using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portal.BL.Interface;
using Portal.BL.Models;
using Portal.DAL.Entity;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;

namespace Portal.PL.Controllers
{
    public class EmployeeController : Controller
    {
        #region prop
        private readonly IEmployee employee;
        private readonly Mapper mapper;
        private readonly IDepartment department;
        #endregion

        #region const
        public EmployeeController(IEmployee employee, Mapper mapper , IDepartment department)
        {
            this.employee = employee;
            this.mapper = mapper;
            this.department = department;
        }
        #endregion

        #region Actions
        public async Task<IActionResult> Index()
        {
            var data = await employee.GetAsync(x=>x. IsActive== true && x.IsDeleted == false);
            var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
            return View(result);

        }
        public async Task<IActionResult> Details(int id )
        {
            var data = await employee.GetByIdAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
            var result = mapper.Map<EmployeeVM>(data);
            var Dpt = await department.GetAsync();
            ViewBag.DepartmentList = new SelectList(Dpt, "ID", "Name", data.DepartmentID);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Creat()
        {
            var data = await department.GetAsync();
            ViewBag.DepartmentList = new SelectList(data , "Id" ,"Name" );
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Creat(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    await employee.CreatAsync(data);
                    return RedirectToAction("Employee");
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            var Dpt = await department.GetAsync();
            ViewBag.DepartmentList = new SelectList(Dpt ,"ID" ,"Name" ,model.DepartmentID);
            return View(model);
        }
       

        [HttpGet]
        public async Task<IActionResult> UpDate(int id)
        {
            var result = await employee.GetByIdAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
            var data = mapper.Map<DepartmentVM>(result);
            var Dpt = await department.GetAsync();
            ViewBag.DepartmentList = new SelectList(Dpt, "ID", "Name", result .DepartmentID);
            return View(data);
        }


        [HttpPost]
        public async Task<IActionResult> UpDate(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    await employee.UpdateAsync(data);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            var Dpt = await department.GetAsync();
            ViewBag.DepartmentList = new SelectList(Dpt, "ID", "Name", model.DepartmentID);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await employee.GetByIdAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
            var result = mapper.Map<DepartmentVM>(data);
            var Dpt = await department.GetAsync();
            ViewBag.DepartmentList = new SelectList(Dpt, "ID", "Name", data.DepartmentID);
            return View(result);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await employee.DeleteAsync(id);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            var Dpt = await department.GetAsync();
            //ViewBag.DepartmentList = new SelectList(Dpt, "ID", "Name", data.DepartmentID);
            return View();
        }
    }
    #endregion
}

