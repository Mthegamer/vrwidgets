using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ScrollCursor : MonoBehaviour
  {
    public GameObject cursor = null;
    public GameObject incIndicator = null;
    public GameObject decIndicator = null;

    private float upper_limit_ = 0.0f;
    private float lower_limit_ = 0.0f;

    private float previous_percent_ = -1.0f;

    private void SetRenderers(GameObject game_object, bool enabled)
    {
      Renderer[] renderers = game_object.GetComponentsInChildren<Renderer>();
      foreach (Renderer renderer in renderers)
      {
        renderer.enabled = enabled;
      }
    }

    public void SetBloomGain(float gain)
    {
      Renderer[] renderers = GetComponentsInChildren<Renderer>();
      foreach (Renderer renderer in renderers)
      {
        renderer.material.SetFloat("_Gain", gain);
      }
    }

    public void SetLimits(float upper_limit, float lower_limit) 
    {
      upper_limit_ = upper_limit;
      lower_limit_ = lower_limit;
    }

    public void UpdatePercent(float percent)
    {
      if (previous_percent_ < 0.0f)
        previous_percent_ = percent;

      if (cursor != null)
      {
        Vector3 local_position = cursor.transform.localPosition;
        local_position.y = (upper_limit_ - lower_limit_) * percent + lower_limit_;
        cursor.transform.localPosition = local_position; 
      }

      SetRenderers(incIndicator, false);
      SetRenderers(decIndicator, false);
      if (percent > previous_percent_ && incIndicator != null)
      {
        SetRenderers(incIndicator, true);
      } 
      else if (percent < previous_percent_ && decIndicator != null)
      {
        SetRenderers(decIndicator, true);
      }

      previous_percent_ = percent;
    }
  }
}

