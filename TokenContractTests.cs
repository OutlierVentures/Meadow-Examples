using Meadow.Contract;
using Meadow.JsonRpc.Types;
using Meadow.UnitTestTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TokenContract
{
    // Inherit from 'ContractTest' to be provided with an RpcClient, 
    // Accounts, and several other useful features.
    [TestClass]
    public class TokenContractTests : ContractTest
    {
        ERC20Basic _contract;

        // Method is ran before each test (all tests are ran in isolation).
        // This is an appropriate area to do contract deployment.
        protected override async Task BeforeEach()
        {
            // Deploy contract.
            _contract = await ERC20Basic.New(1000, RpcClient);
        }


        [TestMethod]
        public async Task ValidateTransferResult()
        {
            // Execute a transfer from the default account (Account 0) to account 2, and get the transaction result.
            var eventLog = await _contract.transfer(Accounts[2], 33);

            var balance = await _contract.balanceOf(Accounts[2]).Call();

            // Validate the balance is what we expect.
            Assert.AreEqual(33, balance);

            var balanceOfAccount0 = await _contract.balanceOf(Accounts[0]).Call();
            Assert.AreEqual(967, balanceOfAccount0);

            // Transfer some tokens back. First get us an interface to the contract from account 2.
            var _contractFromAccount2 = await ERC20Basic.At(RpcClient, _contract.ContractAddress, Accounts[2]);

            // Now transfer some tokens using this contract interface. This should transfer some tokens
            // from account 2 to account 3.
            var transferResult = await _contractFromAccount2.transfer(Accounts[3], 10);


            var balanceOfAccount2 = await _contract.balanceOf(Accounts[2]).Call();
            var balanceOfAccount3 = await _contract.balanceOf(Accounts[3]).Call();

            // Validate the balances are what we expect.
            Assert.AreEqual(10, balanceOfAccount3);
            Assert.AreEqual(23, balanceOfAccount2);
        }

        [TestMethod]
        public async Task TestDeploy()
        {
            // TODO: get a valid connection to Kovan/other networks. Currently 0 accounts
            var kovanClient = Meadow.JsonRpc.Client.JsonRpcClient.Create(new System.Uri("https://kovan.infura.io:443"), 1000000, 6000000);

            var deployResult = await ERC20Basic.Deploy(1000, kovanClient);
        }
    }
}
