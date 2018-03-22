# Ooui.Samples
Sample demonstrating the use of SignalR within Xamarin forms inside of a WebAssembly using Ooui

## Binding Issue
Seems like this could be the reason the UI isn't updating... https://github.com/praeclarum/Ooui/issues/113

## Windows Notes - 3/2018
* Ooui.AspNetCore.SignalR isn't building for me on Windows 10 / Visual Studio 2017 15.7.0 Preview 2. It seems like some silly issue with framework versions. (Probably my machine)
* Without some network changes, you'll have to run as administrator for the Ooui.WebAssembly project to be able to bind ports without access denied issues.

## Mac Notes
* Nothing so far
