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
      constraint_direction_ = (slider_.lowerLimit.transform.position - slider_.upperLimit.transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
      // Constraint the position along the constraint_direction_
    }
  }
}

