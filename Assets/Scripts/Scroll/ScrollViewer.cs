using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ScrollViewer : MonoBehaviour
  {
    public ScrollContent scrollContent;
    public GameObject scrollBoundaries;
    public GameObject scrollWindow;
    public ScrollCursor scrollCursor;

    private Limits boundaries_ = new Limits();

    public void SetScrollActive(bool active)
    {
      if (active)
      {
        scrollCursor.SetBloomGain(10.0f);
      }
      else
      {
        scrollCursor.SetBloomGain(5.0f);
      }
    }

    // Use this for initialization
    void Start()
    {
      boundaries_.GetLimitsToLocal(scrollBoundaries, gameObject);
      scrollWindow.transform.localPosition = new Vector3((boundaries_.r + boundaries_.l) / 2.0f, (boundaries_.t + boundaries_.b) / 2.0f, 0.0f);
      scrollWindow.transform.localScale = new Vector3((boundaries_.r - boundaries_.l), (boundaries_.t - boundaries_.b), 0.0f);
      scrollCursor.SetLimits(boundaries_.t, boundaries_.b);
      SetScrollActive(false);
    }

    void LateUpdate()
    {
      scrollCursor.UpdatePercent(scrollContent.content_percentage);
    }
  }
}

