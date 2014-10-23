using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class SliderHandleGraphics : MonoBehaviour
  {
    private Slider slider_ = null;

    private Vector3 lower_limit_;
    private Vector3 upper_limit_;

    // Use this for initialization
    void Start()
    {
      if (transform.parent && transform.parent.GetComponent<Slider>())
      {
        slider_ = transform.parent.GetComponent<Slider>();
        lower_limit_ = slider_.lowerLimit.transform.localPosition;
        upper_limit_ = slider_.upperLimit.transform.localPosition;
      }
      else
      {
        Debug.LogWarning("Slider Handle Graphics configured incorrectedly");
      }
    }

    // Update is called once per frame
    void LateUpdate()
    {
      if (slider_ == null)
        return;

      // Check limits of the positions the button is allowed to go to
      transform.localPosition = slider_.sliderHandle.transform.localPosition;
      if (transform.localPosition.x > upper_limit_.x)
      {
        transform.localPosition = upper_limit_;
      }
      else if (transform.localPosition.x < lower_limit_.x)
      {
        transform.localPosition = lower_limit_;
      }
    }
  }
}

