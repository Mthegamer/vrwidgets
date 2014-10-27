using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ButtonMidGraphics : MonoBehaviour
  {
    public ButtonTopGraphics buttonTopGraphics;
    public ButtonBotGraphics buttonBotGraphics;

    // Update is called once per frame
    void LateUpdate()
    {
      if (buttonTopGraphics == null || buttonBotGraphics == null)
        return;

      transform.localPosition = (buttonTopGraphics.transform.localPosition + buttonBotGraphics.transform.localPosition) / 2.0f;
    }
  }
}