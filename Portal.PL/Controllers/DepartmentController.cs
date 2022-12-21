using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Portal.BL.Interface;
using Portal.BL.Models;
using Portal.BL.Repository;
using Portal.DAL.Entity;

namespace Portal.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment department;
        private readonly IMapper mapper;

        public DepartmentController(IDepartment _department , IMapper mapper)
        {
            this.department = _department;
            this.mapper = mapper;
        }   

      
        public  async Task<IActionResult> Department()
        {
            var data =  await department.GetAsync();
            var result = mapper.Map< IEnumerable<DepartmentVM>>(data);
            return View(result);

        }
        [HttpGet]
        public IActionResult Creat()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  Creat(DepartmentVM model)
        {
            try
            {
                if(ModelState.IsValid)
                    {
                    var data = mapper.Map<Department>(model);
                    await department.CreatAsync(data);
                    return RedirectToAction("Department");
                }
            
            }catch(Exception ex)
            {
                TempData["error"]=ex.Message;   
            }
            return View(model);
        }
        public  async Task<IActionResult> Details(int id)
        {
            var data = await department.GetByIdAsync(id);
            var result = mapper.Map<DepartmentVM>(data);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> UpDate(int id)
        {
            var result = await department.GetByIdAsync(id);
            var data =mapper.Map<DepartmentVM>(result);  
            return View(data);
        }


        [HttpPost]   
        public async Task<IActionResult> UpDate(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {   var data=mapper.Map<Department>(model);
                    await department.UpdateAsync(data);
                    return RedirectToAction("Department");
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await department.GetByIdAsync(id);
            var result = mapper.Map<DepartmentVM>(data);
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
                    await department.DeleteAsync(id);
                    return RedirectToAction("Department");
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }
    }
}
