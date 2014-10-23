using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ButtonCasing : MonoBehaviour
  {
    private Button button = null;

    // Use this for initialization
    void Start() {     
      if (transform.parent && transform.parent.GetComponent<Button>())
        {
          button = transform.parent.GetComponent<Button>();
        }
        else
        {
          Debug.LogWarning("Button Switch configured incorrectedly");
        }
      GetComponent<SpringJoint>().connectedAnchor = button.transform.position;
	  }
  }
}
