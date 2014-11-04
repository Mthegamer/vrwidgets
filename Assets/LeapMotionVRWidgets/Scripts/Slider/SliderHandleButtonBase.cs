using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public abstract class SliderHandleButtonBase : ButtonBase
  {
    public HandDetector handDetector;

    private SliderHandleBase slider_handle_ = null;

    public override void ButtonPressed()
    {
      slider_handle_.ResetPivot();
    }

    public override void ButtonReleased()
    {
      handDetector.ResetTarget();
    }

    public override void Awake()
    {
      base.Awake();
      slider_handle_ = transform.parent.GetComponent<SliderHandleBase>();      
    }

    // Update is called once per frame
    public override void Update()
    {
      base.Update();
      if (is_pressed_)
      {
        if (handDetector.target)
        {
          slider_handle_.UpdatePosition(handDetector.target.transform.position - handDetector.pivot);
        }
      }
    }
  }
}

