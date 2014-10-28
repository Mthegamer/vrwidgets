using UnityEngine;
using System.Collections;
using VRWidgets;

public class HandDetector : MonoBehaviour
{
  [HideInInspector]
  public GameObject target_ = null;

  public void ResetTarget()
  {
    target_ = null;
  }

  void OnTriggerEnter(Collider collider)
  {
    if (target_ != null)
      return;

    if (collider.transform.parent && collider.transform.parent.parent && collider.transform.parent.parent.GetComponent<HandModel>())
    {
      target_ = collider.gameObject;
    }
  }
}
