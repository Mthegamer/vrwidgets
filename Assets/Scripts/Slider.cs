using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class Slider : MonoBehaviour
  {
    public SliderLimit lowerLimit;
    public SliderLimit upperLimit;
    public GameObject sliderSection;

    public float length = 0;
    public int sections = 0;

    void Awake()
    {
      lowerLimit.transform.localPosition -= new Vector3(length / 2.0f, 0.0f, 0.0f);
      upperLimit.transform.localPosition += new Vector3(length / 2.0f, 0.0f, 0.0f);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
  }
}

