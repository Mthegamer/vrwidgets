using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class Slider : MonoBehaviour
  {
    public GameObject sliderHandle = null;
    public GameObject lowerLimit = null;
    public GameObject upperLimit = null;
    public GameObject inactiveBar = null;
    public GameObject activeBar = null;

    void Awake()
    {
      if (sliderHandle == null || lowerLimit == null || upperLimit == null || inactiveBar == null || activeBar == null)
      {
        Debug.LogWarning("Slider is not initialized properly");
        return;
      }
    }

    void LateUpdate()
    {
      activeBar.transform.localPosition = (sliderHandle.transform.localPosition + lowerLimit.transform.localPosition) / 2.0f;
      Vector3 activeBarScale = activeBar.transform.localScale;
      activeBarScale.x = Mathf.Abs(sliderHandle.transform.localPosition.x - lowerLimit.transform.localPosition.x);
      activeBar.transform.localScale = activeBarScale;
      Renderer[] renderers = activeBar.GetComponentsInChildren<Renderer>();
      foreach (Renderer renderer in renderers)
      {
        renderer.material.SetFloat("_Gain", 3.0f);
      }
    }
  }
}

