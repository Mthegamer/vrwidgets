using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace VRWidgets
{
  struct Limits
  {
    public float t;
    public float b;
    public float r;
    public float l;

    public Limits(float top, float bottom, float right, float left)
    {
      t = top;
      b = bottom;
      r = right;
      l = left;
    }
  }

  public class ScrollHandle : Button
  {
    public HandDetector handDetector;
    public GameObject scrollBoundaries;
    public GameObject scrollContent;

    private Vector3 this_pivot_ = Vector3.zero;
    private Vector3 target_pivot_ = Vector3.zero;

    private Limits scroll_viewer_limits_;
    private Limits scroll_content_limits_;

    private bool is_pressed_ = false;

    public void UpdatePosition(Vector3 position_difference)
    {
      transform.position = position_difference + this_pivot_;

      Vector3 local_position = transform.localPosition;

      if (scroll_content_limits_.b + local_position.y > scroll_viewer_limits_.t)
        local_position.y -= Mathf.Abs(scroll_content_limits_.b + local_position.y - scroll_viewer_limits_.t);

      if (scroll_content_limits_.t + local_position.y < scroll_viewer_limits_.b)
        local_position.y += Mathf.Abs(scroll_content_limits_.t + local_position.y - scroll_viewer_limits_.b);

      if (scroll_content_limits_.l + local_position.x > scroll_viewer_limits_.r)
      {
        local_position.x -= Mathf.Abs(scroll_content_limits_.l + local_position.x - scroll_viewer_limits_.r);
      }

      if (scroll_content_limits_.r + local_position.x < scroll_viewer_limits_.l)
      {
        local_position.x += Mathf.Abs(scroll_content_limits_.r + local_position.x - scroll_viewer_limits_.l);
      }

      local_position.z = 0.0f;
      transform.localPosition = local_position;

      UpdateButtonProperties();
    }

    public override void ButtonPressed()
    {
      is_pressed_ = true;
      if (handDetector.target)
      {
        this_pivot_ = transform.position;
        target_pivot_ = handDetector.target.transform.position;
      }
    }

    public override void ButtonReleased()
    {
      is_pressed_ = false;
    }

    private Limits GetLimits(GameObject game_object)
    {
      Limits limits = new Limits(float.MinValue, float.MaxValue, float.MinValue, float.MaxValue);

      Vector3[] vertices = GetVertices(game_object);
      for (int i = 0; i < vertices.Length; ++i)
      {
        limits.t = Mathf.Max(vertices[i].y * game_object.transform.localScale.y, limits.t);
        limits.b = Mathf.Min(vertices[i].y * game_object.transform.localScale.y, limits.b);
        limits.r = Mathf.Max(vertices[i].x * game_object.transform.localScale.x, limits.r);
        limits.l = Mathf.Min(vertices[i].x * game_object.transform.localScale.x, limits.l);
      }

      return limits;
    }

    private Vector3[] GetVertices(GameObject game_object)
    {
      Vector3[] vertices = new Vector3[0];
      if (game_object.GetComponentInChildren<MeshFilter>())
        vertices = game_object.GetComponentInChildren<MeshFilter>().mesh.vertices;
      else
        vertices = game_object.GetComponent<MeshFilter>().mesh.vertices;
      return vertices;
    }

    void Awake()
    {
      ButtonReleased();

      scroll_viewer_limits_ = GetLimits(scrollBoundaries);
      scroll_content_limits_ = GetLimits(scrollContent);

      Vector3 detector_scale = handDetector.transform.localScale;
      detector_scale.x = (scroll_content_limits_.r - scroll_content_limits_.l);
      detector_scale.y = (scroll_content_limits_.t - scroll_content_limits_.b);
      handDetector.transform.localScale = detector_scale;

      float viewer_height = scroll_viewer_limits_.t - scroll_viewer_limits_.b;
      float viewer_width = scroll_viewer_limits_.r - scroll_viewer_limits_.l;
      if (scroll_content_limits_.t - scroll_content_limits_.b > viewer_height)
      {
        scroll_content_limits_.t -= viewer_height;
        scroll_content_limits_.b += viewer_height;
      }
      else
      {
        scroll_content_limits_.t = viewer_height / 2.0f;
        scroll_content_limits_.b = viewer_height / 2.0f;
      }
      if (scroll_content_limits_.r - scroll_content_limits_.l > viewer_width)
      {
        scroll_content_limits_.r -= viewer_width;
        scroll_content_limits_.l += viewer_width;
      }
      else
      {
        scroll_content_limits_.r = viewer_width / 2.0f;
        scroll_content_limits_.l = viewer_width / 2.0f;
      }
    }

    public override void Update()
    {
      base.Update();
      if (is_pressed_)
      {
        if (handDetector.target)
        {
          UpdatePosition(handDetector.target.transform.position - target_pivot_);
        }
      }
    }
  }
}

