using UnityEngine;
using System.Collections;
using VRWidgets;

public class SliderHandleButton : Button
{
  public HandDetector handDetector;
  public ButtonTopGraphics buttonTopGraphics;
  public ButtonBotGraphics buttonBotGraphics;

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
    buttonTopGraphics.SetBloomGain(3.0f);
    buttonBotGraphics.SetBloomGain(2.0f);
    buttonBotGraphics.SetColor(new Color(0.0f, 1.0f, 1.0f, 1.0f));
    Debug.Log("PRESSED");
  }

  public override void ButtonReleased()
  {
    is_pressed_ = false;
    handDetector.ResetTarget();
    buttonTopGraphics.SetBloomGain(1.5f);
    buttonBotGraphics.SetBloomGain(1.5f);
    buttonBotGraphics.SetColor(new Color(0.0f, 0.1f, 0.1f, 1.0f));
    //buttonBotGraphics.SetColor(new Color(0.067f, 0.067f, 0.067f, 0.5f));
    Debug.Log("RELEASED");
  }

  void Awake()
  {
    slider_handle_ = transform.parent.GetComponent<SliderHandle>();
    ButtonReleased();
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
