using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public enum ButtonState
  {
    INACTIVE,
    ACTIVE
  }

  [RequireComponent(typeof(Rigidbody))]
  [RequireComponent(typeof(BoxCollider))]
  public abstract class ButtonBase : MonoBehaviour
  {
    public float spring = 0.0f;
    public float triggerDistance = 0.0f;
    [Range(0, 1)]
    public float releaseSensitivity = 0.75f;

    protected ButtonState state_;
    protected Vector3 resting_position_;

    private float cushion_;

    public abstract void ButtonReleased();
    public abstract void ButtonPressed();

    protected void ConstraintMovement()
    {
      Vector3 local_position = transform.localPosition;
      local_position.x = resting_position_.x;
      local_position.y = resting_position_.y;
      local_position.z = Mathf.Max(0.0f, local_position.z);
      transform.localPosition = local_position;
    }

    protected void ApplySpring()
    {
      rigidbody.AddForce(-spring * (transform.localPosition - resting_position_));
    }

    protected void CheckTrigger()
    {
      switch (state_) 
      {
        case ButtonState.INACTIVE:
          if (transform.localPosition.z > triggerDistance)
          {
            ButtonPressed();
            state_ = ButtonState.ACTIVE;
          }
          break;
        case ButtonState.ACTIVE:
          if (transform.localPosition.z < cushion_)
          {
            ButtonReleased();
            state_ = ButtonState.INACTIVE;
          }
          break;
        default:
          break;
      }
    }

    public virtual void Awake()
    {
      state_ = ButtonState.INACTIVE;
      resting_position_ = transform.localPosition;
      cushion_ = triggerDistance * releaseSensitivity;
    }

    public virtual void Update()
    {
      ConstraintMovement();
      ApplySpring();
      CheckTrigger();
    }
  }
}
