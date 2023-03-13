using Benefits.DbModels;
using Benefits.Helpers;
using Benefits.Models;
using Benefits.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Benefits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IBenefitsRepository _repo;
        public EmployeeController(IBenefitsRepository repo)
        {
            _repo = repo;            
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            var employees = await _repo.GetEmployees();

            ConcurrentBag<EmployeeViewModel> results = new ConcurrentBag<EmployeeViewModel>();
            Parallel.ForEach(employees, emp =>
            {
                results.Add(BenefitCostHelpers.CalculateCosts(emp));
            });
            //Can Re-order if desired.
            return Ok(results);
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<EmployeeViewModel>> GetById(int id)
        {
            Employee employee = await _repo.GetEmployeeById(id);
            if (employee == null) { return NotFound(); }
            return Ok(BenefitCostHelpers.CalculateCosts(employee));
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

    }
}

