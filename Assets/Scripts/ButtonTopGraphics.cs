using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ButtonTopGraphics : MonoBehaviour
  {
    private Button button_ = null;

    void Start()
    {
      if (transform.parent && transform.parent.GetComponent<Button>())
      {
        button_ = transform.parent.GetComponent<Button>();
      }
      else
      {
        Debug.LogWarning("Button Switch configured incorrectedly");
      }
    }

    void LateUpdate()
    {
      if (button_ == null)
        return;

      // Check limits of the positions the button is allowed to go to
      float buttonCasingPosZ = button_.buttonCasing.transform.localPosition.z;
      float buttonCasingScaleZ = button_.buttonCasing.transform.localScale.z;
      float buttonSwitchPosZ = button_.buttonSwitch.transform.localPosition.z;
      float buttonSwitchScaleZ = button_.buttonSwitch.transform.localScale.z;
      if ((buttonCasingPosZ + buttonCasingScaleZ / 2.0f) < (buttonSwitchPosZ - buttonSwitchScaleZ / 2.0f))
      {
        transform.localPosition = new Vector3(0.0f, 0.0f, buttonCasingPosZ);
      }
      else
      {
        transform.localPosition = new Vector3(0.0f, 0.0f, (buttonSwitchPosZ - buttonSwitchScaleZ / 2.0f - buttonCasingScaleZ / 2.0f));
      }
      transform.localPosition -= new Vector3(0.0f, 0.0f, buttonCasingScaleZ / 2.0f);
    }
  }
}

