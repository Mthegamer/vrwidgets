#VR Widgets
There are 3 widgets in this package you can use:

1. Buttons
2. Sliders
3. Scrollers

## Buttons
Buttons only require a script that inhereits from ButtonBase.
Take a look at the ButtonDemoBasic example on how to inhereit ButtonBase.

#### ButtonBase
Inspector Values  | Definition
------- | ----------
float string            | Strength of the string (Recommend: 100)
float triggerDistance   | How far does the button need to be pressed to trigger (Recommend: 0.025)
float cushionThickness  | A cushion used hysteresis. It's positioned right above the trigger. Keep this number low (Recommend: 0.05)

Functions | Definition
--------- | ---------
abstract void ButtonReleased()  | Called when button is released
abstract void ButtonPressed()   | Called when button is pressed
float GetPercent()              | Percent between resting and pressed position
Vector3 GetPosition()           | Position of the button in local space
virtual void ApplyConstraints() | Constrains the movement of the button. Can be overriden by your implementation

## Sliders
Sliders are more complex to integrate than buttons.
Please follow the SliderDemoBasic prefab to follow how to integrate the sliders

Sliders require two scripts:
1. SliderHandle - Responsible for moving the handle, and updating the graphics with the slider bar
2. SliderHandleButton - Responsible for activating the handle, and updating the graphics for handle

Sliders also require two additional game objects:
1. SliderUpperLimit
2. SliderLowerLimit
These limits determine how far can the slider move to.

#### SliderHandleButtonBase - Inherits from ButtonBase
Inspector Values | Definition
---------------- | ----------
HandDetector handDetector     | HandDetector is used to determine which part of the hand should the slider follow
SliderHandleBase sliderHandle | Attach the sliderHandle so it knows who to signal them to start moving

Functions | Definition
--------- | ----------
abstract void SlidePressed()  | Called when handle is pressed
abstract void SliderReleased()   | Called when handle is released

#### SliderHandleBase
Inspector Values | Definition
---------------- | ----------
GameObject upperLimit | The position for the upperLimit of the slider. Only localPosition.x will be used
GameObject lowerLimit | The position for the lowerLimit of the slider. Only localPosition.x will be used

Functions | Definition
--------- | ----------
float GetPercent()            | Percent for the slider position betweem lower and upper limit
virtual void UpdatePosition() | 

## Scrollers