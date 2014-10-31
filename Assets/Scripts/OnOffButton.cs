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
    buttonTopGraphics.SetBloomGain(3.0f);
    buttonMidGraphics.SetBloomGain(10.0f);
    buttonMidGraphics.SetColor(new Color(0.0f, 0.05f, 0.05f, 1.0f));
    buttonBotGraphics.SetBloomGain(2.5f);
    buttonBotGraphics.SetColor(new Color(0.0f, 1.0f, 1.0f, 1.0f));
  }

  public override void TurnsInactive()
  {
    base.TurnsInactive();
    buttonTopGraphics.SetStatus(false);
    buttonTopGraphics.SetBloomGain(1.0f);
    buttonMidGraphics.SetBloomGain(1.0f);
    buttonMidGraphics.SetColor(new Color(0.067f, 0.067f, 0.067f, 0.25f));
    buttonBotGraphics.SetBloomGain(1.0f);
    buttonBotGraphics.SetColor(new Color(0.0f, 0.1f, 0.1f, 1.0f));
  }

  void Awake()
  {
    buttonMidGraphics.SetColor(new Color(0.067f, 0.067f, 0.067f, 0.25f));
    buttonBotGraphics.SetColor(new Color(0.0f, 0.1f, 0.1f, 1.0f));
  }
}
