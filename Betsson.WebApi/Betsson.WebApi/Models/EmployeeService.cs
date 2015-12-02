using System.Linq;

namespace Betsson.WebApi.Models
{
    public class EmployeeService : IEmployeeService
    {
        public bool AuthenticateUser(string username, string password)
        {
            return
                ServiceFactory.Instance.DataContext.Employee.Select(
                    emp => emp.Username.Equals(username) && emp.Password.Equals(password)).Any();
        }
    }
}