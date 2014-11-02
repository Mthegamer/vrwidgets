using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ButtonTopGraphics : MonoBehaviour
  {
    public GameObject onButton = null;
    public GameObject offButton = null;

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

    public void SetStatus(bool status)
    {
      if (status)
      {
        onButton.SetActive(true);
        offButton.SetActive(false);
      }
      else
      {
        onButton.SetActive(false);
        offButton.SetActive(true);
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
      SetStatus(false);
    }

    void LateUpdate()
    {
      if (button_ == null)
        return;

      float casing_pos = button_.buttonCasing.transform.localPosition.z;
      float casing_scale = button_.buttonCasing.transform.localScale.z;
      float switch_pos = button_.buttonSwitch.transform.localPosition.z;
      float switch_scale = button_.buttonSwitch.transform.localScale.z;

      float graphics_position = casing_pos - casing_scale / 2.0f; // The position is relative to the casing
      float graphics_position_limit = switch_pos - switch_scale / 2.0f - casing_scale; // The limit is relative to the switch

      float position = Mathf.Min(graphics_position, graphics_position_limit);
      transform.position = button_.transform.TransformPoint(new Vector3(0.0f, 0.0f, position));
    }
  }
}

