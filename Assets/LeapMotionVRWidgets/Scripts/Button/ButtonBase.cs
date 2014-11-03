using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  [RequireComponent(typeof(Rigidbody))]
  [RequireComponent(typeof(BoxCollider))]
  public abstract class ButtonBase : MonoBehaviour
  {
    public float spring = 0.0f;
    public float triggerDistance = 0.0f;
    public float cushionThickness = 0.0f;

    protected Vector3 resting_position_;

    private bool is_pressed_;
    private float constraint_distance_;

    public abstract void ButtonReleased();
    public abstract void ButtonPressed();

    public Vector3 GetPosition()
    {
      if (triggerDistance == 0.0f)
        return Vector3.zero;

      Vector3 position = transform.localPosition;
      position.z = resting_position_.z + Mathf.Clamp(position.z / triggerDistance, 0.0f, 1.0f) * triggerDistance;
      return position;
    }

    protected void SetConstraintDistance(float distance)
    {
      constraint_distance_ = distance;
    }

    protected virtual void ConstraintMovement()
    {
      Vector3 local_position = transform.localPosition;
      local_position.x = resting_position_.x;
      local_position.y = resting_position_.y;
      local_position.z = Mathf.Max(constraint_distance_, local_position.z);
      transform.localPosition = local_position;
    }

    protected void ApplySpring()
    {
      rigidbody.AddForce(-spring * (transform.localPosition - resting_position_));
    }

    protected void CheckTrigger()
    {
      if (is_pressed_ == false)
      {
        if (transform.localPosition.z > triggerDistance)
        {
          ButtonPressed();
          is_pressed_ = true;
        }
      }
      else if (is_pressed_ == true)
      {
        if (transform.localPosition.z < (triggerDistance + cushionThickness))
        {
          ButtonReleased();
          is_pressed_ = false;
        }
      }
    }

    public virtual void Awake()
    {
      is_pressed_ = false;
      resting_position_ = transform.localPosition;
      cushionThickness = Mathf.Clamp(cushionThickness, 0.0f, triggerDistance - 0.001f);
      constraint_distance_ = 0.0f;
    }

    public virtual void Update()
    {
      ConstraintMovement();
      ApplySpring();
      CheckTrigger();
    }
  }
}
