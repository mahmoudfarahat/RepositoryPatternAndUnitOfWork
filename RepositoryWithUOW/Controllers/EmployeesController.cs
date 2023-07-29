using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryWIthUOW.Core.Interfaces;
using RepositoryWIthUOW.Core.Models;

namespace RepositoryWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly  IBaseRepository<Employee> _employeeRepository;

        public EmployeesController(IBaseRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [HttpGet]
        public  IActionResult GetById(int id) { 
        
        return Ok(_employeeRepository.GetByID(id));
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetByIdAysc(int id)
        {

            return Ok(await _employeeRepository.GetByIDAysc(id));
        }

        [HttpGet("GetAll")]
        public IActionResult  GetAll()
        {

            return Ok(_employeeRepository.GetAll());
        }

   

    }
}
