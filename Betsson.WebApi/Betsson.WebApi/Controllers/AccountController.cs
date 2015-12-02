using System.Net;
using System.Net.Http;
using System.Web.Http;
using Betsson.WebApi.Entities;
using Betsson.WebApi.Models;
using Betsson.WebApi.Utilities;
using log4net;

namespace Betsson.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger("AccountController");
        private readonly IAccountService _accountService;

        public AccountController()
        {
            _accountService = new AccountService();
            Log.Debug("AccountService initialized");
        }

        public AccountController(IAccountService service)
        {
            _accountService = service;
            Log.Debug("AccountService initialized for Test");
        }

        //POST api/account/ - Create Account
        [HttpPost]
        public HttpResponseMessage PostAccount(NewAccountDetailEntity account)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Model is in-valid for entry POST api/account");
                throw WebExceptionFactory.GetBadRequestError("Model is in valid please check your payload");
            }
            var newAccount = _accountService.CreateAccount(account);
            Log.Info("Account has been created");
            // send response
            return Request.CreateResponse(HttpStatusCode.Created, newAccount);
        }

        //GET api/account/
        [HttpGet]
        public AccountEntity GetAccount([FromUri] int accountId)
        {
            if (accountId != 0)
            {
                return _accountService.GetAccount(accountId);
            }
            Log.Error("Model is in-valid for entry GET api/account");
            throw WebExceptionFactory.GetBadRequestError("Invalid account ID");
        }
    }
}
