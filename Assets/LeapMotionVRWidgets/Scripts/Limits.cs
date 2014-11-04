using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class Limits
  {
    public float t = float.MinValue;
    public float b = float.MaxValue;
    public float r = float.MinValue;
    public float l = float.MaxValue;

    public Limits()
    {
    }

    public void GetLimits(GameObject target)
    {
      MeshFilter[] mesh_filters = target.GetComponentsInChildren<MeshFilter>();
      foreach (MeshFilter mesh_filter in mesh_filters)
      {
        Vector3[] vertices = mesh_filter.mesh.vertices;
        for (int i = 0; i < vertices.Length; ++i)
        {
          Vector3 verticeTransformed = Vector3.Scale(vertices[i], mesh_filter.transform.localScale);
          t = Mathf.Max(verticeTransformed.y, t);
          b = Mathf.Min(verticeTransformed.y, b);
          r = Mathf.Max(verticeTransformed.x, r);
          l = Mathf.Min(verticeTransformed.x, l);
        }
      }
    }
  }
}

