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

    protected bool entered_switch_ = false;
    protected bool entered_cushion_ = false;
    protected bool exited_switch_ = false;
    protected bool exited_cushion_ = false;

    public abstract void ButtonReleased();
    public abstract void ButtonPressed();

    public virtual void ButtonEntersSwitch()
    {
      entered_switch_ = true;
    }

    public virtual void ButtonExitsSwitch()
    {
      exited_switch_ = true;
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
      entered_cushion_ = true;
    }

    public void ButtonExitsCushion()
    {
      exited_cushion_ = true;
    }

    void Start()
    {
      TurnsInactive();
    }

    void Update()
    {
      if (entered_switch_ && entered_cushion_)
      {
        if (isToggleButton)
        {
          ButtonPressed();
          if (isActive)
            TurnsInactive();
          else
            TurnsActive();
          isActive = !isActive;
        }
        entered_switch_ = false;
        entered_cushion_ = false;
      }

      if (exited_switch_ && exited_cushion_)
      {
        ButtonReleased();
        exited_switch_ = false;
        exited_cushion_ = false;
      }
    }
  }
}

