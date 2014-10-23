using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public abstract class Button : MonoBehaviour
  {
    public ButtonCasing buttonCasing;
    public ButtonCushion buttonCushion;
    public ButtonSwitch buttonSwitch;

    protected bool button_pressed_ = false;

    public abstract void ButtonAction();

    public virtual void ButtonPressed()
    {
      if (!button_pressed_)
      {
        ButtonAction();
      }
      button_pressed_ = true;
    }

    public virtual void ButtonEntersCushion()
    {
      button_pressed_ = false;
    }
  }
}

