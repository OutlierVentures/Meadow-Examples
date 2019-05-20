# Meadow-Examples

Examples for working with the [Meadow](https://github.com/MeadowSuite/Meadow) toolbox for Ethereum smart contracts.


# Prerequisites

Tested on Windows. Should run on Mac as well, and possibly Linux.

On Windows, install:

1. Visual Studio Code 1.29 - must be this older version due to a compatibility problem at time of writing
1. Meadow and dependencies as [described in the Meadow docs](https://github.com/MeadowSuite/Meadow)
1. Visual Studio Code extensions:
    1. Solidity Debugger (`hosho.solidity-debugger`)
    1. solidity (`juanblanco.solidity`)
    1. C# (`ms-vscode.csharp`)
    
# Running

Two demonstration contracts are included:

1. Simple HelloWorld contract from Meadow example project
1. Basic ERC20 token

And some tests for both.

Tests can be run and debugged in VS Code using Solidity debugger as [described in the Meadow docs](https://github.com/MeadowSuite/Meadow/wiki/Using-the-VSCode-Solidity-Debugger). Place breakpoints, click Debug Test, and off you go.
