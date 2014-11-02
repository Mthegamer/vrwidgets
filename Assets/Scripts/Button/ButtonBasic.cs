using UnityEngine;
using System.Collections;
using VRWidgets;

public class ButtonBasic : Button 
{
  public override void ButtonPressed()
  {
    Debug.Log("PRESSED");
  }

  public override void ButtonReleased()
  {
    Debug.Log("RELEASED");
  }
}
