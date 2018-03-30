# Ooui.Samples
Sample demonstrating the use of SignalR within Xamarin forms inside of a WebAssembly using Ooui

# Using Ooui version 0.9.206

## Issues
## ViewModel via XAML issue 
* https://github.com/praeclarum/Ooui/issues/123
* Entry.Text = string.Empty; isn't reflected in the UI for some reason. The ItemsSource bindings was fixed by Praeclarum

## Windows Notes - 3/2018
* Using Core 2.1 Preview 1 - https://github.com/dotnet/core/blob/master/release-notes/download-archives/2.1.0-preview1-download.md
* Without some network changes, you'll have to run as administrator for the Ooui.WebAssembly project to be able to bind ports without access denied issues.

## Mac Notes
* Nothing yet
