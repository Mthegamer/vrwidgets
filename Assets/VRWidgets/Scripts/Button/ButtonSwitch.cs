using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ButtonSwitch : MonoBehaviour
  {
    private Button button_ = null;

    void OnTriggerEnter(Collider collider)
    {
      if (button_ == null)
        return;

      if (collider.gameObject == button_.buttonCasing.gameObject)
      {
        button_.ButtonEntersSwitch();
      }
    }

    void OnTriggerExit(Collider collider)
    {
      if (button_ == null)
        return;

      if (collider.gameObject == button_.buttonCasing.gameObject)
      {
        button_.ButtonExitsSwitch();
      }
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

    void Start()
    {
    }
  }
}
