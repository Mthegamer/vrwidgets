using UnityEngine;
using System.Collections;
using VRWidgets;

[RequireComponent (typeof (BoxCollider))]
public class HandDetector : MonoBehaviour
{
  [HideInInspector]
  public Vector3 pivot = Vector3.zero;
  [HideInInspector]
  public GameObject target = null;

  private bool IsHand(Collider other)
  {
    return other.transform.parent && other.transform.parent.parent && other.transform.parent.parent.GetComponent<HandModel>();
  }

  public void ResetTarget()
  {
    target = null;
  }

  void OnTriggerEnter(Collider other)
  {
    if (target != null)
      return;

    if (IsHand(other))
    {
      target = other.gameObject;
      pivot = other.transform.position;
    }
  }

  void Awake()
  {
    GetComponent<BoxCollider>().isTrigger = true;
  }
}
