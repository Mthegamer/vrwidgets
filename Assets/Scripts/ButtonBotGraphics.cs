using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ButtonBotGraphics : MonoBehaviour
  {
    private Button button_ = null;

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

    void Awake()
    {
      if (transform.parent && transform.parent.GetComponentInChildren<Button>())
      {
        button_ = transform.parent.GetComponentInChildren<Button>();
      }
      else
      {
        Debug.LogWarning("Button Switch configured incorrectedly");
      }
    }

    void LateUpdate()
    {
      if (button_ == null)
        return;

      float active_pos = button_.buttonToggleActive.transform.localPosition.z;
      float casing_pos = button_.buttonCasing.transform.localPosition.z;
      float casing_scale = button_.buttonCasing.transform.localScale.z;
      float switch_pos = button_.buttonSwitch.transform.localPosition.z;
      float switch_scale = button_.buttonSwitch.transform.localScale.z;

      float graphics_position = casing_pos - casing_scale / 2.0f; // The position is relative to the casing
      float graphics_position_upper_limit = switch_pos - switch_scale / 2.0f - casing_scale; // The upper limit is relative to switch
      float graphics_position_lower_limit = active_pos - casing_scale / 2.0f; // The lower limit is relative to active button position

      float position = Mathf.Clamp(graphics_position, graphics_position_lower_limit, graphics_position_upper_limit);
      transform.position = button_.transform.TransformPoint(new Vector3(0.0f, 0.0f, position));
    }
  }
}
