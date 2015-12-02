using System.Net;
using System.Net.Http;
using System.Web.Http;
using Betsson.WebApi.Entities;
using Betsson.WebApi.Models;
using Betsson.WebApi.Utilities;
using log4net;

namespace Betsson.WebApi.Controllers
{
    public class TransactionController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger("TransactionController");
        private readonly IAccountService _accountService;

        public TransactionController()
        {
            _accountService = new AccountService();
            Log.Debug("AccountService for TransactionController is initialized");
        }

        public TransactionController(IAccountService accountService)
        {
            _accountService = accountService;
            Log.Debug("AccountService for TransactionController is initialized for Test");
        }

        //PUT api/transaction/ - PerformTransaction

        /// <summary>
        ///     Execute a transanction (deposit or withdrawal)
        /// </summary>
        /// <param name="id">account id</param>
        /// <param name="transaction">trasaction entity</param>
        /// <returns>Transaction entity</returns>
        [HttpPut]
        public HttpResponseMessage PutTransaction(int id, [FromBody] TransactionEntity transaction)
        {
            if (!ModelState.IsValid)
            {
                Log.Error("Model is in-valid for entry PUT api/account");
                throw WebExceptionFactory.GetBadRequestError("Model is in valid please check your payload");
            }
            if (id != transaction.AccountId)
            {
                Log.Error("Sent Id is not same as account ID");
                throw WebExceptionFactory.GetBadRequestError("Account ID is different");
            }
            var newTransaction = _accountService.ExecuteTransaction(transaction);
            return Request.CreateResponse(HttpStatusCode.Created, newTransaction);
        }

        //GET api/transaction/ 

        /// <summary>
        ///     Get the account balance details
        /// </summary>
        /// <param name="accountId">account Id</param>
        /// <returns>balance amount</returns>
        [HttpGet]
        public string GetBalance([FromUri] int accountId)
        {
            if (accountId != 0)
            {
                return _accountService.GetBalance(accountId);
            }
            Log.Error("Model is in-valid for entry GetAccount api/transaction");
            throw WebExceptionFactory.GetBadRequestError("Model is in valid please check your payload");
        }
    }
}