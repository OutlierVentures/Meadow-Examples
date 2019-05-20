//a69e7dcd3312d5afbe2b507a0e6cc4a126d031541684e073c77687b02dee54ac
// NOTICE: Do not change this file. This file is auto-generated and any changes will be reset.
// Generated date: 2019-05-20T15:32:57 (UTC)
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
    [Meadow.Contract.SolidityContractAttribute(typeof(ERC20Basic), CONTRACT_SOL_FILE, CONTRACT_NAME)]
    public class ERC20Basic : Meadow.Contract.BaseContract
    {
        public static Lazy<byte[]> BYTECODE_BYTES = new Lazy<byte[]>(() => Meadow.Core.Utils.HexUtil.HexToBytes(GeneratedSolcData<ERC20Basic>.Default.GetSolcBytecodeInfo(CONTRACT_SOL_FILE, CONTRACT_NAME).Bytecode));
        public const string CONTRACT_SOL_FILE = "ERC20Basic.sol";
        public const string CONTRACT_NAME = "ERC20Basic";
        protected override string ContractSolFilePath => CONTRACT_SOL_FILE;
        protected override string ContractName => CONTRACT_NAME;
        private ERC20Basic(Meadow.JsonRpc.Client.IJsonRpcClient rpcClient, Meadow.Core.EthTypes.Address address, Meadow.Core.EthTypes.Address defaultFromAccount): base(rpcClient, address, defaultFromAccount)
        {
            Meadow.Contract.EventLogUtil.RegisterDeployedContractEventTypes(address.GetHexString(hexPrefix: true), typeof(TokenContract.ERC20Basic.Approval), typeof(TokenContract.ERC20Basic.Transfer));
        }

        public static async Task<ERC20Basic> At(Meadow.JsonRpc.Client.IJsonRpcClient rpcClient, Meadow.Core.EthTypes.Address address, Meadow.Core.EthTypes.Address? defaultFromAccount = null)
        {
            defaultFromAccount = defaultFromAccount ?? (await rpcClient.Accounts())[0];
            return new ERC20Basic(rpcClient, address, defaultFromAccount.Value);
        }

        public ERC20Basic()
        {
        }

        /// <summary>
        /// Deploys the contract.  <para/>
        /// </summary>
        /// <param name = "total"><c>uint256</c></param>
        /// <param name = "rpcClient">The RPC client to be used for this contract instance.</param>
        /// <param name = "defaultFromAccount">If null then the first account returned by eth_accounts will be used.</param>
        /// <returns>An contract instance pointed at the deployed contract address.</returns>
        public static async Task<ERC20Basic> Deploy(Meadow.Core.EthTypes.UInt256 total, Meadow.JsonRpc.Client.IJsonRpcClient rpcClient, Meadow.JsonRpc.Types.TransactionParams transactionParams = null, Meadow.Core.EthTypes.Address? defaultFromAccount = null)
        {
            transactionParams = transactionParams ?? new Meadow.JsonRpc.Types.TransactionParams();
            defaultFromAccount = defaultFromAccount ?? transactionParams.From ?? (await rpcClient.Accounts())[0];
            transactionParams.From = transactionParams.From ?? defaultFromAccount;
            var encodedParams = Meadow.Core.AbiEncoding.EncoderUtil.Encode(EncoderFactory.LoadEncoder("uint256", total));
            var contractAddr = await ContractFactory.Deploy(rpcClient, BYTECODE_BYTES.Value, transactionParams, encodedParams);
            return new ERC20Basic(rpcClient, contractAddr, defaultFromAccount.Value);
        }

        /// <summary>
        /// Deploys the contract.  <para/>
        /// </summary>
        /// <param name = "total"><c>uint256</c></param>
        /// <param name = "rpcClient">The RPC client to be used for this contract instance.</param>
        /// <param name = "defaultFromAccount">If null then the first account returned by eth_accounts will be used.</param>
        /// <returns>An contract instance pointed at the deployed contract address.</returns>
        public static ContractDeployer<ERC20Basic> New(Meadow.Core.EthTypes.UInt256 total, Meadow.JsonRpc.Client.IJsonRpcClient rpcClient, Meadow.JsonRpc.Types.TransactionParams transactionParams = null, Meadow.Core.EthTypes.Address? defaultFromAccount = null)
        {
            var encodedParams = Meadow.Core.AbiEncoding.EncoderUtil.Encode(EncoderFactory.LoadEncoder("uint256", total));
            return new ContractDeployer<ERC20Basic>(rpcClient, BYTECODE_BYTES.Value, transactionParams, defaultFromAccount, encodedParams);
        }

        [Meadow.Contract.EventSignatureAttribute(SIGNATURE)]
        public class Approval : Meadow.Contract.EventLog
        {
            public override string EventName => "Approval";
            public override string EventSignature => SIGNATURE;
            public const string SIGNATURE = "8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925";
            // Event log parameters.
            public readonly Meadow.Core.EthTypes.Address tokenOwner;
            public readonly Meadow.Core.EthTypes.Address spender;
            public readonly Meadow.Core.EthTypes.UInt256 tokens;
            public Approval(Meadow.JsonRpc.Types.FilterLogObject log): base(log)
            {
                // Decode the log topic args.
                Span<byte> topicBytes = MemoryMarshal.AsBytes(new Span<Meadow.Core.EthTypes.Data>(log.Topics).Slice(1));
                AbiTypeInfo[] topicTypes = new AbiTypeInfo[]{"address", "address"};
                var topicBuff = new AbiDecodeBuffer(topicBytes, topicTypes);
                DecoderFactory.Decode(topicTypes[0], ref topicBuff, out tokenOwner);
                DecoderFactory.Decode(topicTypes[1], ref topicBuff, out spender);
                // Decode the log data args.
                Span<byte> dataBytes = log.Data;
                AbiTypeInfo[] dataTypes = new AbiTypeInfo[]{"uint256"};
                var dataBuff = new AbiDecodeBuffer(dataBytes, dataTypes);
                DecoderFactory.Decode(dataTypes[0], ref dataBuff, out tokens);
                // Add all the log args and their metadata to a collection that can be checked at runtime.
                LogArgs = new(string Name, string Type, bool Indexed, object Value)[]{("tokenOwner", "address", true, tokenOwner), ("spender", "address", true, spender), ("tokens", "uint256", false, tokens)};
            }
        }

        [Meadow.Contract.EventSignatureAttribute(SIGNATURE)]
        public class Transfer : Meadow.Contract.EventLog
        {
            public override string EventName => "Transfer";
            public override string EventSignature => SIGNATURE;
            public const string SIGNATURE = "ddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef";
            // Event log parameters.
            public readonly Meadow.Core.EthTypes.Address from;
            public readonly Meadow.Core.EthTypes.Address to;
            public readonly Meadow.Core.EthTypes.UInt256 tokens;
            public Transfer(Meadow.JsonRpc.Types.FilterLogObject log): base(log)
            {
                // Decode the log topic args.
                Span<byte> topicBytes = MemoryMarshal.AsBytes(new Span<Meadow.Core.EthTypes.Data>(log.Topics).Slice(1));
                AbiTypeInfo[] topicTypes = new AbiTypeInfo[]{"address", "address"};
                var topicBuff = new AbiDecodeBuffer(topicBytes, topicTypes);
                DecoderFactory.Decode(topicTypes[0], ref topicBuff, out from);
                DecoderFactory.Decode(topicTypes[1], ref topicBuff, out to);
                // Decode the log data args.
                Span<byte> dataBytes = log.Data;
                AbiTypeInfo[] dataTypes = new AbiTypeInfo[]{"uint256"};
                var dataBuff = new AbiDecodeBuffer(dataBytes, dataTypes);
                DecoderFactory.Decode(dataTypes[0], ref dataBuff, out tokens);
                // Add all the log args and their metadata to a collection that can be checked at runtime.
                LogArgs = new(string Name, string Type, bool Indexed, object Value)[]{("from", "address", true, from), ("to", "address", true, to), ("tokens", "uint256", false, tokens)};
            }
        }

        /// <summary> <para/>Returns <c>string</c></summary>
        public EthFunc<System.String> name()
        {
            var callData = Meadow.Core.AbiEncoding.EncoderUtil.GetFunctionCallBytes("name()");
            return EthFunc.Create<System.String>(this, callData, "string", DecoderFactory.Decode);
        }

        /// <summary> <para/>Returns <c>bool</c></summary>
        /// <param name = "@delegate"><c>address</c></param>
        /// <param name = "numTokens"><c>uint256</c></param>
        public EthFunc<System.Boolean> approve(Meadow.Core.EthTypes.Address @delegate, Meadow.Core.EthTypes.UInt256 numTokens)
        {
            var callData = Meadow.Core.AbiEncoding.EncoderUtil.GetFunctionCallBytes("approve(address,uint256)", EncoderFactory.LoadEncoder("address", @delegate), EncoderFactory.LoadEncoder("uint256", numTokens));
            return EthFunc.Create<System.Boolean>(this, callData, "bool", DecoderFactory.Decode);
        }

        /// <summary> <para/>Returns <c>uint256</c></summary>
        public EthFunc<Meadow.Core.EthTypes.UInt256> totalSupply()
        {
            var callData = Meadow.Core.AbiEncoding.EncoderUtil.GetFunctionCallBytes("totalSupply()");
            return EthFunc.Create<Meadow.Core.EthTypes.UInt256>(this, callData, "uint256", DecoderFactory.Decode);
        }

        /// <summary> <para/>Returns <c>bool</c></summary>
        /// <param name = "owner"><c>address</c></param>
        /// <param name = "buyer"><c>address</c></param>
        /// <param name = "numTokens"><c>uint256</c></param>
        public EthFunc<System.Boolean> transferFrom(Meadow.Core.EthTypes.Address owner, Meadow.Core.EthTypes.Address buyer, Meadow.Core.EthTypes.UInt256 numTokens)
        {
            var callData = Meadow.Core.AbiEncoding.EncoderUtil.GetFunctionCallBytes("transferFrom(address,address,uint256)", EncoderFactory.LoadEncoder("address", owner), EncoderFactory.LoadEncoder("address", buyer), EncoderFactory.LoadEncoder("uint256", numTokens));
            return EthFunc.Create<System.Boolean>(this, callData, "bool", DecoderFactory.Decode);
        }

        /// <summary> <para/>Returns <c>uint8</c></summary>
        public EthFunc<System.Byte> decimals()
        {
            var callData = Meadow.Core.AbiEncoding.EncoderUtil.GetFunctionCallBytes("decimals()");
            return EthFunc.Create<System.Byte>(this, callData, "uint8", DecoderFactory.Decode);
        }

        /// <summary> <para/>Returns <c>uint256</c></summary>
        /// <param name = "tokenOwner"><c>address</c></param>
        public EthFunc<Meadow.Core.EthTypes.UInt256> balanceOf(Meadow.Core.EthTypes.Address tokenOwner)
        {
            var callData = Meadow.Core.AbiEncoding.EncoderUtil.GetFunctionCallBytes("balanceOf(address)", EncoderFactory.LoadEncoder("address", tokenOwner));
            return EthFunc.Create<Meadow.Core.EthTypes.UInt256>(this, callData, "uint256", DecoderFactory.Decode);
        }

        /// <summary> <para/>Returns <c>string</c></summary>
        public EthFunc<System.String> symbol()
        {
            var callData = Meadow.Core.AbiEncoding.EncoderUtil.GetFunctionCallBytes("symbol()");
            return EthFunc.Create<System.String>(this, callData, "string", DecoderFactory.Decode);
        }

        /// <summary> <para/>Returns <c>bool</c></summary>
        /// <param name = "receiver"><c>address</c></param>
        /// <param name = "numTokens"><c>uint256</c></param>
        public EthFunc<System.Boolean> transfer(Meadow.Core.EthTypes.Address receiver, Meadow.Core.EthTypes.UInt256 numTokens)
        {
            var callData = Meadow.Core.AbiEncoding.EncoderUtil.GetFunctionCallBytes("transfer(address,uint256)", EncoderFactory.LoadEncoder("address", receiver), EncoderFactory.LoadEncoder("uint256", numTokens));
            return EthFunc.Create<System.Boolean>(this, callData, "bool", DecoderFactory.Decode);
        }

        /// <summary> <para/>Returns <c>uint256</c></summary>
        /// <param name = "owner"><c>address</c></param>
        /// <param name = "@delegate"><c>address</c></param>
        public EthFunc<Meadow.Core.EthTypes.UInt256> allowance(Meadow.Core.EthTypes.Address owner, Meadow.Core.EthTypes.Address @delegate)
        {
            var callData = Meadow.Core.AbiEncoding.EncoderUtil.GetFunctionCallBytes("allowance(address,address)", EncoderFactory.LoadEncoder("address", owner), EncoderFactory.LoadEncoder("address", @delegate));
            return EthFunc.Create<Meadow.Core.EthTypes.UInt256>(this, callData, "uint256", DecoderFactory.Decode);
        }

        /// <summary>The contract fallback function. <para/></summary>
        public EthFunc FallbackFunction => EthFunc.Create(this, Array.Empty<byte>());
    }
}
