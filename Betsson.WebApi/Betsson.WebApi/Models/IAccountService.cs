using Betsson.WebApi.Entities;

namespace Betsson.WebApi.Models
{
    public interface IAccountService
    {
        AccountEntity CreateAccount(NewAccountDetailEntity account);
        AccountEntity GetAccount(int accountId);
        TransactionEntity ExecuteTransaction(TransactionEntity transaction);
        string GetBalance(int accountId);
    }
}