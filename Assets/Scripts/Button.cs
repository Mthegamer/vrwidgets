using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public abstract class Button : MonoBehaviour
  {
    public ButtonCasing buttonCasing;
    public ButtonCushion buttonCushion;
    public ButtonSwitch buttonSwitch;

    public GameObject buttonToggleActive;
    public GameObject buttonToggleInactive;

    public bool isToggleButton = false;

    protected bool isActive = false;
    protected bool button_pressed_ = false;

    public abstract void ButtonAction();

    public virtual void ButtonPressed()
    {
      if (!button_pressed_)
      {
        ButtonAction();
        if (isToggleButton)
        {
          if (isActive)
            TurnsInactive();
          else
            TurnsActive();
          isActive = !isActive;
        }
      }
      button_pressed_ = true;
    }

    public virtual void TurnsActive()
    {
      buttonCasing.SetSpringAnchor(buttonToggleActive.transform.position);
    }

    public virtual void TurnsInactive()
    {
      buttonCasing.SetSpringAnchor(buttonToggleInactive.transform.position);
    }

    public void ButtonEntersCushion()
    {
      button_pressed_ = false;
    }

    void Start()
    {
      TurnsInactive();
    }
  }
}

