using UnityEngine;
using System.Collections;
using VRWidgets;

public class OnOffButton : Button
{
  public ButtonTopGraphics buttonTopGraphics;

  public override void ButtonAction()
  {
    Debug.Log("PRESSED");
  }

  public override void TurnsActive()
  {
    base.TurnsActive();
    buttonTopGraphics.SetStatus(true);
  }

  public override void TurnsInactive()
  {
    base.TurnsInactive();
    buttonTopGraphics.SetStatus(false);
  }
}
