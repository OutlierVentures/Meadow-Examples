//a69e7dcd3312d5afbe2b507a0e6cc4a126d031541684e073c77687b02dee54ac
// NOTICE: Do not change this file. This file is auto-generated and any changes will be reset.
// Generated date: 2019-05-20T16:35:42 (UTC)
#pragma warning disable SA1000 // The keyword 'new' should be followed by a space

#pragma warning disable SA1003 // Symbols should be spaced correctly

#pragma warning disable SA1008 // Opening parenthesis should be preceded by a space

#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly

#pragma warning disable SA1011 // Closing square brackets should be spaced correctly

#pragma warning disable SA1012 // Opening brace should be preceded by a space

#pragma warning disable SA1013 // Closing brace should be preceded by a space

#pragma warning disable SA1024 // Colons Should Be Spaced Correctly

#pragma warning disable SA1128 // Put constructor initializers on their own line

#pragma warning disable SA1300 // Element should begin with upper-case letter

#pragma warning disable SA1307 // Field names should begin with upper-case letter

#pragma warning disable SA1313 // Parameter names should begin with lower-case letter

#pragma warning disable IDE1006 // Naming Styles

using Meadow.Contract;
using Meadow.Core.AbiEncoding;
using Meadow.Core.EthTypes;
using Meadow.Core.Utils;
using Meadow.JsonRpc.Types;
using SolcNet.DataDescription.Output;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace TokenContract
{
    /// <summary>From file ERC20Basic.sol<para/></summary>
    [Meadow.Contract.SolidityContractAttribute(typeof(SafeMath), CONTRACT_SOL_FILE, CONTRACT_NAME)]
    public class SafeMath : Meadow.Contract.BaseContract
    {
        public static Lazy<byte[]> BYTECODE_BYTES = new Lazy<byte[]>(() => Meadow.Core.Utils.HexUtil.HexToBytes(GeneratedSolcData<SafeMath>.Default.GetSolcBytecodeInfo(CONTRACT_SOL_FILE, CONTRACT_NAME).Bytecode));
        public const string CONTRACT_SOL_FILE = "ERC20Basic.sol";
        public const string CONTRACT_NAME = "SafeMath";
        protected override string ContractSolFilePath => CONTRACT_SOL_FILE;
        protected override string ContractName => CONTRACT_NAME;
        private SafeMath(Meadow.JsonRpc.Client.IJsonRpcClient rpcClient, Meadow.Core.EthTypes.Address address, Meadow.Core.EthTypes.Address defaultFromAccount): base(rpcClient, address, defaultFromAccount)
        {
            Meadow.Contract.EventLogUtil.RegisterDeployedContractEventTypes(address.GetHexString(hexPrefix: true));
        }

        public static async Task<SafeMath> At(Meadow.JsonRpc.Client.IJsonRpcClient rpcClient, Meadow.Core.EthTypes.Address address, Meadow.Core.EthTypes.Address? defaultFromAccount = null)
        {
            defaultFromAccount = defaultFromAccount ?? (await rpcClient.Accounts())[0];
            return new SafeMath(rpcClient, address, defaultFromAccount.Value);
        }

        public SafeMath()
        {
        }

        /// <summary>
        /// Deploys the contract.  <para/>
        /// </summary>
         
        /// <param name = "rpcClient">The RPC client to be used for this contract instance.</param>
        /// <param name = "defaultFromAccount">If null then the first account returned by eth_accounts will be used.</param>
        /// <returns>An contract instance pointed at the deployed contract address.</returns>
        public static async Task<SafeMath> Deploy(Meadow.JsonRpc.Client.IJsonRpcClient rpcClient, Meadow.JsonRpc.Types.TransactionParams transactionParams = null, Meadow.Core.EthTypes.Address? defaultFromAccount = null)
        {
            transactionParams = transactionParams ?? new Meadow.JsonRpc.Types.TransactionParams();
            defaultFromAccount = defaultFromAccount ?? transactionParams.From ?? (await rpcClient.Accounts())[0];
            transactionParams.From = transactionParams.From ?? defaultFromAccount;
            var encodedParams = Array.Empty<byte>();
            var contractAddr = await ContractFactory.Deploy(rpcClient, BYTECODE_BYTES.Value, transactionParams, encodedParams);
            return new SafeMath(rpcClient, contractAddr, defaultFromAccount.Value);
        }

        /// <summary>
        /// Deploys the contract.  <para/>
        /// </summary>
         
        /// <param name = "rpcClient">The RPC client to be used for this contract instance.</param>
        /// <param name = "defaultFromAccount">If null then the first account returned by eth_accounts will be used.</param>
        /// <returns>An contract instance pointed at the deployed contract address.</returns>
        public static ContractDeployer<SafeMath> New(Meadow.JsonRpc.Client.IJsonRpcClient rpcClient, Meadow.JsonRpc.Types.TransactionParams transactionParams = null, Meadow.Core.EthTypes.Address? defaultFromAccount = null)
        {
            var encodedParams = Array.Empty<byte>();
            return new ContractDeployer<SafeMath>(rpcClient, BYTECODE_BYTES.Value, transactionParams, defaultFromAccount, encodedParams);
        }

        /// <summary>The contract fallback function. <para/></summary>
        public EthFunc FallbackFunction => EthFunc.Create(this, Array.Empty<byte>());
    }
}
