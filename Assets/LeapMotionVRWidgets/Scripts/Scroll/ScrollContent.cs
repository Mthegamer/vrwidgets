using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ScrollContent : MonoBehaviour
  {
    public ScrollViewer scrollViewer;

    [HideInInspector]
    public float content_percentage = 0.0f;

    private float upper_limit_ = float.MinValue;
    private float lower_limit_ = float.MaxValue;

    void Awake()
    {
      Limits content_limits = new Limits();
      content_limits.GetLimitsToLocal(gameObject, gameObject);
      Limits viewer_limits = new Limits();
      viewer_limits.GetLimitsToLocal(scrollViewer.scrollBoundaries, gameObject);

      float viewer_height = viewer_limits.t - viewer_limits.b;

      if (content_limits.t - content_limits.b > viewer_height)
      {
        float y_offset = (content_limits.t + content_limits.b) / 2.0f - transform.localPosition.y;
        upper_limit_ = y_offset + content_limits.t - viewer_height / 2.0f;
        lower_limit_ = y_offset + content_limits.b + viewer_height / 2.0f;
      }
      else
      {
        upper_limit_ = 0.0f;
        lower_limit_ = 0.0f;
      }
    }

    // Update is called once per frame
    void LateUpdate()
    {
      Vector3 local_position = transform.localPosition;
      local_position.x = 0.0f;
      local_position.y = (local_position.y > upper_limit_) ? upper_limit_ : local_position.y;
      local_position.y = (local_position.y < lower_limit_) ? lower_limit_ : local_position.y;
      local_position.z = 0.0f;
      transform.localPosition = local_position;
      content_percentage = (upper_limit_ != lower_limit_) ? (local_position.y - lower_limit_) / (upper_limit_ - lower_limit_) : 0.0f;
    }
  }
}

