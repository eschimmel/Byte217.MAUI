## Introduction
This solution shows how to manage the screen size without having to take into account the sizes of all the different bars available on the different platforms.

I have included a part of the source code that I used for my mobile application Smart Letter Board, which can be found at
https://smartletterboard.com


## Problem
An important requirement for Smart Letter Board was the display of the keys as big as possible, both for phones and tablets. I also wanted to give the user the possibility to select from different page layouts to make the keys fit better: one with the numbers on top, one with a numeric pad on the right, and one with numbers on a separate page
On the desktop, the screen elements should resize when the application is being resized.


## Solution
Four parts in the code are important:

File: Byte217.MAUI.Application.Maui/MainPage.cs 
Function: SizeAllocated
This function is called when the page is created and when it is resized. Most importantly, the width and height are the dimensions of the drawable area, without bars. Unfortunately, IOS has a small peculiarity that must be taken into account.

File: Byte217.MAUI.Application.Maui/Controls/Button.cs
BindableProperty PageLayout
This bindable property is called when the source is changed. When it is called it calculates a new width and height for this button.

File: Byte217.MAUI.Models/Factories/PageLayoutFactory.cs
Function: CreatePageLayouts
This function calculates the multiplier needed to resize the UI elements to their correct size.

File: Byte217.MAUI.ObservableModels/ObservablePageLayout.cs
Class: ObservablePageLayout
This class uses the PageLayout multiplier to convert the original dimension of the UI elements to their new dimensions. Setting the ObservablePageLayout to a new value triggers a screen refresh.

## How it works
1. When the MainPage is created, OnSizeAllocated is called
2. OnSizeAllocated calls MainViewModel.CreatePageLayouts()
3. CreatePageLayout() calculates the Multiplier and sets the ObservablePageLayout in the MainViewModel
4. The properties of the ObservablePageLayout are multiplied with the Multiplier and therefore show the UI element in its desired size.
5. In case the screen can be resized, OnSizeAllocated() gets called and the Multiplier is recalculated.

In 'Smart Letter Board' the user has the possibility to select another Page layout, with its own calculated Multiplier. Selecting another Page layout also triggers a refresh of the UI elements it is bound to.


Ed Schimmel
Byte217