using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class SliderHandle : MonoBehaviour
  {
    public GameObject upperLimit;
    public GameObject lowerLimit;
    private Vector3 constraint_direction_ = Vector3.right; // X-axis
    private Vector3 origin_position_ = Vector3.zero;

    public void SetReferencePosition()
    {
      origin_position_ = transform.position;
    }

    public void UpdatePosition(Vector3 local_position_difference)
    {
      Renderer[] upper_limit_renderers = upperLimit.GetComponentsInChildren<Renderer>();
      foreach (Renderer upper_limit_renderer in upper_limit_renderers)
      {
        upper_limit_renderer.enabled = false;
      }

      transform.position = Vector3.Project(local_position_difference, constraint_direction_) + origin_position_;
      Vector3 sliderHandlePosition = transform.localPosition;
      if (sliderHandlePosition.x < lowerLimit.transform.localPosition.x)
      {
        sliderHandlePosition.x = lowerLimit.transform.localPosition.x;
      }

      if (sliderHandlePosition.x > upperLimit.transform.localPosition.x)
      {
        sliderHandlePosition.x = upperLimit.transform.localPosition.x;
        foreach (Renderer upper_limit_renderer in upper_limit_renderers)
        {
          upper_limit_renderer.enabled = true;
        }
      }

      transform.localPosition = sliderHandlePosition;
    }

    // Use this for initialization
    void Awake()
    {
      origin_position_ = transform.position;
      constraint_direction_ = (upperLimit.transform.position - lowerLimit.transform.position) / 2.0f;
      UpdatePosition(Vector3.zero);
    }
  }
}

