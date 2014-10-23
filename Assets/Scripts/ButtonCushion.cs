using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ButtonCushion : MonoBehaviour
  {
    private Button button = null;

    void OnTriggerEnter(Collider collider)
    {
      if (button == null)
        return;

      if (collider.gameObject == button.buttonCasing.gameObject)
      {
        button.ButtonEntersCushion(); 
      }
    }

    void Start()
    {
      if (transform.parent && transform.parent.GetComponent<Button>())
      {
        button = transform.parent.GetComponent<Button>();
      }
      else
      {
        Debug.LogWarning("Button Switch configured incorrectedly");
      }
    }
  }
}

