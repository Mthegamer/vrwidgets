using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ButtonCushion : MonoBehaviour
  {
    private Button button_ = null;

    void OnTriggerEnter(Collider collider)
    {
      if (button_ == null)
        return;

      if (collider.gameObject == button_.buttonCasing.gameObject)
      {
        button_.ButtonEntersCushion();
      }
    }

    void OnTriggerExit(Collider collider)
    {
      if (button_ == null)
        return;

      if (collider.gameObject == button_.buttonCasing.gameObject)
      {
        button_.ButtonExitsCushion();
      }
    }

    void Awake()
    {
      if (transform.parent && transform.parent && transform.parent.parent.GetComponent<Button>())
      {
        button_ = transform.parent.parent.GetComponent<Button>();
      }
      else
      {
        Debug.LogWarning("Button Switch configured incorrectedly");
      }
    }
  }
}

