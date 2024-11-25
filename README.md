# Calculator App


## Project Overview
This Unity project implements a simple calculator application. The project includes several scripts that manage various functionalities such as button size modification, orientation management, audio playback, and the calculator logic itself.

## Table of Contents
- [Firebase Deployment](#firebase-deployment)
- [Unity and Project Installation](#unity-and-project-installation)
- [Implementation Details](#implementation-details)
- [Usage](#usage)

## Firebase Deployment
This project is deployed on Firebase for easy access. You can visit the live demo by going to:
https://calculator-unityapp.web.app

## Unity and Project Installation
1. Clone the repository:
https://github.com/Gaurav0818/Calculator.git
2. Open the unity hub.
3. Install the unity version: 6000.0.16f1
4. Open the project in Unity.
5. Run the project in the Unity Editor or build it for your desired platform.

## Implementation Details
1. ButtonSizeModifier.cs
   This script adjusts the size of UI buttons based on the screen dimensions. It listens for orientation changes and updates the button sizes accordingly.
2. AudioManager.cs
   This script manages screen orientation changes. It raises an event when the screen dimensions change, allowing other scripts to respond to these changes.
3. Calculator.cs
   This script handles audio playback. It allows playing audio clips by name and manages a list of audio clips.
4. OrientationManager.cs
   This script manages screen orientation changes. It raises an event when the screen dimensions change, allowing other scripts to respond to these changes.
5. AudioManager.cs
   This script handles audio playback. It allows playing audio clips by name and manages a list of audio clips.
6. CalculatorKey.cs
   This script represents a key on the calculator. When a key is pressed, it sends the corresponding value to the Calculator script.
7. SortBasedOnPreferredRatio.cs
   This script sorts UI elements based on their preferred ratio. It adjusts the height of child elements proportionally based on their specified ratios.
8. SetPreferredRatio.cs
   This script stores the preferred ratio for a UI element. It is used by the SortBasedOnPreferredRatio script to determine the size of each element.
9. Singleton.cs
   This script provides a generic singleton pattern for other scripts to inherit from, ensuring that only one instance of a class exists.
## Usage
1. Button Size Modification: Attach the ButtonSizeModifier script to UI buttons to automatically adjust their size based on screen dimensions.
2. Orientation Management: Use the OrientationManager script to detect and respond to screen orientation changes.
3. Audio Playback: Use the AudioManager script to play audio clips by name.
4. Calculator: Use the Calculator and CalculatorKey scripts to implement a functional calculator UI.
5. UI Sorting: Use the SortBasedOnPreferredRatio and SetPreferredRatio scripts to sort and size UI elements based on their preferred ratios.

