using EmployeeApi.Models;
using System;
using System.Security.Claims;
using System.Web.Http;
using System.Linq;
using System.Web.Http.Cors;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        public EmployeeController()
        {
        }

        [Route("Getall")]
        [Authorize]
        public async Task<IHttpActionResult> GetAllEmployeeDetails()
        {
            try
            {
                string response = await RestServiceHelper.GetServiceData("GetAllEmployee");
                if (response.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }



        [Authorize]
        [Route("Authenticate")]
        public IHttpActionResult GetAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello " + identity);
        }

        [Authorize(Roles = "admin")]
        [Route("GetEmployeeById")]
        public IHttpActionResult GetEmployeeById(int id)
        {
            try
            {
                var data = RestServiceHelper.GetServiceData("GetEmployeeByID/" + id);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("CheckUserCredetial")]
        public async Task<IHttpActionResult> CheckUserCredential(string userName, string password)
        {
            try
            {
                var data = await RestServiceHelper.GetServiceData("CheckUserCredetial/" + userName + "/" + password);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [Authorize(Roles = "admin")]
        [Route("AddEmployee")]
        [HttpPost]
        public async Task<IHttpActionResult> AddEmployee([FromBody] Employees emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string response = await RestServiceHelper.PostServiceData("AddEmployee", emp);
                return Ok("Employee added");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
