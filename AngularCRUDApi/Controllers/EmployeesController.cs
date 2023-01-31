using AngularCRUDApi.DAL;
using AngularCRUDApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularCRUDApi.Controllers
{
    [EnableCors("angularcorsapp")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly SqlDatabaseContext sqlDatabaseContext;

        public EmployeesController(SqlDatabaseContext sqlDatabaseContext)
        {
            this.sqlDatabaseContext = sqlDatabaseContext;
        }
        [HttpGet()]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            var employeeData = sqlDatabaseContext.Employee.ToList();
            if (employeeData != null)
            {
                return Ok(employeeData);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Employee> GetId(int id)
        {
            var emp = sqlDatabaseContext.Employee.Where(a => a.id == id).FirstOrDefault();
            if (emp != null)
            {
                return Ok(emp);
            }
            else
                return NotFound();
        }
        [HttpPost()]
        public ActionResult<Employee> Post(Employee emp)
        {
            if (ModelState.IsValid)
            {
                sqlDatabaseContext.Employee.Add(emp);
                sqlDatabaseContext.SaveChanges();
                return CreatedAtAction("GetId", new { id = emp.id }, emp); ;
            }
            else
                return BadRequest(ModelState.Values);

        }
        [HttpPut()]
        public ActionResult<Employee> Put(int id, Employee emp)
        {
            if (ModelState.IsValid)
            {
                if (id!=null)
                {
                    sqlDatabaseContext.Employee.Update(emp);
                    sqlDatabaseContext.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            return BadRequest(ModelState.Values);

        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var empId = sqlDatabaseContext.Employee.Find(id);
            if (empId != null)
            {
                sqlDatabaseContext.Employee.Remove(empId);
                sqlDatabaseContext.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
