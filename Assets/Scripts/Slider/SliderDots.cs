using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VRWidgets;

public class SliderDots : MonoBehaviour {
  public GameObject dot;
  public int numberOfDots = 0;

  private List<GameObject> dots = new List<GameObject>();
  private Slider slider_;

  public void UpdateDots(float position)
  {
    for (int i = 0; i < dots.Count; ++i)
    {
      if (dots[i].transform.localPosition.x < position)
      {
        Renderer[] renderers = dots[i].GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
          renderer.material.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
          renderer.material.SetFloat("_Gain", 3.0f);
        }
      }
      else
      {
        Renderer[] renderers = dots[i].GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
          renderer.material.color = new Color(0.067f, 0.067f, 0.067f, 0.5f);
          renderer.material.SetFloat("_Gain", 1.0f);
        }
      }
    }
  }

	// Use this for initialization
	void Awake() {
    if (numberOfDots < 1)
      return;

    slider_ = transform.parent.GetComponent<Slider>();
    float lowerLimit = slider_.lowerLimit.transform.localPosition.x;
    float upperLimit = slider_.upperLimit.transform.localPosition.x;
    float length = upperLimit - lowerLimit;
    float increments = length / numberOfDots;

    for (float x = lowerLimit + increments / 2.0f; x < upperLimit; x += increments) {
      GameObject new_dot = Instantiate(dot) as GameObject;
      new_dot.transform.parent = transform;
      new_dot.transform.localPosition = new Vector3(x, 1.0f, -0.1f);
      new_dot.transform.localScale = Vector3.one;
      dots.Add(new_dot);
    }
    Destroy(dot);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
