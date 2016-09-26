# KeyboardSimulator
A small program that simulates input from your keyboard. Simply enter the input you wish to simulate and the hotkey with which you want to trigger it. Beside that there are a few options for timing, linebreaks and looping input.

## Features
 - Any text input that you'd want to simulate
 - Single- or looping execution
 - Custom delay between loops
 - Custom delay between individual characters
 - Customizable hotkey for activating simulation
 - Simulation of enter key
 
## Setup
If you're just interested in the program you can simply grab `KeyboardSimulator.exe` from the root directory.
Do note that you'll need the .NET Framework for this to work.

If you want to look at the main source code, you can find it in `KeyboardSimulator/Form1.cs` and if you want to run the entire project or fiddle around with it you'll need the entire repository. Enjoy!

## Usage
Enter the text you want to simulate in the Output text box.  
Click the Record Hotkey button to select the hotkey you want to user as a trigger.  
Check the Repeat checkbox if you want the program to keep looping until you press the hotkey again.  
Enter a delay between each loop.  
Click the start button so the program start to listen to the hotkey you specified.  
Now as soon as you press the hotkey the specified output will be simulated as if you entered it yourself.

Screenshot of the programs interface:  
![Program interface](http://i.imgur.com/rfZYitf.png)