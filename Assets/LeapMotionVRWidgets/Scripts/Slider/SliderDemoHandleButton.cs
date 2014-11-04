using UnityEngine;
using System.Collections;
using VRWidgets;

public class SliderDemoHandleButton : SliderHandleButtonBase 
{
  public SliderDemoGraphics topLayer;
  public SliderDemoGraphics midLayer;
  public SliderDemoGraphics botLayer;

  private void PressedGraphics()
  {
    topLayer.SetBloomGain(5.0f);
    botLayer.SetBloomGain(4.0f);
    botLayer.SetColor(new Color(0.0f, 1.0f, 1.0f, 1.0f));
  }

  private void ReleasedGraphics()
  {
    topLayer.SetBloomGain(2.0f);
    botLayer.SetBloomGain(2.0f);
    botLayer.SetColor(new Color(0.067f, 0.067f, 0.067f, 0.5f));
  }

  public override void ButtonPressed()
  {
    base.ButtonPressed();
    PressedGraphics();
  }

  public override void ButtonReleased()
  {
    base.ButtonReleased();
    ReleasedGraphics();
  }
}
