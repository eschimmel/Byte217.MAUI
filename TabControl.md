## Introduction

This solution shows how to show a tab control with an underlined title for the active tab. The tab bar and the tabs can be positioned independently.


## Problem
Many developers have created a Tab Control and there are many ways to achieve the goal. My challenge was to underline the text of the active tab on all the platforms. Underlining the text gives a good user experience, because it clearly indicates which tab is the active one. The standard tab control works on pages and used the AppShell component. In my case, I wanted multiple tabs on one page and not multiple pages controlled by a TabbedPage. On my page I have a TabControl with three tabs.


## Solution
Five parts in the code are important:

File: Byte217.MAUI.ViewModels/MainViewModel.cs
The MainViewModel controls the display of the active tab using RelayCommands and ObservableProperties. Each tab is bound to a RelayCommand and is shown when the Observable property indicates it. As an example, 
the DictionaryPress() command sets the ShowDictionary property to true and the others to false.

File: Byte217.MAUI.Application.Maui/Controls/TabBar.cs
The TabBar contains a button for each tab. Each button is bound to its corresponding RelayCommand
Underneath each button, there is a Rectangle that only shows if the tab is active. The display of the Rectangle is controlled by its corresponding ObservableProperty. I had to add some platform-specific code to make this work on all platforms, but it is still very few.

File: Byte217.MAUI.Application.Maui/Controls/DictionaryTab.cs
File: Byte217.MAUI.Application.Maui/Controls/HistoryTab.cs
File: Byte217.MAUI.Application.Maui/Controls/KeyboardSettings.cs
These are the tabs with their own content and functionality. I have bound them all to the same ViewModel, because this allows me to make changes on all the different tabs and save the changes by pressing a Save button outside of the tabs.

File: Byte217.MAUI.Application.Maui/Controls/TabControl.cs
The TabControl itself is simply a container that holds the tabs and can be used to position them on the page.

File: Byte217.MAUI.Application.Maui/Pages/SettingsPage.cs
As you can see on the SettingsPage, the TabBar and the TabControl are positioned at different locations. In my case, the TabBar is on top of the tabs, but switching it to a different row would place it underneath the tabs.
I had to add some platform-specific code to the OnAppearing() method to decrease the TabBar row for iOS. For other platforms, I had to ensure that my ScrollView was positioned correctly.

As you can see, the Save and Cancel buttons are handled on page level and not on tab level.


## How it works
1. The TabBar shows the tabs with the text of the active tab underlined.
2. Pressing another tab call a RelayCommand of the MainViewModel
3. The RelayCommand changes the active tab by setting observable properties
4. The observable properties determine which tab is visible and which underline is shown.


Ed Schimmel
Byte217