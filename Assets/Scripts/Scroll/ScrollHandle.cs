using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace VRWidgets
{
  public class ScrollHandle : Button
  {
    public HandDetector handDetector;
    public ScrollViewer scrollViewer;
    public ScrollContent scrollContent;

    private Vector3 this_pivot_ = Vector3.zero;
    private Vector3 content_pivot_ = Vector3.zero;
    private Vector3 target_pivot_ = Vector3.zero;

    private bool is_pressed_ = false;

    public void UpdatePosition(Vector3 position_difference)
    {
      transform.position = position_difference + this_pivot_;
      scrollContent.transform.position = position_difference + content_pivot_;

      UpdateButtonProperties();
    }

    public override void ButtonPressed()
    {
      is_pressed_ = true;
      if (handDetector.target)
      {
        this_pivot_ = transform.position;
        content_pivot_ = scrollContent.transform.position;
        target_pivot_ = handDetector.target.transform.position;
        scrollViewer.SetScrollActive(true);
      }
    }

    public override void ButtonReleased()
    {
      is_pressed_ = false;
      transform.localPosition = Vector3.zero;
      scrollViewer.SetScrollActive(false);
    }

    void Awake()
    {
      ButtonReleased();

      Limits viewer_limits = new Limits();
      viewer_limits.GetLimitsToLocal(scrollViewer.scrollBoundaries, gameObject);

      Vector3 detector_scale = handDetector.transform.localScale;
      detector_scale.x = (viewer_limits.r - viewer_limits.l);
      detector_scale.y = (viewer_limits.t - viewer_limits.b);
      handDetector.transform.localScale = detector_scale;
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

