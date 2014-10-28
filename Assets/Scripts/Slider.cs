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

      inactiveBar.transform.localPosition = (upperLimit.transform.localPosition + lowerLimit.transform.localPosition) / 2.0f;
      Vector3 inactiveBarScale = inactiveBar.transform.localScale;
      inactiveBarScale.x = Mathf.Abs(upperLimit.transform.localPosition.x - lowerLimit.transform.localPosition.x);
      inactiveBar.transform.localScale = inactiveBarScale;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void LateUpdate()
    {
      activeBar.transform.localPosition = (sliderHandle.transform.localPosition + lowerLimit.transform.localPosition) / 2.0f;
      Vector3 activeBarScale = activeBar.transform.localScale;
      activeBarScale.x = Mathf.Abs(sliderHandle.transform.localPosition.x - lowerLimit.transform.localPosition.x);
      activeBar.transform.localScale = activeBarScale;
    }
  }
}

