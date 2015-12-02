using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using Betsson.WebApi.Controllers;
using Betsson.WebApi.Entities;
using Betsson.WebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Betsson.WebApi.Tests.Controllers
{
    [TestClass]
    public class TransactionControllerTests
    {
        private const string Localhost = "localhost:60000";
        [TestMethod]
        public void PutTransactionTest()
        {
            var transaction = new TransactionEntity
            {
                AccountId = 3,
                Amount = 100,
                Details = "Test Details",
                IsDeposit = true,
                Message = "Test Transaction"
            };
            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(ser => ser.ExecuteTransaction(transaction)).Returns(transaction);

            var controller = new TransactionController(accountServiceMock.Object)
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
                {"controller", "Transaction"}
            });
           
            var httpResponse = controller.PutTransaction(3, transaction);
            var trans = httpResponse.Content.ReadAsAsync<TransactionEntity>().Result;
            Assert.IsNotNull(trans, "Transaction was NULL");
            Assert.AreEqual(trans.AccountId, 3, "Account ID was different");
        }

        [TestMethod]
        public void GetBalanceTest()
        {
            const string inputResult = "1000";
            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(ser => ser.GetBalance(1)).Returns(inputResult);
            var controller = new TransactionController(accountServiceMock.Object);
            var outputResult = controller.GetBalance(1);
            Assert.AreSame(inputResult, outputResult, "Output result is not same as input");
        }
    }
}
