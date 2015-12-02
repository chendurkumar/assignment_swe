using System;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Betsson.Data;
using Betsson.WebApi.Entities;
using Betsson.WebApi.Utilities;
using log4net;

namespace Betsson.WebApi.Models
{
    public class AccountService : IAccountService
    {
        private static readonly ILog Log = LogManager.GetLogger("AccountService");
        private readonly ServiceFactory _instance = ServiceFactory.Instance;

        /// <summary>
        ///     Create a Account
        /// </summary>
        /// <param name="account">Account Object</param>
        public AccountEntity CreateAccount(NewAccountDetailEntity account)
        {
            Mapper.CreateMap<Account, AccountEntity>();
            var newAccount = new Account
            {
                Account_Balance = decimal.Parse(account.DepositAmount),
                Customer_Id = CheckCustomer(account.CustomerId),
                Account_Type = account.AccountType,
                Account_Number = GetNextAccountNumber()
            };

            try
            {
                var createdAccount = _instance.DataContext.Account.Add(newAccount);
                Commit();
                Log.Debug($"New account has been created, account number {newAccount.Account_Number}");
                Mapper.CreateMap<Account, AccountEntity>();
                return Mapper.Map<AccountEntity>(createdAccount);
            }
            catch (InvalidOperationException e)
            {
                const string msg = "Error occured while creating account";
                throw WebExceptionFactory.GetBadRequestError(msg, e);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Log.Error(
                        $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Log.Error($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                throw WebExceptionFactory.GetBadRequestError("Database error", e);
            }
            catch (HttpResponseException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw WebExceptionFactory.GetServerError(ex.Message);
            }
        }

        /// <summary>
        ///     GetAccount a account details
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <returns></returns>
        public AccountEntity GetAccount(int accountId)
        {
            try
            {
                var account = _instance.DataContext.Account.FirstOrDefault(acc => acc.Account_Id.Equals(accountId));
                Mapper.CreateMap<Account, AccountEntity>();
                return Mapper.Map<AccountEntity>(account);
            }
            catch (ArgumentNullException ex)
            {
                const string msg = "Error occured while retrieving the account";
                WebExceptionFactory.GetBadRequestError(msg, ex);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Log.Error(
                        $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Log.Error($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                throw WebExceptionFactory.GetBadRequestError("Database error", e);
            }
            catch (HttpResponseException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw WebExceptionFactory.GetServerError(ex.Message);
            }
            return null;
        }

        /// <summary>
        ///     Execute a transaction
        /// </summary>
        /// <param name="transaction">Transaction object</param>
        public TransactionEntity ExecuteTransaction(TransactionEntity transaction)
        {
            try
            {
                var account =
                    _instance.DataContext.Account.FirstOrDefault(a => a.Account_Id.Equals(transaction.AccountId));
                if (account == null)
                {
                    throw WebExceptionFactory.GetNotFoundError("Account not found");
                }
                if (transaction.IsDeposit)
                {
                    account.Account_Balance += transaction.Amount;
                }
                else
                {
                    if (account.Account_Balance < transaction.Amount)
                    {
                        throw WebExceptionFactory.GetBadRequestError(
                            "Low availble funds cannot execute the transaction.");
                    }
                    account.Account_Balance -= transaction.Amount;
                }

                // Create a transaction 
                var trans = new Transaction
                {
                    Account_Id = transaction.AccountId,
                    Amount = transaction.Amount,
                    Transaction_Type = transaction.IsDeposit ? 1 : 2,
                    Message = transaction.Message,
                    Details = transaction.Details,
                    Timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                };
                var newTransaction = _instance.DataContext.Transaction.Add(trans);
                Log.Info($"new transaction has been created with id {newTransaction.Transaction_Id}");
                Commit();
                Mapper.CreateMap<Transaction, TransactionEntity>();
                return Mapper.Map<TransactionEntity>(newTransaction);
            }
            catch (ArgumentNullException ex)
            {
                const string msg = "Error occured while executing a transaction in the account";
                throw WebExceptionFactory.GetBadRequestError(msg, ex);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Log.Error(
                        $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Log.Error($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                throw WebExceptionFactory.GetBadRequestError("Database error", e);
            }
            catch (HttpResponseException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw WebExceptionFactory.GetServerError(ex.Message);
            }
        }

        /// <summary>
        ///     GetAccount the balance details
        /// </summary>
        /// <param name="accountId">account id</param>
        /// <returns>balance</returns>
        public string GetBalance(int accountId)
        {
            try
            {
                var account =
                    _instance.DataContext.Account.FirstOrDefault(a => a.Account_Id.Equals(accountId));
                if (account == null)
                {
                    throw WebExceptionFactory.GetNotFoundError("Account not found");
                }

                return account.Account_Balance.ToString(CultureInfo.InvariantCulture);
            }
            catch (ArgumentNullException ex)
            {
                const string msg = "Error occured while executing a transaction in the account";
                throw WebExceptionFactory.GetBadRequestError(msg, ex);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Log.Error(
                        $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Log.Error($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                throw WebExceptionFactory.GetBadRequestError("Database error", e);
            }
            catch (HttpResponseException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw WebExceptionFactory.GetServerError(ex.Message);
            }
        }

        /// <summary>
        ///     Check if the customer exsist.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>customer id</returns>
        private int CheckCustomer(string customerId)
        {
            int custId;
            try
            {
                custId = int.Parse(customerId);
            }
            catch (Exception ex)
            {
                throw WebExceptionFactory.GetBadRequestError($"Invalid Customer ID {customerId}", ex);
            }
            if (custId == 0)
            {
                throw WebExceptionFactory.GetBadRequestError("Customer ID cannot be zero");
            }
            var customer = _instance.DataContext.Customer.FirstOrDefault(x => x.Customer_Id.Equals(custId));
            if (customer == null) // new customer
            {
                throw WebExceptionFactory.GetNotFoundError(
                    $"Customer with id {customerId} dont exist, please create new customer");
            }
            return customer.Customer_Id;
        }

        /// <summary>
        ///     GetAccount next account number
        /// </summary>
        /// <returns></returns>
        private string GetNextAccountNumber()
        {
            var randomNumber = new Random().Next(0, 1000000).ToString("D5");
            var accountNumber = $"1234-{randomNumber}";
            var accountAlreadyExist = _instance.DataContext.Account.Any(x => x.Account_Number.Equals(accountNumber));
            return accountAlreadyExist ? GetNextAccountNumber() : accountNumber;
        }

        /// <summary>
        ///     Save the changed to the DB.
        /// </summary>
        private void Commit()
        {
            _instance.DataContext.SaveChanges();
        }
    }
}