# ScientistConsoleApp

This is a (very contrived) example application to show the basics of how to use [Scientist.Net](https://github.com/github/Scientist.net).

This program will take a phrase passed in as command line arguments and tell you whether or not it thinks it's an actual meme. The default implementation is provided by `MemeBot2000`, which thinks only phrases with **kitty** (*case-insensitive*) in them are memes. The new implementation we want to test is implemented in `MemeBot3000`, which knows squirrels are the new hottness so only phrases with **squirrel** (*also case-insensitive*) are memes. 

The examples included only cover what I think are the most basic / essential use cases for [Scientist.Net](https://github.com/github/Scientist.net) and does not go into detail on all the functionality.

## Requirements
Install [.NET Core 2.0](https://www.microsoft.com/net/learn/get-started/) on your machine.

## Running the examples
* Clone this repository locally.
* Restore the required packages by running `dotnet restore` from the CLI at the repository root.
* Copy the code at the bottom of each example into `Program.Main(string[] args)`.
* From a CLI at the repository root, run `dotnet run [phrase]`. E.g. `dotnet run here kitty kitty` should output **'here kitty kitty' is a meme.**
