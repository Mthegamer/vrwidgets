using UnityEngine;
using System.Collections;
using VRWidgets;

public class ButtonDemo1 : ButtonBase 
{
  public override void ButtonReleased()
  {
    Debug.Log("Released");
  }

  public override void ButtonPressed()
  {
    Debug.Log("Pressed");
  }
}
