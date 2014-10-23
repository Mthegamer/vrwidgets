using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ButtonGraphics : MonoBehaviour
  {
    private Button button = null;

    Vector3 position_start_limit_;
    Vector3 position_end_limit_;

    void Start()
    {
      if (transform.parent && transform.parent.GetComponent<Button>())
      {
        button = transform.parent.GetComponent<Button>();
        position_start_limit_ = transform.localPosition;
        position_end_limit_ = button.buttonSwitch.transform.localPosition - new Vector3(0.0f, 0.0f, (button.buttonSwitch.transform.localScale.z + transform.localScale.z) / 2.0f);
      }
      else
      {
        Debug.LogWarning("Button Switch configured incorrectedly");
      }
    }

    void Update()
    {
      if (button == null)
        return;

      transform.localPosition = button.buttonCasing.transform.localPosition;
      if (transform.localPosition.z > position_end_limit_.z)
      {
        transform.localPosition = position_end_limit_;
      }
      else if (transform.localPosition.z < position_start_limit_.z)
      {
        transform.localPosition = position_start_limit_;
      }
    }
  }
}

