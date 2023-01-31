using AngularCRUDApi.DAL;
using AngularCRUDApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularCRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class casCadingsController : ControllerBase
    {
        private readonly SqlDatabaseContext sqlDatabaseContext;

        public casCadingsController(SqlDatabaseContext sqlDatabaseContext)
        {
            this.sqlDatabaseContext = sqlDatabaseContext;
        }
        [HttpGet("getAllCountryList")]
        public ActionResult<IEnumerable<Country>> getAllCountryList()
        {
            var countrylist = sqlDatabaseContext.Country.ToList();
            return Ok(countrylist);
        }
        [HttpGet("getAllStateList")]
        public ActionResult<IEnumerable<State>> getAllStateList()
        {
            var statelist = sqlDatabaseContext.State.ToList();
            return Ok(statelist);
        }
        [HttpGet("GetStateById/{countryId}")]
        public ActionResult<IEnumerable<State>> GetStateById(int countryId)
        {

            var stateId = sqlDatabaseContext.State.Where(s => s.CountryId == countryId)
                .Select(x => new 
                {
                     x.StateId,
                     x.StateName
                }).ToList();
            if (stateId != null)
            {
                return Ok(stateId);
            }
            else
                return BadRequest();

        }
        [HttpGet("GetCityBystateId/{stateId}")]
        public ActionResult<IEnumerable<City>> GetCityBystateId(int stateId)
        {
            var cityId=sqlDatabaseContext.City.Where(c=>c.StateId==stateId)
                .Select(x=>new { x.cityId,x.cityName }).ToList();
            if(cityId!=null)
            {
                return Ok(cityId);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
