using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class SliderHandleButtonGraphics : MonoBehaviour
  {
    private Button button_ = null;

    void Awake()
    {
      if (transform.parent && transform.parent.GetComponentInChildren<Button>())
      {
        button_ = transform.parent.GetComponentInChildren<Button>();
      }
      else
      {
        Debug.LogWarning("Slider Handle Button Graphics configured incorrectedly");
      }
    }

    void LateUpdate()
    {
      if (button_ == null)
        return;

      float casing_pos = button_.buttonCasing.transform.localPosition.z;
      float casing_scale = button_.buttonCasing.transform.localScale.z;
      float switch_pos = button_.buttonSwitch.transform.localPosition.z;
      float switch_scale = button_.buttonSwitch.transform.localScale.z;

      float graphics_position = casing_pos; // The position is relative to the casing
      float graphics_position_limit = switch_pos - switch_scale / 2.0f - casing_scale / 2.0f; // The limit is relative to the switch

      float position = Mathf.Min(graphics_position, graphics_position_limit);
      transform.position = button_.transform.TransformPoint(new Vector3(0.0f, 0.0f, position));
    }
  }
}

