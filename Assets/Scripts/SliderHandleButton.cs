using UnityEngine;
using System.Collections;
using VRWidgets;

public class SliderHandleButton : Button
{
  public HandDetector handDetector;

  private SliderHandle slider_handle_ = null;
  private bool is_pressed_ = false;
  private Vector3 target_origin_position_ = Vector3.zero;

  public override void ButtonPressed()
  {
    is_pressed_ = true;
    if (handDetector.target)
    {
      target_origin_position_ = handDetector.target.transform.position;
      slider_handle_.SetReferencePosition();
    }
    Debug.Log("PRESSED");
  }

  public override void ButtonReleased()
  {
    is_pressed_ = false;
    handDetector.ResetTarget();
    Debug.Log("RELEASED");
  }

  void Awake()
  {
    slider_handle_ = transform.parent.GetComponent<SliderHandle>();
  }

  public override void Update()
  {
    base.Update();
    if (is_pressed_)
    {
      if (handDetector.target)
      {
        slider_handle_.UpdatePosition(handDetector.target.transform.position - target_origin_position_);
        buttonCasing.SetSpringAnchor(slider_handle_.transform.position);
      }
    }
  }
}
