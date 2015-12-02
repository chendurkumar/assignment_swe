using System.Web.Http;
using Betsson.WebApi.Entities;
using Betsson.WebApi.Models;
using Betsson.WebApi.Utilities;
using log4net;

namespace Betsson.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger("EmployeeController");
        private readonly IEmployeeService _employeeService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }

        public EmployeeController(IEmployeeService service)
        {
            _employeeService = service;
        }

        // POST api/employee
        [HttpPost]
        public IHttpActionResult PostLogin([FromBody] AuthenticationEntity auth)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Model is in-valid for entry POST api/employee");
                throw WebExceptionFactory.GetBadRequestError("Model is in valid check your payload");
            }
            if (!_employeeService.AuthenticateUser(auth.username, auth.password))
            {
                Log.Info($"{auth.username} is not authenticated");
                throw WebExceptionFactory.GetBadRequestError("Model is in valid check your payload");
            }
            Log.Info($"{auth.username} has been authenticated");
            return Ok();
        }
    }
}
