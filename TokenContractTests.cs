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
            // Execute the renderHelloWorld function as a transaction and get the 
            var eventLog = await _contract.transfer(Accounts[2], 33);

            var balance = await _contract.balanceOf(Accounts[2]).Call();

            // Validate the balance is what we expect.
            Assert.AreEqual(33, balance);

            // Transfer some tokens back
            var _contractFromAccount2 = await ERC20Basic.At(RpcClient, _contract.ContractAddress, Accounts[2]);
            
            var transferResult = await _contractFromAccount2.transfer(Accounts[3], 10);

            var balanceOfAccount2 = await _contract.balanceOf(Accounts[2]).Call();
            var balanceOfAccount3 = await _contract.balanceOf(Accounts[3]).Call();

            // Validate the balance is what we expect.
            Assert.AreEqual(10, balanceOfAccount3);
            Assert.AreEqual(23, balanceOfAccount2);
        }
    }
}
