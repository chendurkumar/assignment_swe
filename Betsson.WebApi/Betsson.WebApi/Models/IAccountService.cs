using System.Collections.Generic;
using Betsson.WebApi.Entities;

namespace Betsson.WebApi.Models
{
    public interface IAccountService
    {
        AccountEntity CreateAccount(NewAccountDetailEntity account);
        AccountEntity GetAccount(int accountId);
        void ExecuteTransaction(TransactionEntity transaction);
        string GetBalance(int accountId);
    }
}