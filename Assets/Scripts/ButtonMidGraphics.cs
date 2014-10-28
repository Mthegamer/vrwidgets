using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ButtonMidGraphics : MonoBehaviour
  {
    public ButtonTopGraphics buttonTopGraphics;
    public ButtonBotGraphics buttonBotGraphics;

    public void SetBloomGain(float gain)
    {
      Renderer[] renderers = GetComponentsInChildren<Renderer>();
      foreach (Renderer renderer in renderers)
      {
        renderer.material.SetFloat("_Gain", gain);
      }
    }

    // Update is called once per frame
    void LateUpdate()
    {
      if (buttonTopGraphics == null || buttonBotGraphics == null)
        return;

      transform.localPosition = (buttonTopGraphics.transform.localPosition + buttonBotGraphics.transform.localPosition) / 2.0f;
    }
  }
}