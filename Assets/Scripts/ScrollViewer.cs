using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ScrollViewer : MonoBehaviour
  {
    public GameObject scrollBoundaries;
    public GameObject scrollWindow;

    // Use this for initialization
    void Start()
    {
      float x_max = float.MinValue;
      float x_min = float.MaxValue;
      float y_max = float.MinValue;
      float y_min = float.MaxValue;

      Vector3[] vertices = new Vector3[0];
      if (scrollBoundaries.GetComponentInChildren<MeshFilter>())
        vertices = scrollBoundaries.GetComponentInChildren<MeshFilter>().mesh.vertices;
      else
        vertices = scrollBoundaries.GetComponent<MeshFilter>().mesh.vertices;

      for (int i = 0; i < vertices.Length; ++i)
      {
        y_max = Mathf.Max(vertices[i].y * scrollBoundaries.transform.localScale.y, y_max);
        y_min = Mathf.Min(vertices[i].y * scrollBoundaries.transform.localScale.y, y_min);
        x_max = Mathf.Max(vertices[i].x * scrollBoundaries.transform.localScale.x, x_max);
        x_min = Mathf.Min(vertices[i].x * scrollBoundaries.transform.localScale.x, x_min);
      }
      
      scrollWindow.transform.localPosition = new Vector3((x_max + x_min) / 2.0f, (y_max + y_min) / 2.0f, 0.0f);
      scrollWindow.transform.localScale = new Vector3((x_max - x_min), (y_max - y_min), 0.0f);
    }
  }
}

