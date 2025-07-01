## Introduction
This solution shows:

1. how precise sizing of UI elements can be done without having to take into account the sizes of all the different bars that are available on the different platforms.
2. A Tab Control that doesn't switch between pages and underlines the title of the active tab
3. A readonly text display withpx-8USERLIMITS01out scrollbars that scrolls horizontally when the text doesn't fit anymore. 

This file only contains the overall structure of the solution. The other .md files contain the specific documentation for that control.

I have included a part of the source code that I used for my mobile application Smart Letter Board, which can be found on
https://smartletterboard.com


## Architecture
The architecture is copied from the original project. The different components are as loosely coupled as possible.

Byte217.MAUI.Core
Extensions on .NET classes. E.g. StringExtensions

Byte217.MAUI.Models
Models generated with EF Core, extensions and everything model related on project level

Byte217.MAUI.ObservableModels
These models needed to be observable. Changes on these models trigger a refresh of the UI elements they are bound to. 

Byte217.MAUI.ViewModels
This contains the MainViewModel that is used to tie everything together. This uses the Community.Toolkit.Mvvm for Observability.

Byte217.MAUI.Application.Maui
This contains the presentation layer, MAUI and platform specific code. 

I have to mention that only the Byte217.MAUI.Application.Maui project contains the MAUI specific NuGet packages. For calculating the Page Layouts I needed to know some platform specific characteristics, like idiom (phone or table) and platform (iOS or not). By passing this data from the Application layer into the ViewModel layer, I can keep the latter free from platform specific, higher level NuGet packages.

Similarly, I didn't want to include Observability to my datamodel classes, as this is only useful in a MVVM scenario. In the Smart Letter Board application I have added a Services project that uses the Models to persist the data to the database. Observability on the models would be redundant here. The ObservableModels project is used to fill the gap for only those models that need it.


Ed Schimmel
Byte217