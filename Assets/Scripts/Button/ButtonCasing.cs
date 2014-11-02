using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ButtonCasing : MonoBehaviour
  {
    public Button button = null;
    private Vector3 constraint_direction_;
    private float local_z_constraint_ = 0.0f;

    public void SetSpringAnchor(Vector3 position)
    {
      GetComponent<SpringJoint>().connectedAnchor = position;
      local_z_constraint_ = button.transform.InverseTransformPoint(position).z;
    }

    void Awake()
    {
      constraint_direction_ = (button.buttonSwitch.transform.position - button.transform.position).normalized;
      SetSpringAnchor(transform.position);
    }

    void Update()
    {
      // Constraint the position along the constraint_direction_
      transform.position = Vector3.Project(transform.position - button.transform.position, constraint_direction_) + button.transform.position;

      // If the button is going backwards, place it back to original spot
      if (transform.localPosition.z < local_z_constraint_)
      {
        Vector3 local_position = transform.localPosition;
        local_position.z = local_z_constraint_;
        transform.localPosition = local_position;
      }
    }
  }
}
