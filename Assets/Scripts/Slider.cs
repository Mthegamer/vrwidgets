using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class Slider : MonoBehaviour
  {
    public SliderLimit lowerLimit;
    public SliderLimit upperLimit;
    public SliderHandle sliderHandle;
    public GameObject sliderSection;

    public float length = 0;
    public int sections = 0;

    void Awake()
    {
      lowerLimit.transform.localPosition -= new Vector3(length / 2.0f, 0.0f, 0.0f);
      upperLimit.transform.localPosition += new Vector3(length / 2.0f, 0.0f, 0.0f);
      float section_size = length / sections;
      for (float x = lowerLimit.transform.localPosition.x + section_size / 2.0f; x < upperLimit.transform.localPosition.x; x += section_size)
      {
        Vector3 position = new Vector3(x, 0.0f, 0.0f);
        GameObject section = Instantiate(sliderSection, Vector3.zero, Quaternion.identity) as GameObject;
        section.transform.parent = transform;
        section.transform.localPosition = position;
        section.transform.localRotation = Quaternion.identity;
        section.transform.localScale = Vector3.one * section_size;
      }
      sliderSection.SetActive(false);
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

