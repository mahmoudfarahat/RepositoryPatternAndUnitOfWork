using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryWIthUOW.Core;
using RepositoryWIthUOW.Core.Consts;
using RepositoryWIthUOW.Core.Dto;
using RepositoryWIthUOW.Core.Interfaces;
using RepositoryWIthUOW.Core.Models;

namespace RepositoryWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        //private readonly IBaseRepository<Department> _departmentRepository;

        public DepartmentsController(IUnitOfWork  unitOfWork)
        {
            _unitOfWork = unitOfWork;
         }


        [HttpGet]
        public IActionResult GetById(int id)
        {

            return Ok(_unitOfWork.Departments.GetByID(id));
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            var department = _unitOfWork.Departments.Find(b => b.Name == "Hr", new[] { "Employees" });

            var departmentDTO = new DepartmentDto
            {
                Name = department.Name,
                Employees = department.Employees.Select(e => new EmployeeDto { Name = e.Name }).ToList()
                // Include other employee properties as needed
            };

           
            return Ok(departmentDTO);
       
        }

        [HttpGet("GetAllWithEmployees")]
        public IActionResult GetAllWithEmployees()
        {
            var departments = _unitOfWork.Departments.FindAll(b => b.Name == "Hr", new[] { "Employees" });

            var departmentDTOs = departments.Select(d => new DepartmentDto
            {
                Name = d.Name,
                Employees = d.Employees.Select(e => new EmployeeDto { Name = e.Name }).ToList()
                 
            }).ToList();

            return Ok(departmentDTOs);

        }


        [HttpGet("GetAllWithEmployeesWithSKip")]
        public IActionResult GetAllWithEmployeesWithSKip()
        {
            var departments = _unitOfWork.Departments.FindAll(b => b.Name == "Hr", null, null, b => b.Id, OrderBy.Descending) ;

            //var departmentDTOs = departments.Select(d => new DepartmentDto
            //{
            //    Name = d.Name,
            //    Employees = d.Employees.Select(e => new EmployeeDto { Name = e.Name }).ToList()

            //}).ToList();

            return Ok(departments);

        }

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var department = _unitOfWork.Departments.Add(new Department { Name = "development", Description = "Nice" });
            _unitOfWork.Complete();
            return Ok(department);
        }
     

    }
}
