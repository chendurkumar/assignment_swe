namespace Betsson.WebApi.Models
{
    public interface IEmployeeService
    {
        bool AuthenticateUser(string username, string password);
    }
}