//6744ba701f755a7a4449a58f993f80e83de9f2c90ca7a1bbac20b1edfef7246c
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
    /// <summary>From file HelloWorld.sol<para/></summary>
    [Meadow.Contract.SolidityContractAttribute(typeof(HelloWorld), CONTRACT_SOL_FILE, CONTRACT_NAME)]
    public class HelloWorld : Meadow.Contract.BaseContract
    {
        public static Lazy<byte[]> BYTECODE_BYTES = new Lazy<byte[]>(() => Meadow.Core.Utils.HexUtil.HexToBytes(GeneratedSolcData<HelloWorld>.Default.GetSolcBytecodeInfo(CONTRACT_SOL_FILE, CONTRACT_NAME).Bytecode));
        public const string CONTRACT_SOL_FILE = "HelloWorld.sol";
        public const string CONTRACT_NAME = "HelloWorld";
        protected override string ContractSolFilePath => CONTRACT_SOL_FILE;
        protected override string ContractName => CONTRACT_NAME;
        private HelloWorld(Meadow.JsonRpc.Client.IJsonRpcClient rpcClient, Meadow.Core.EthTypes.Address address, Meadow.Core.EthTypes.Address defaultFromAccount): base(rpcClient, address, defaultFromAccount)
        {
            Meadow.Contract.EventLogUtil.RegisterDeployedContractEventTypes(address.GetHexString(hexPrefix: true), typeof(TokenContract.HelloWorld.HelloEvent));
        }

        public static async Task<HelloWorld> At(Meadow.JsonRpc.Client.IJsonRpcClient rpcClient, Meadow.Core.EthTypes.Address address, Meadow.Core.EthTypes.Address? defaultFromAccount = null)
        {
            defaultFromAccount = defaultFromAccount ?? (await rpcClient.Accounts())[0];
            return new HelloWorld(rpcClient, address, defaultFromAccount.Value);
        }

        public HelloWorld()
        {
        }

        /// <summary>
        /// Deploys the contract.  <para/>
        /// </summary>
         
        /// <param name = "rpcClient">The RPC client to be used for this contract instance.</param>
        /// <param name = "defaultFromAccount">If null then the first account returned by eth_accounts will be used.</param>
        /// <returns>An contract instance pointed at the deployed contract address.</returns>
        public static async Task<HelloWorld> Deploy(Meadow.JsonRpc.Client.IJsonRpcClient rpcClient, Meadow.JsonRpc.Types.TransactionParams transactionParams = null, Meadow.Core.EthTypes.Address? defaultFromAccount = null)
        {
            transactionParams = transactionParams ?? new Meadow.JsonRpc.Types.TransactionParams();
            defaultFromAccount = defaultFromAccount ?? transactionParams.From ?? (await rpcClient.Accounts())[0];
            transactionParams.From = transactionParams.From ?? defaultFromAccount;
            var encodedParams = Array.Empty<byte>();
            var contractAddr = await ContractFactory.Deploy(rpcClient, BYTECODE_BYTES.Value, transactionParams, encodedParams);
            return new HelloWorld(rpcClient, contractAddr, defaultFromAccount.Value);
        }

        /// <summary>
        /// Deploys the contract.  <para/>
        /// </summary>
         
        /// <param name = "rpcClient">The RPC client to be used for this contract instance.</param>
        /// <param name = "defaultFromAccount">If null then the first account returned by eth_accounts will be used.</param>
        /// <returns>An contract instance pointed at the deployed contract address.</returns>
        public static ContractDeployer<HelloWorld> New(Meadow.JsonRpc.Client.IJsonRpcClient rpcClient, Meadow.JsonRpc.Types.TransactionParams transactionParams = null, Meadow.Core.EthTypes.Address? defaultFromAccount = null)
        {
            var encodedParams = Array.Empty<byte>();
            return new ContractDeployer<HelloWorld>(rpcClient, BYTECODE_BYTES.Value, transactionParams, defaultFromAccount, encodedParams);
        }

        [Meadow.Contract.EventSignatureAttribute(SIGNATURE)]
        public class HelloEvent : Meadow.Contract.EventLog
        {
            public override string EventName => "HelloEvent";
            public override string EventSignature => SIGNATURE;
            public const string SIGNATURE = "28843b844d4060d225bc7fb6279bd091f7ddb51b0f3d7e97947f52d3b609a2be";
            // Event log parameters.
            public readonly System.String _message;
            public readonly Meadow.Core.EthTypes.Address _sender;
            public HelloEvent(Meadow.JsonRpc.Types.FilterLogObject log): base(log)
            {
                // Decode the log topic args.
                Span<byte> topicBytes = MemoryMarshal.AsBytes(new Span<Meadow.Core.EthTypes.Data>(log.Topics).Slice(1));
                AbiTypeInfo[] topicTypes = Array.Empty<AbiTypeInfo>();
                var topicBuff = new AbiDecodeBuffer(topicBytes, topicTypes);
                // Decode the log data args.
                Span<byte> dataBytes = log.Data;
                AbiTypeInfo[] dataTypes = new AbiTypeInfo[]{"string", "address"};
                var dataBuff = new AbiDecodeBuffer(dataBytes, dataTypes);
                DecoderFactory.Decode(dataTypes[0], ref dataBuff, out _message);
                DecoderFactory.Decode(dataTypes[1], ref dataBuff, out _sender);
                // Add all the log args and their metadata to a collection that can be checked at runtime.
                LogArgs = new(string Name, string Type, bool Indexed, object Value)[]{("_message", "string", false, _message), ("_sender", "address", false, _sender)};
            }
        }

        /// <summary> <para/>Returns <c>string</c></summary>
        public EthFunc<System.String> renderHelloWorld()
        {
            var callData = Meadow.Core.AbiEncoding.EncoderUtil.GetFunctionCallBytes("renderHelloWorld()");
            return EthFunc.Create<System.String>(this, callData, "string", DecoderFactory.Decode);
        }

        /// <summary> <para/>Returns <c>uint256</c></summary>
        /// <param name = "a"><c>uint256</c></param>
        /// <param name = "b"><c>uint256</c></param>
        public EthFunc<Meadow.Core.EthTypes.UInt256> sum(Meadow.Core.EthTypes.UInt256 a, Meadow.Core.EthTypes.UInt256 b)
        {
            var callData = Meadow.Core.AbiEncoding.EncoderUtil.GetFunctionCallBytes("sum(uint256,uint256)", EncoderFactory.LoadEncoder("uint256", a), EncoderFactory.LoadEncoder("uint256", b));
            return EthFunc.Create<Meadow.Core.EthTypes.UInt256>(this, callData, "uint256", DecoderFactory.Decode);
        }

        /// <summary>The contract fallback function. <para/></summary>
        public EthFunc FallbackFunction => EthFunc.Create(this, Array.Empty<byte>());
    }
}
