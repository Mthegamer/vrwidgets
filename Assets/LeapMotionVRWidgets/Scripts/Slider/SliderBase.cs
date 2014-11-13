using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public abstract class SliderBase : ButtonBase
  {
    public GameObject upperLimit;
    public GameObject lowerLimit;

    private HandDetector handDetector;
    private Vector3 pivot_ = Vector3.zero;
    private Vector3 target_pivot_ = Vector3.zero;

    public abstract void SliderPressed();
    public abstract void SliderReleased();

    public override void ButtonPressed()
    {
      if (handDetector.target)
      {
        pivot_ = transform.localPosition;
        target_pivot_ = transform.parent.InverseTransformPoint(handDetector.target.transform.position);
      }
      SliderPressed();
    }

    public override void ButtonReleased()
    {
      handDetector.ResetTarget();
      SliderReleased();
    }

    public virtual void UpdatePosition(Vector3 displacement)
    {
      Vector3 local_position = transform.localPosition;
      local_position.x = displacement.x + pivot_.x;
      transform.localPosition = local_position;
    }

    protected override void ApplyConstraints()
    {
      Vector3 local_position = transform.localPosition;
      if (local_position.x < lowerLimit.transform.localPosition.x)
      {
        local_position.x = lowerLimit.transform.localPosition.x;
      }
      if (local_position.x > upperLimit.transform.localPosition.x)
      {
        local_position.x = upperLimit.transform.localPosition.x;
      }
      local_position.y = 0.0f;
      local_position.z = Mathf.Clamp(local_position.z, min_distance_, max_distance_);
      transform.localPosition = local_position;
      transform.rigidbody.velocity = Vector3.zero;
    }

    public override void Awake()
    {
      base.Awake();
      handDetector = GetComponentInChildren<HandDetector>();
    }

    // Update is called once per frame
    public override void Update()
    {
      base.Update();
      if (is_pressed_)
      {
        if (handDetector.target)
        {
          UpdatePosition(transform.parent.InverseTransformPoint(handDetector.target.transform.position) - target_pivot_);
          ApplyConstraints();
        }
      }
    }
  }
}

