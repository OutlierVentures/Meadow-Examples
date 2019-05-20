//1cb13aee9c41456d74cca76b90cdc9c4a37d0c03009985d657bab9652fa9cbcf
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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Meadow.JsonRpc.Types;

namespace TokenContract
{
    public static class ContractEventLogHelper
    {
        public static Meadow.Contract.EventLog Parse(string eventSignatureHash, Meadow.JsonRpc.Types.FilterLogObject log)
        {
            var eventLog = Meadow.Contract.EventLogUtil.Parse(eventSignatureHash, log);
            if (eventLog != null)
            {
                return eventLog;
            }

            // Switch on the event signature hash and the number of indexed event arguments.
            switch (eventSignatureHash + "_" + (log.Topics.Length - 1).ToString("00", CultureInfo.InvariantCulture))
            {
                case "8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925_02":
                    return new TokenContract.ERC20Basic.Approval(log);
                case "ddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef_02":
                    return new TokenContract.ERC20Basic.Transfer(log);
                case "28843b844d4060d225bc7fb6279bd091f7ddb51b0f3d7e97947f52d3b609a2be_00":
                    return new TokenContract.HelloWorld.HelloEvent(log);
                default:
                    return null;
            }
        }
    }
}
