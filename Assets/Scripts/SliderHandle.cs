using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class SliderHandle : MonoBehaviour
  {
    private Slider slider_ = null;
    private Vector3 constraint_direction_;

    // Use this for initialization
    void Start()
    {
      if (transform.parent && transform.parent.GetComponent<Slider>())
      {
        slider_ = transform.parent.GetComponent<Slider>();
      }
      else
      {
        Debug.LogWarning("Button Switch configured incorrectedly");
      }
      GetComponent<SpringJoint>().connectedAnchor = transform.position;
      constraint_direction_ = (slider_.lowerLimit.transform.position - slider_.upperLimit.transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
      // Constraint the position along the constraint_direction_
      transform.position = Vector3.Project(transform.position - slider_.transform.position, constraint_direction_) + slider_.transform.position;

      // If the button is going backwards, place it back to original spot
      if (transform.localPosition.x < slider_.upperLimit.transform.localPosition.x && transform.localPosition.x > slider_.lowerLimit.transform.localPosition.x)
      {
        GetComponent<SpringJoint>().spring = 0.0f;
        GetComponent<SpringJoint>().connectedAnchor = transform.position;
      }
      else
      {
        GetComponent<SpringJoint>().spring = 100.0f;
      }
    }
  }
}

