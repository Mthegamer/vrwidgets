using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ButtonTopGraphics : MonoBehaviour
  {
    public GameObject onButton = null;
    public GameObject offButton = null;

    private Button button_ = null;

    public void SetStatus(bool status)
    {
      if (status)
      {
        onButton.SetActive(true);
        offButton.SetActive(false);
      }
      else
      {
        onButton.SetActive(false);
        offButton.SetActive(true);
      }
    }

    private bool isCasingPastSwitch()
    {
      float button_casing_pos_z = button_.buttonCasing.transform.localPosition.z;
      float button_casing_scale_z = button_.buttonCasing.transform.localScale.z;
      float button_switch_pos_z = button_.buttonSwitch.transform.localPosition.z;
      float button_switch_scale_z = button_.buttonSwitch.transform.localScale.z;
      return ((button_casing_pos_z + button_casing_scale_z / 2.0f) < (button_switch_pos_z - button_switch_scale_z / 2.0f));
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
    }

    void LateUpdate()
    {
      if (button_ == null)
        return;

      float button_casing_pos_z = button_.buttonCasing.transform.localPosition.z;
      float button_casing_scale_z = button_.buttonCasing.transform.localScale.z;
      float button_switch_pos_z = button_.buttonSwitch.transform.localPosition.z;
      float button_switch_scale_z = button_.buttonSwitch.transform.localScale.z;
      Vector3 transformed_position = Vector3.zero;
      // Check limits of the positions the button is allowed to go to
      if (isCasingPastSwitch())
      {
        transformed_position += new Vector3(0.0f, 0.0f, button_casing_pos_z - button_casing_scale_z / 2.0f);
      }
      else
      {
        transformed_position += new Vector3(0.0f, 0.0f, (button_switch_pos_z - button_switch_scale_z / 2.0f - button_casing_scale_z));
      }
      transform.position = button_.transform.TransformPoint(transformed_position);
    }
  }
}

