using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ButtonCasing : MonoBehaviour
  {
    private Button button_ = null;
    private Vector3 constraint_direction_;
    private float local_z_constraint_ = 0.0f;

    public void SetSpringAnchor(Vector3 position)
    {
      GetComponent<SpringJoint>().connectedAnchor = position;
      local_z_constraint_ = button_.transform.InverseTransformPoint(position).z;
      Debug.Log(local_z_constraint_);
    }

    void Awake()
    {
      if (transform.parent && transform.parent.GetComponent<Button>())
      {
        button_ = transform.parent.GetComponent<Button>();
      }
      else
      {
        Debug.LogWarning("Button Switch configured incorrectedly");
      }
      constraint_direction_ = (button_.buttonSwitch.transform.position - button_.transform.position).normalized;
      SetSpringAnchor(transform.position);
    }

    // Use this for initialization
    void Start() {
	  }

    void Update()
    {
      // Constraint the position along the constraint_direction_
      transform.position = Vector3.Project(transform.position - button_.transform.position, constraint_direction_) + button_.transform.position;

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
