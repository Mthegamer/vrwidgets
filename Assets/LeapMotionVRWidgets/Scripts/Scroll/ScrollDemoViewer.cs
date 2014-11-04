using UnityEngine;
using System.Collections;
using VRWidgets;

public class ScrollDemoViewer : ScrollViewerBase
{
  public ScrollContentBase content;

  public GameObject cursor = null;
  public GameObject incIndicator = null;
  public GameObject decIndicator = null;

  private float previous_percent_ = -1.0f;

  private void SetRenderers(GameObject game_object, bool enabled)
  {
    Renderer[] renderers = game_object.GetComponentsInChildren<Renderer>();
    foreach (Renderer renderer in renderers)
    {
      renderer.enabled = enabled;
    }
  }

  public void SetBloomGain(float gain)
  {
    Renderer[] renderers = GetComponentsInChildren<Renderer>();
    foreach (Renderer renderer in renderers)
    {
      renderer.material.SetFloat("_Gain", gain);
    }
  }

  public override void ScrollActive()
  {
    SetBloomGain(10.0f);
  }

  public override void ScrollInactive()
  {
    SetBloomGain(5.0f);
  }
  
  public void UpdatePercent(float percent)
  {
    if (previous_percent_ < 0.0f)
      previous_percent_ = percent;

    if (cursor != null)
    {
      Vector3 local_position = cursor.transform.localPosition;
      local_position.y = (boundaries_.t - boundaries_.b) * percent + boundaries_.b;
      cursor.transform.localPosition = local_position;
    }

    SetRenderers(incIndicator, false);
    SetRenderers(decIndicator, false);
    if (percent > previous_percent_ && incIndicator != null)
    {
      SetRenderers(incIndicator, true);
    }
    else if (percent < previous_percent_ && decIndicator != null)
    {
      SetRenderers(decIndicator, true);
    }

    previous_percent_ = percent;
  }

  void LateUpdate()
  {
    UpdatePercent(content.GetPercent());
  }
}
