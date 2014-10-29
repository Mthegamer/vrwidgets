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

    public void SetColor(Color color)
    {
      Renderer[] renderers = GetComponentsInChildren<Renderer>();
      foreach (Renderer renderer in renderers)
      {
        renderer.material.color = color;
      }
    }

    // Update is called once per frame
    void LateUpdate()
    {
      if (buttonTopGraphics == null || buttonBotGraphics == null)
        return;

      transform.localPosition = (buttonTopGraphics.transform.localPosition + buttonBotGraphics.transform.localPosition) / 2.0f;
      float z = Mathf.Abs(buttonTopGraphics.transform.localPosition.z - buttonBotGraphics.transform.localPosition.z) / 4.0f;
      Vector3 local_position = transform.localPosition;
      transform.localPosition = local_position + new Vector3(0.0f, 0.0f, -z);
    }
  }
}