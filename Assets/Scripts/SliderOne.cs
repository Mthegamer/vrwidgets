using UnityEngine;
using System.Collections;
using VRWidgets;

public class SliderOne : Slider 
{
  public SliderDots sliderDots = null;
	
	// Update is called once per frame
	void Update () {
    sliderDots.UpdateDots(sliderHandle.transform.localPosition.x);
	}
}
