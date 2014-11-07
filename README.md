#VR Widgets
There are 3 widgets in this package you can use:

1. Buttons
2. Sliders
3. Scrollers

### Buttons
Buttons only require a script that inhereits from ButtonBase.
You can see the barebone example on the ButtonDemoBasic prefab.

#### Inspector Values
Values  | Definition
------- | ----------
float string            | Strength of the string
float triggerDistance   | How far does the button need to be pressed to trigger
float cushionThickness  | A cushion used hysteresis. It's positioned right above the trigger. Keep this number low.

float string; 
float triggerDistance;
float cushionThickness;

abstract void ButtonReleased(); // This function is used for 
abstract void ButtonPressed();


### Sliders
### Scrollers