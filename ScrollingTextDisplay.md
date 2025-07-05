## Introduction
This solution shows how to: 
1. make a readonly, disabled Entry that scrolls horizontally without scrollbars. This is the Compact Mode
2. add scrollbars to a readonly, disabled Editor. This is the Full Mode


## Problem
Smart Letter Board is an application that makes it possible to use the phone to enter text without using the standard keyboard functionality. The keyboard had to be as big as possible and the entered text had to be visible for user and participant. As the display has a limited size, I decided to make the text display horizontally scrollable, but without scrollbars. The Entry itself had to be readonly and disabled, because I only wanted it to be filled by the key presses of my own keyboard on the display. However, disabled, readonly entry doesn't scroll when its text doesn't fit.

This is a very specific use case, but it might be helpful for someone who faces the same challenge.


## Solution
Four parts in the code are important:

File: Byte217.MAUI.Application.Maui/Controls/TextDisplay.cs
BindableProperty KeyProcessor.Text
The text is processed by the KeyProcessor when one of the keys on the keyboard is pressed. I have removed some of the more advanced processing, to keep the example simple and focus on the scrolling part.

File: Byte217.MAUI.Application.Maui/ViewModels/Processors/KeyProcessor.cs
This class processes the key presses and shows the text in the TextDisplay.

File: Byte217.MAUI.Application.Maui/Pages/MainPage.xaml 
This shows the TextDisplay in its Compact Mode, an Entry without scrollbar that scrolls horizontally when the text doesn't fit.

File: Byte217.MAUI.Application.Maui/Pages/TextPage.xaml 
This shows the TextDisplay in Full Mode, a multiline Editor with a vertical scrollbar when the text doesn't fit.

## How it works
An enabled Entry gives the user the ability to scroll through the text by placing the cursor within the text and move it. This is not possible with readonly, disabled Entry. It only shows the text that fits within its dimensions.

An enabled Editor allows the user to scroll through the text by placing the cursor within the text and move it. This is not possible with a readonly disabled Editor. However it can resize when AutoSize is enabled. It only shows the text that fits within its dimensions.

The problem to solve is:
1. To make a readonly, disabled Entry scroll without adding scrollbars when the text doesn't fit anymore
2. To add scrollbars to a readonly, disabled Editor when the text doesn't fit anymore


In Compact Mode, using an Entry:
1. I placed the Entry in a ScrollView without scrollbars. When the Entry becomes wider than the ScrollView, I scroll the Entry to the end. This will show the last characters entered.
2. However, this method has a side effect. As long as the text fits within the Entry, its border is visible on all sides. When the text doesn't fit anymore, the Entry grows bigger than its surrounding ScrollView and the border on the right side disappears. To make up for this, I placed a Border component around the ScrollView

In Full Mode, using an Editor:
1. I placed the Editor in a ScrollView with a vertical scrollbar. The Editor resizes when the text doesn't fit anymore. This will cause the vertical scrollbar on the ScrollView to appear. For consistency, I have added a similar Border around this ScrollView.

In my case, only the Entry is shown together with the keys on the Keyboard. The Editor is more for display purposes only. In the Entry_TextChanged event handler, I had to add a call to InvalidateMeasure() and an await Task.Delay(50) to make this work on all platforms. As long as text is entered the Editor is scrolled to its initial position, which shows the text from the beginning. This ensures that switching modes always shows the text from the beginning in Full Mode. Once in Full Mode, the scrollbar can be used to scroll to text closer to the end.


Ed Schimmel
Byte217
