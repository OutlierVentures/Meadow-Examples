using Meadow.UnitTestTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

// Run tests in parallel.
// Set "Workers = 1" to disable parallel test execution.
[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace TokenContract
{
    [TestClass]
    public static class GlobalSetup
    {
        [AssemblyInitialize]
        public static void Init(TestContext testContext)
        {
            // Exclude sol files from coverage report (uncomment to enable).
            // Global.HideSolidityFromReport("Migrations.sol", "MockContract.sol");

            // Configure some defaults (optional).
            Global.DefaultGasLimit = 6000000;
            Global.AccountCount = 120;
            Global.AccountBalance = 2500;
            // If not set a randomly generated mnemonic is used.
            Global.AccountMnemonic = "adapt rare camp prefer vessel flock escape lounge hair oyster mask crane sister glide author";
        }

        [AssemblyCleanup]
        public static async Task Cleanup()
        {
            // Triggers coverage report generation at the end of unit test execution.
            await Global.GenerateCoverageReport();
        }

    }
}
