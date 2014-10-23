﻿using UnityEngine;
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
  }
}
