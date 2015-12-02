using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Betsson.WebApi.Controllers;
using Betsson.WebApi.Entities;
using Betsson.WebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Betsson.WebApi.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTests
    {
        private const string Localhost = "localhost:60000";

        [TestMethod]
        public void PostTransactionTest()
        {
            var newAccountDetails = new NewAccountDetailEntity
            {
                AccountType = "Fixed Deposit",
                CustomerId = "3",
                DepositAmount = "1000"
            };

            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(ser => ser.CreateAccount(newAccountDetails)).Returns(new AccountEntity
            {
                Account_Id = 101,
                Account_Balance = 1000,
                Account_Number = "1234-12345",
                Account_Type = "Fixed Deposit",
                Customer_Id = 3
            });

            var controller = new AccountController(accountServiceMock.Object)
            {
                Configuration = new HttpConfiguration(),
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"http://{Localhost}/api/account")
                }
            };
            controller.Configuration.MapHttpAttributeRoutes();
            controller.Configuration.EnsureInitialized();
            controller.RequestContext.RouteData = new HttpRouteData(new HttpRoute(), new HttpRouteValueDictionary
            {
                {"controller", "Account"}
            });
            var httpResponse = controller.PostAccount(newAccountDetails);
            var createdAccount = httpResponse.Content.ReadAsAsync<AccountEntity>().Result;
            Assert.IsNotNull(createdAccount, "Created account was null or empty");
            Assert.AreEqual(createdAccount.Account_Id, 101, "Account ID are not same");
            Assert.AreEqual(createdAccount.Account_Balance, 1000, "Account balance are not same");
            Assert.AreEqual(createdAccount.Customer_Id, 3, "Customer ID are not same");
            Assert.AreSame(createdAccount.Account_Number, "1234-12345", "Account number are not same");
            Assert.AreSame(createdAccount.Account_Type, "Fixed Deposit", "Account type are not same");
        }

        [TestMethod]
        public void GetAccountTest()
        {
            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(ser => ser.GetAccount(1))
                .Returns(new AccountEntity
                {
                    Account_Id = 1,
                    Account_Number = "1234-12345",
                    Account_Type = "Deposit",
                    Account_Balance = 1000,
                    Customer_Id = 2,
                    Deleted = false
                });
            var controller = new AccountController(accountServiceMock.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var accountDetail = controller.GetAccount(1);
            Assert.AreEqual(accountDetail.Account_Id, 1);
            Assert.AreEqual(accountDetail.Account_Number, "1234-12345");
            Assert.AreEqual(accountDetail.Account_Type, "Deposit");
            Assert.AreEqual(accountDetail.Account_Balance, 1000);
            Assert.AreEqual(accountDetail.Customer_Id, 2);
            Assert.AreEqual(accountDetail.Deleted, false);
        }
    }
}