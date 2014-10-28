using UnityEngine;
using System.Collections;
using VRWidgets;

public class OnOffButton : Button
{
  public ButtonTopGraphics buttonTopGraphics;
  public ButtonBotGraphics buttonBotGraphics;
  public ButtonMidGraphics buttonMidGraphics;

  public override void ButtonPressed()
  {
    Debug.Log("PRESSED");
  }

  public override void ButtonReleased()
  {
    Debug.Log("RELEASED");
  }

  public override void TurnsActive()
  {
    base.TurnsActive();
    buttonTopGraphics.SetStatus(true);
    buttonTopGraphics.SetBloomGain(1.5f);
    buttonMidGraphics.SetBloomGain(10.0f);
    buttonBotGraphics.SetBloomGain(2.0f);
  }

  public override void TurnsInactive()
  {
    base.TurnsInactive();
    buttonTopGraphics.SetStatus(false);
    buttonTopGraphics.SetBloomGain(1.0f);
    buttonMidGraphics.SetBloomGain(1.0f);
    buttonBotGraphics.SetBloomGain(1.0f);
  }
}
