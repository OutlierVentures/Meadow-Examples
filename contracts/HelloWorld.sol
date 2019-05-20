pragma solidity ^0.4.24;

contract HelloWorld {

    event HelloEvent(string _message, address _sender);
    // string hello;

    // constructor () public {
    //     hello = renderHelloWorld();
    //     uint a = 1;
    //     uint b = 2;
    //     uint c;
    //     c = sum(a, b);
    //     address s = msg.sender;
    //     renderHelloWorld();
    // }

    function renderHelloWorld () public returns  (string memory) {
        emit HelloEvent("Hello world", msg.sender);
        return "Hello world";
    }

    function sum(uint a, uint b) public returns (uint) {
        return a + b;
    }

}
