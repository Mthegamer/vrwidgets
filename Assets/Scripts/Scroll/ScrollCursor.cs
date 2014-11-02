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

      incIndicator.SetActive(false);
      decIndicator.SetActive(false);
      if (percent > previous_percent_ && incIndicator != null)
      {
        incIndicator.SetActive(true);
      } 
      else if (percent < previous_percent_ && decIndicator != null)
      {
        decIndicator.SetActive(true);
      }

      previous_percent_ = percent;
    }
  }
}

