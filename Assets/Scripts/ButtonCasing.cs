using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ButtonCasing : MonoBehaviour
  {
    private Button button_ = null;
    private Vector3 constraint_direction_;

    // Use this for initialization
    void Start() {     
      if (transform.parent && transform.parent.GetComponent<Button>())
        {
          button_ = transform.parent.GetComponent<Button>();
        }
        else
        {
          Debug.LogWarning("Button Switch configured incorrectedly");
        }
      GetComponent<SpringJoint>().connectedAnchor = button_.transform.position;
      constraint_direction_ = (button_.buttonSwitch.transform.position - button_.transform.position).normalized;
	  }

    void Update()
    {
      transform.position = Vector3.Project(transform.position - button_.transform.position, constraint_direction_) + button_.transform.position;
      if (transform.localPosition.z < 0.0f)
      {
        Vector3 local_position = transform.localPosition;
        local_position.z = 0.0f;
        transform.localPosition = local_position;
      }
        
    }
  }
}
