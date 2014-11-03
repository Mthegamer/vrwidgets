using UnityEngine;
using System.Collections;
using VRWidgets;

public class HandDetector : MonoBehaviour
{
  [HideInInspector]
  public GameObject target = null;

  public void ResetTarget()
  {
    target = null;
  }

  void OnTriggerEnter(Collider collider)
  {
    if (target != null)
      return;

    if (collider.transform.parent && collider.transform.parent.parent && collider.transform.parent.parent.GetComponent<HandModel>())
    {
      target = collider.gameObject;
    }
  }
}
