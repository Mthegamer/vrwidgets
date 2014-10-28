using UnityEngine;
using System.Collections;
using VRWidgets;

public class SliderHandleButton : Button
{
  public HandDetector handDetector;

  private bool is_pressed_ = false;
  public override void ButtonPressed()
  {
    is_pressed_ = true;
    Debug.Log("PRESSED");
  }

  public override void ButtonReleased()
  {
    is_pressed_ = false;
    handDetector.ResetTarget();
    Debug.Log("RELEASED");
  }

  public override void Update()
  {
    base.Update();
    if (is_pressed_)
    {
      if (handDetector.target_)
      {
        Vector3 target = new Vector3(handDetector.target_.transform.position.x, transform.parent.position.y, transform.parent.position.z);
        transform.parent.position = Vector3.Lerp(transform.parent.position, target, 0.5f);
        buttonCasing.SetSpringAnchor(transform.parent.position);
      }
    }
  }
}
